namespace DotNet8WebApi.GenericRepositoryPatternExample.Api;

public static class ModularService
{
    public static IServiceCollection AddFeatures(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        services
            .AddDbContextService(builder)
            .AddBusinessLogicService()
            .AddRepositoryService()
            .AddJsonService();

        return services;
    }

    private static IServiceCollection AddDbContextService(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        builder.Services.AddDbContext<AppDbContext>(
            opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            },
            ServiceLifetime.Transient
        );

        return services;
    }

    private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
    {
        services.AddScoped<BL_Blog>().AddScoped<BL_Student>();
        return services;
    }

    private static IServiceCollection AddRepositoryService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        return services;
    }

    private static IServiceCollection AddJsonService(this IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }
}
