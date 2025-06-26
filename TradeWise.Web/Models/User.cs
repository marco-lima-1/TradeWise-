using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeWise.Web.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; } = 10000; // Saldo inicial fictício
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? LastLoginAt { get; set; }
        
        // Propriedade calculada para nome completo
        public string FullName => $"{FirstName} {LastName}";
        
        // Relacionamentos
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
} 