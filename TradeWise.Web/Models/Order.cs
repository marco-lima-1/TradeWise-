using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeWise.Web.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string UserId { get; set; } = string.Empty;
        
        [Required]
        public int AssetId { get; set; }
        
        [Required]
        public OrderType Type { get; set; } // Buy ou Sell
        
        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        
        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal Quantity { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal Price { get; set; } // Preço unitário no momento da ordem
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; } // Quantity * Price
        
        [Column(TypeName = "decimal(18,8)")]
        public decimal? ExecutedQuantity { get; set; }
        
        [Column(TypeName = "decimal(18,8)")]
        public decimal? ExecutedPrice { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ExecutedAmount { get; set; }
        
        [Column(TypeName = "decimal(8,4)")]
        public decimal Fee { get; set; } = 0.001m; // Taxa de 0.1%
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal FeeAmount { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? ExecutedAt { get; set; }
        
        public DateTime? CancelledAt { get; set; }
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        [StringLength(100)]
        public string? CancellationReason { get; set; }
        
        // Relacionamentos
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        
        [ForeignKey("AssetId")]
        public virtual Asset Asset { get; set; } = null!;
        
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
    
    public enum OrderType
    {
        Buy = 1,
        Sell = 2
    }
    
    public enum OrderStatus
    {
        Pending = 1,
        PartiallyFilled = 2,
        Filled = 3,
        Cancelled = 4,
        Failed = 5
    }
} 
