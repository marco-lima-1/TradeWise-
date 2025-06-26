using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeWise.API.Models
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Symbol { get; set; } = string.Empty; // BTC, ETH, etc.
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty; // Bitcoin, Ethereum, etc.
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [StringLength(255)]
        public string? IconUrl { get; set; }
        
        [Required]
        [StringLength(50)]
        public string CoinGeckoId { get; set; } = string.Empty; // ID para API do CoinGecko
        
        [Column(TypeName = "decimal(18,8)")]
        public decimal CurrentPrice { get; set; }
        
        [Column(TypeName = "decimal(18,8)")]
        public decimal PreviousPrice { get; set; }
        
        [Column(TypeName = "decimal(10,4)")]
        public decimal PriceChange24h { get; set; }
        
        [Column(TypeName = "decimal(10,4)")]
        public decimal PriceChangePercentage24h { get; set; }
        
        [Column(TypeName = "decimal(20,2)")]
        public decimal MarketCap { get; set; }
        
        [Column(TypeName = "decimal(20,2)")]
        public decimal Volume24h { get; set; }
        
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Relacionamentos
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public virtual ICollection<PriceHistory> PriceHistories { get; set; } = new List<PriceHistory>();
    }
} 
