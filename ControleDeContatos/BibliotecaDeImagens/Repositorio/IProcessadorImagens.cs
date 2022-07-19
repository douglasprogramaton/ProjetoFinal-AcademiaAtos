namespace CadastrosBiblioteca.Repositorio;

public interface IProcessadorImagens
{
    Task<bool> SalvarUploadImagemAsync(string caminhoArquivoImagem,IFormFile imagem);

    Task<bool> ExcluirImagemAsync(string caminhoArquivoImagem);
    /// <summary>
    ///Está task com o tipo efeito imagem, com 2 parâmetros  um com o caminhho da imagem, e outro com o efeito
    ///que será aplicado então houve a necessidade de criar um tipo efeitoImagem.
    /// </summary>
    /// <param name="caminhoArquivoImagem"></param>
    /// <param name="efeito"></param>
    /// <returns></returns>
    Task<bool> AplicarEfeitoAsync(string caminhoArquivoImagem, EfeitoImagem efeito);
}
