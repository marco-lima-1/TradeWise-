using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeWise.Web.Models
{
    public class PriceHistory
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int AssetId { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,8)")]
        public decimal Price { get; set; }
        
        [Column(TypeName = "decimal(20,2)")]
        public decimal Volume { get; set; }
        
        [Column(TypeName = "decimal(20,2)")]
        public decimal MarketCap { get; set; }
        
        [Required]
        public DateTime Timestamp { get; set; }
        
        [Required]
        public PriceInterval Interval { get; set; } = PriceInterval.OneHour;
        
        // Relacionamentos
        [ForeignKey("AssetId")]
        public virtual Asset Asset { get; set; } = null!;
    }
    
    public enum PriceInterval
    {
        OneMinute = 1,
        FiveMinutes = 5,
        FifteenMinutes = 15,
        OneHour = 60,
        FourHours = 240,
        OneDay = 1440,
        OneWeek = 10080
    }
} 
