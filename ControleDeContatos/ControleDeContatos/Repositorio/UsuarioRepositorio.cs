using ControleDeContatos.Models;
using ControleDeContatos.NovaPasta3;
using Microsoft.EntityFrameworkCore;
namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    { private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsuarioModel listarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);//para buscar o primeiro ou o item que esta dentro de contatos ,
                                                           //com uma clausula que diz que eu quero todo mundo da tabela contato
                                                           //onde x=>x.Id== ao Id.
        }
        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();//Carrega tudo para a lista de contatosmodel"buscaTOdos"
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //gravar no banco de dados 
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();//comitando a informação para o banco usando o metodo SaveChanges()
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB=listarPorId(usuario.Id);
            if (usuarioDB == null) throw new System.Exception("Erro na atualização do contato!");
            usuarioDB.Name= usuario.Name;
            usuarioDB.Email= usuario.Email;
            usuarioDB.Login= usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;
            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();
            return usuarioDB;
        }
        public bool ApagarContato(int id)
        {
            UsuarioModel contatoDB = listarPorId(id);
            if (contatoDB == null) throw new System.Exception("Erro na deleção do contato!");
            _bancoContext.Usuarios.Update(contatoDB);
            _bancoContext.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }

        ContatoModel IUsuarioRepositorio.listarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
