using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeWise.Web.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string UserId { get; set; } = string.Empty;
        
        public int? OrderId { get; set; } // Pode ser null para outras transações (depósitos, etc.)
        
        [Required]
        public TransactionType Type { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? AssetQuantity { get; set; }
        
        [Column(TypeName = "decimal(18,8)")]
        public decimal? AssetPrice { get; set; }
        
        public int? AssetId { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Fee { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal BalanceBefore { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal BalanceAfter { get; set; }
        
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? Reference { get; set; } // Referência externa se houver
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Relacionamentos
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
        
        [ForeignKey("AssetId")]
        public virtual Asset? Asset { get; set; }
    }
    
    public enum TransactionType
    {
        Buy = 1,           // Compra de ativo
        Sell = 2,          // Venda de ativo
        Deposit = 3,       // Depósito de dinheiro
        Withdrawal = 4,    // Saque de dinheiro
        Fee = 5,          // Taxa cobrada
        Bonus = 6,        // Bônus creditado
        Refund = 7        // Reembolso
    }
} 
