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
        /// <summary>
        /// Quando a Propriedade Virtual nao é usada nesse tipo de aplicação significa que
        /// o lateloading que =significa carregamento tardido
        /// </summary>
        public ICollection<ImagemModel> ?Imagens { get; set; }
    }
}
