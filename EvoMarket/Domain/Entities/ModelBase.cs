using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public abstract class ModelBase
{
    [Column("id")] public long Id { get; set; }
}