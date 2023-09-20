using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class ModelBase
{   
    [Column("id")]
    public long Id { get; set; }
   
}