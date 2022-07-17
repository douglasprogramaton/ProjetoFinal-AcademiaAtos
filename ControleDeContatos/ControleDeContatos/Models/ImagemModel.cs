using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastrosBiblioteca.Models
{
    public class ImagemModel
    {
        [Key]
        public int IdImagem { get; set; }
        [Required]
        [Display(Name = "Título da Imagem")]
        public string Titulo { get; set; }
        public int IdGaleria { get; set; }
        [ForeignKey("IdGaleria")]
        public GaleriaModel? Galerias { get; set; }
        [NotMapped,Required(ErrorMessage ="Imagem não enviada.")]
        [Display(Name ="Arquivo da imagem")]
        public IFormFile ArquivoImagem  { get; set; }
        [NotMapped]
        public string CaminhoImagem
        {
            get
            {
                var caminhoArquivoImagem = Path.Combine($"\\Images\\", IdImagem.ToString("D6") + ".webp");
                return caminhoArquivoImagem;
            }
        }
    }
}
