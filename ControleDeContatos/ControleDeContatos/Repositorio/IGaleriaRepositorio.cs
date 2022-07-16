using CadastrosBiblioteca.Models;

namespace CadastrosBiblioteca.Repositorio
{
    public interface IGaleriaRepositorio
    {
        GaleriaModel listarPorId(int id);
        GaleriaModel Adicionar(GaleriaModel galeria);
        List<GaleriaModel> BuscarTodos();
        GaleriaModel Atualizar(GaleriaModel galeria);
        public bool ApagarGaleria(int id);
    }
}
