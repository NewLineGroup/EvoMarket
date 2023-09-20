using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Models;

public class ModelBase
{
    [Column("id")]
    public int Id { get; set; }
}