using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shops;

[Table("filter_params", Schema = "shop")]
public class FilterParam : ModelBase
{
    [Column("value")] public string Value { get; set; }
    public List<FilterParamValue> FilterParamValues { get; set; }
}