using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {/// <summary>
     /// Id que ira representar um código sequencial na intidade e  no banco de dados.
     /// dados que sao considerados como atributos no projeto e colunas no banco de dados.
     /// </summary>
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio!")]//usando o DataAnnotations para validar campo tornando obrigatorio
        public string ?Name { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        [EmailAddress(ErrorMessage = "E-mail inválido ")]
        public string ?Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio!")]
        [Phone(ErrorMessage ="Celular inválido")]
        public string ?Celular { get; set; }
        
    }
}
