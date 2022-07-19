using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {

        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel listarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
       public bool ApagarContato(int id);
    }
}
