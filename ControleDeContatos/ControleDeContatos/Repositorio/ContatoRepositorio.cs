using ControleDeContatos.Models;
using ControleDeContatos.NovaPasta3;
using Microsoft.EntityFrameworkCore;
namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    { private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel listarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);//para buscar o primeiro ou o item que esta dentro de contatos ,
                                                           //com uma clausula que diz que eu quero todo mundo da tabela contato
                                                          //onde x=>x.Id== ao Id.
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();//Carrega tudo para a lista de contatosmodel"buscaTOdos"
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar no banco de dados 
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();//comitando a informação para o banco usando o metodo SaveChanges()
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB=listarPorId(contato.Id);
            if (contatoDB == null) throw new System.Exception("Erro na atualização do contato!");
            contatoDB.Name= contato.Name;
            contatoDB.Email= contato.Email;
            contatoDB.Celular= contato.Celular;
            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }
        public bool ApagarContato(int id)
        {
            ContatoModel contatoDB = listarPorId(id);
            if (contatoDB == null) throw new System.Exception("Erro na deleção do contato!");
            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
