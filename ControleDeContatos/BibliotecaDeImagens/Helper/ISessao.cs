using ControleDeContatos.Models;

namespace ControleDeContatos.Helper
{
    public interface ISessao
    {
       public void CriarSessaoDoUsuario(UsuarioModel usuario);
       public void RemoverSessaoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }

}
