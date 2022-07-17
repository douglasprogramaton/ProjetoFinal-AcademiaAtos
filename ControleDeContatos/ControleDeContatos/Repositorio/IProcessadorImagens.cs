﻿namespace CadastrosBiblioteca.Repositorio;

public interface IProcessadorImagens
{
    Task<bool> SalvarUploadImagemAsync(string caminhoArquivoImagem,IFormFile imagem);

    Task<bool> ExcluirImagemAsync(string caminhoArquivoImagem);

    Task<bool> AplicarEfeitoAsync(string caminhoArquivoImagem, EfeitoImagem efeito);
}
