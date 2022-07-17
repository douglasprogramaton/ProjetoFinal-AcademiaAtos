using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace CadastrosBiblioteca.Repositorio
{
    public class ProcessadorImagmService : IProcessadorImagens
    {
        public async Task<bool> AplicarEfeitoAsync(string caminhoArquivoImagem, EfeitoImagem efeito)
        {
            var fs = new FileStream(caminhoArquivoImagem, FileMode.Open,FileAccess.Read);
            var img =await Image.LoadAsync(fs);
            fs.Close();
            switch (efeito) 
            {
                case EfeitoImagem.RotacionarDireita:
                    RotacionarDireita(img);
                    break;
                case EfeitoImagem.RotacionarEsquerda:
                    RotacionarEsquerda(img);
                    break;
                case EfeitoImagem.InverterHorizontal:
                    InverterHorizontal(img);
                    break;
                case EfeitoImagem.InverterVertical:
                    InverterVertical(img);
                    break;
                case EfeitoImagem.EscalaDeCinza:
                    AplicarEscalaDeCinza(img);
                    break;
                case EfeitoImagem.Sepia:
                    AplicarSepia(img);
                    break;
                case EfeitoImagem.Desfoque:
                    AplicarDesfoque(img);
                    break;
                case EfeitoImagem.Negativo:
                    AplicarNegarivo(img);
                    break;
            }
            await img.SaveAsync(caminhoArquivoImagem);
            return true;

        }
        private void RotacionarDireita(Image img)
        {
            img.Mutate(x => x.Rotate(90));
        }
        private void RotacionarEsquerda(Image img)
        {
            img.Mutate(x => x.Rotate(-90));
        }
        private void InverterHorizontal(Image img)
        {
            img.Mutate(x => x.Flip(FlipMode.Horizontal));
        }
        private void InverterVertical(Image img)
        {
            img.Mutate(x => x.Flip(FlipMode.Vertical));
        }
        private void AplicarEscalaDeCinza(Image img)
        {
            img.Mutate(x => x.Grayscale());
        }
        private void AplicarDesfoque(Image img)
        {
            img.Mutate(x => x.GaussianBlur());
        }
        private void AplicarSepia(Image img)
        {
            img.Mutate(x => x.Sepia());
        }
        private void AplicarNegarivo(Image img)
        {
            img.Mutate(x => x.Invert());
        }
        public async Task<bool> ExcluirImagemAsync(string caminhoArquivoImagem)
        {
            if (File.Exists(caminhoArquivoImagem))
            {
                try
                {
                    File.Delete(caminhoArquivoImagem);
                    return true;
                }
                catch (IOException)
                {
                    return await Task.FromResult(false);
                    
                }
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> SalvarUploadImagemAsync(string caminhoArquivoImagem, IFormFile imagem)
        {
            if(imagem == null)
            {
                return false;
            }
            var ms= new MemoryStream();
            await imagem.CopyToAsync(ms);
            ms.Position = 0;
            return await SalvarImagemComoWebpAsync(caminhoArquivoImagem, ms,true);
        }

        private static async Task<bool> SalvarImagemComoWebpAsync(string caminhoArquivoImagem, MemoryStream ms, bool quadrada=true)
        {
            var img = await Image.LoadAsync(ms);
            var extensaoImagem = caminhoArquivoImagem.Substring(caminhoArquivoImagem.LastIndexOf('.')).ToLower();
            
            
            if (quadrada)// fraz a transformação da imagem para que ela fique quadrada de acordo com seu menor lado 
            {
                var tamanho = img.Size();
                var ladoMenor= (tamanho.Height<tamanho.Width)? tamanho.Height :tamanho.Width;
                img.Mutate(x =>
                x.Resize(new ResizeOptions
                { Size = new Size(ladoMenor, ladoMenor),
                    Mode = ResizeMode.Crop
                }).BackgroundColor(new Rgba32(255, 255, 255, 0)));
          
            }
            caminhoArquivoImagem = caminhoArquivoImagem.Replace(extensaoImagem, ".webp");// substituindo a extensao original por webp
            await img.SaveAsWebpAsync(caminhoArquivoImagem);
            return true;
        }
    }
}
