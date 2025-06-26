using System.ComponentModel.DataAnnotations;
using TradeWise.Web.Models;

namespace TradeWise.API.DTOs
{
    public class CreateOrderDto
    {
        [Required(ErrorMessage = "Ativo é obrigatório")]
        public int AssetId { get; set; }
        
        [Required(ErrorMessage = "Tipo de ordem é obrigatório")]
        public OrderType Type { get; set; }
        
        [Required(ErrorMessage = "Quantidade é obrigatória")]
        [Range(0.00000001, double.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
        public decimal Quantity { get; set; }
        
        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
        public decimal Price { get; set; }
        
        [StringLength(500, ErrorMessage = "Observações devem ter no máximo 500 caracteres")]
        public string? Notes { get; set; }
        
        // Propriedade calculada para exibição
        public decimal TotalAmount => Quantity * Price;
        
        // Propriedade para validação do valor mínimo
        public decimal MinOrderAmount { get; set; } = 10m;
        
        // Propriedade para validação do valor máximo
        public decimal MaxOrderAmount { get; set; } = 100000m;
    }
    
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public string AssetSymbol { get; set; } = string.Empty;
        public string AssetName { get; set; } = string.Empty;
        public OrderType Type { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? ExecutedQuantity { get; set; }
        public decimal? ExecutedPrice { get; set; }
        public decimal? ExecutedAmount { get; set; }
        public decimal Fee { get; set; }
        public decimal FeeAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExecutedAt { get; set; }
        public DateTime? CancelledAt { get; set; }
        public string? Notes { get; set; }
        public string? CancellationReason { get; set; }
        
        // Propriedades calculadas
        public string TypeDisplay => Type == OrderType.Buy ? "Compra" : "Venda";
        public string StatusDisplay => Status switch
        {
            OrderStatus.Pending => "Pendente",
            OrderStatus.PartiallyFilled => "Parcialmente Executada",
            OrderStatus.Filled => "Executada",
            OrderStatus.Cancelled => "Cancelada",
            OrderStatus.Failed => "Falhou",
            _ => Status.ToString()
        };
    }
} 
