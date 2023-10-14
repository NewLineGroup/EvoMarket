using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shops;

[Table("filter_params", Schema = "shop")]
public class FilterParam : ModelBase
{
    [Column("param_name")] public string ParamName { get; set; }
   // public List<string> ParamValues { get; set; }
}