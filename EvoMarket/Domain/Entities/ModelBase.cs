using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class ModelBase
{
    [Column("id")] public long Id { get; set; }
    [Column("create_date")] public DateTime CreateDate { get; set; }
    [Column("update_date")] public DateTime UpdateDate { get; set; }
}