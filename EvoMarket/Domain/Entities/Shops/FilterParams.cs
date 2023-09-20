using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shops;

public class FilterParams:ModelBase
{
    [Column("value")]
    public string Value { get; set; }
    [Column("filter_param_value")]
    public FilterParamValues FilterParamValues { get; set; }
}