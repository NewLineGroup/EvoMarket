using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public abstract class AuditableModelBase : ModelBase
{
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}