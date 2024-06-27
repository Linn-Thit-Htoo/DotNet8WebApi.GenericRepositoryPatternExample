namespace DotNet8WebApi.GenericRepositoryPatternExample.Shared;

public static class DevCode
{
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
    }
}