using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Shop.Models;

public class FilterParamValues:ModelBase
{
    [Column("filter_param_id")]
    public long FilterParamId { get; set; }
    [Column("value")]
    public string Value { get; set; }
}