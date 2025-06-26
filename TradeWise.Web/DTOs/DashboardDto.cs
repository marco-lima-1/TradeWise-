namespace TradeWise.API.DTOs
{
    public class DashboardDto
    {
        public decimal TotalBalance { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal InvestedAmount { get; set; }
        public decimal TotalProfitLoss { get; set; }
        public decimal TotalProfitLossPercentage { get; set; }
        public decimal TotalPortfolioValue { get; set; }
        
        public List<PortfolioItemDto> Portfolio { get; set; } = new();
        public List<RecentOrderDto> RecentOrders { get; set; } = new();
        public List<AssetPriceDto> TopAssets { get; set; } = new();
        public List<PriceChartDto> PriceHistory { get; set; } = new();
        
        // Estatísticas adicionais
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int ExecutedOrders { get; set; }
        public DateTime LastActivity { get; set; }
    }
    
    public class PortfolioItemDto
    {
        public int AssetId { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? IconUrl { get; set; }
        public decimal Quantity { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal ProfitLoss { get; set; }
        public decimal ProfitLossPercentage { get; set; }
        public decimal PortfolioPercentage { get; set; }
        
        // Propriedades calculadas
        public string ProfitLossDisplay => ProfitLoss >= 0 ? $"+${ProfitLoss:N2}" : $"-${Math.Abs(ProfitLoss):N2}";
        public string ProfitLossClass => ProfitLoss >= 0 ? "text-success" : "text-danger";
    }
    
    public class RecentOrderDto
    {
        public int Id { get; set; }
        public string AssetSymbol { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        
        // Propriedades para exibição
        public string TypeClass => Type.ToLower() == "buy" ? "text-success" : "text-danger";
        public string StatusClass => Status.ToLower() switch
        {
            "filled" => "text-success",
            "pending" => "text-warning",
            "cancelled" => "text-secondary",
            "failed" => "text-danger",
            _ => "text-info"
        };
    }
    
    public class AssetPriceDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? IconUrl { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal PriceChange24h { get; set; }
        public decimal PriceChangePercentage24h { get; set; }
        public decimal MarketCap { get; set; }
        public decimal Volume24h { get; set; }
        
        // Propriedades calculadas
        public string PriceChangeDisplay => PriceChange24h >= 0 ? $"+{PriceChange24h:N2}" : $"{PriceChange24h:N2}";
        public string PriceChangeClass => PriceChange24h >= 0 ? "text-success" : "text-danger";
        public string PriceChangePercentageDisplay => PriceChangePercentage24h >= 0 ? $"+{PriceChangePercentage24h:N2}%" : $"{PriceChangePercentage24h:N2}%";
    }
    
    public class PriceChartDto
    {
        public DateTime Timestamp { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        
        // Para Chart.js
        public long TimestampMs => ((DateTimeOffset)Timestamp).ToUnixTimeMilliseconds();
    }
} 
