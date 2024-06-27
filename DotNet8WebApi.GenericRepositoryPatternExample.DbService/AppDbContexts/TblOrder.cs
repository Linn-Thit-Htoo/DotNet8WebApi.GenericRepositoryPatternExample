using System;
using System.Collections.Generic;

namespace DotNet8WebApi.GenericRepositoryPatternExample.DbService.AppDbContexts;

public partial class TblOrder
{
    public string OrderId { get; set; } = null!;

    public string CustomerCode { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public decimal Discount { get; set; }

    public DateTime OrderDate { get; set; }
}
