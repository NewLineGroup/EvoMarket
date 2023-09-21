using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class ModelBase
{
    [Column("id")] public long Id { get; set; }
    [Column("SaveDate")] public DateTime SaveDate { get; set; }
    [Column("UpdateDate")] public DateTime UpdateDate { get; set; }
}