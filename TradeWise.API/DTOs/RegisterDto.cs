using System.ComponentModel.DataAnnotations;

namespace TradeWise.API.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        [StringLength(100, ErrorMessage = "Sobrenome deve ter no máximo 100 caracteres")]
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(6, ErrorMessage = "Senha deve ter pelo menos 6 caracteres")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*#?&]{6,}$", 
            ErrorMessage = "Senha deve conter pelo menos uma letra e um número")]
        public string Password { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Confirmação de senha é obrigatória")]
        [Compare("Password", ErrorMessage = "Senhas não coincidem")]
        public string ConfirmPassword { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Você deve aceitar os termos de uso")]
        public bool AcceptTerms { get; set; } = false;
    }
} 
