using CadastrosBiblioteca.Models;
using ControleDeContatos.NovaPasta3;

namespace CadastrosBiblioteca.Repositorio
{
    public class GaleriaRepositorio : IGaleriaRepositorio
    {
        private readonly BancoContext _bancoContext;

        public GaleriaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public GaleriaModel listarPorId(int id)
        {
            return _bancoContext.Galerias.FirstOrDefault(x => x.IdGaleria == id);//para buscar o primeiro ou o item que esta dentro de contatos ,
                                                                          //com uma clausula que diz que eu quero todo mundo da tabela contato
                                                                          //onde x=>x.Id== ao Id.
        }
        public List<GaleriaModel> BuscarTodos()
        {
            return _bancoContext.Galerias.ToList();//Carrega tudo para a lista de contatosmodel"buscaTOdos"
        }
        public GaleriaModel Adicionar(GaleriaModel galeria)
        {
          
            _bancoContext.Galerias.Add(galeria);
            _bancoContext.SaveChanges();
            return galeria;
        }
        public GaleriaModel Atualizar(GaleriaModel galeria)
        {
            GaleriaModel galeriaDB = listarPorId(galeria.IdGaleria);
            if (galeriaDB == null) throw new System.Exception("Erro na atualização do contato!");
            galeria.Titulo = galeria.Titulo;
            _bancoContext.Galerias.Update(galeriaDB);
            _bancoContext.SaveChanges();
            return galeriaDB;
        }
        public bool ApagarGaleria(int id)
        {
                 GaleriaModel galeriaDB = listarPorId(id);
                if (galeriaDB == null) throw new System.Exception("Erro na deleção do contato!");
                _bancoContext.Galerias.Update(galeriaDB);
                _bancoContext.Remove(galeriaDB);
                _bancoContext.SaveChanges();
                return true;
            
        }
    }
}
