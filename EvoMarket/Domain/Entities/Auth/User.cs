using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Auth;

    [Table("users")]
    public class User:ModelBase
    {
        [Required]
        [Column("email")]
        public string Email { get; set; }
        [Column("password_hash_string")]
        public string PasswordHashString { get; set; }
        [Column("client_id")]
        public int ClinetId { get; set; }
        [Column("otp")]
        public string? Otp { get; set; }
        [Column("expire_date")]
        public DateTime? ExpireDate { get; set; }
    }
