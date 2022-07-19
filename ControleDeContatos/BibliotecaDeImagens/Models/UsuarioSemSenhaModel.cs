using ControleDeContatos.Enuns;
using System.ComponentModel.DataAnnotations;
using ControleDeContatos.Models;

namespace ControleDeContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio!")]
        [EmailAddress(ErrorMessage = "E-mail inválido ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public PerfilEnum? Perfil { get; set; }
     
    }
}
