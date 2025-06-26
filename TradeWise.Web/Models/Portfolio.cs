using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeWise.Web.Models
{
    public class Portfolio
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string UserId { get; set; } = string.Empty;
        
        [Required]
        public int AssetId { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal Quantity { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal AveragePrice { get; set; } // Preço médio de compra
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCost { get; set; } // Custo total investido
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentValue { get; set; } // Valor atual da posição
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProfitLoss { get; set; } // Lucro/Prejuízo
        
        [Column(TypeName = "decimal(10,4)")]
        public decimal ProfitLossPercentage { get; set; } // Percentual de lucro/prejuízo
        
        public DateTime FirstPurchaseAt { get; set; } = DateTime.UtcNow;
        
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        
        // Relacionamentos
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        
        [ForeignKey("AssetId")]
        public virtual Asset Asset { get; set; } = null!;
    }
} 
