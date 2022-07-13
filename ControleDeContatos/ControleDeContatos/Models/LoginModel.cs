using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Senha { get; set; }
    }
}
