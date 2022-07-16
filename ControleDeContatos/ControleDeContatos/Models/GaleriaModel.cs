using System.ComponentModel.DataAnnotations;
namespace CadastrosBiblioteca.Models
{
    public class GaleriaModel
    {
        [Key]
        [Display(Name = "Código")]
        public int IdGaleria { get; set; }
        [Required]
        [Display(Name = "Título da Galeria")]
        public string Titulo { get; set; }

        public ICollection<ImagemModel> ?Imagens { get; set; }
    }
}
