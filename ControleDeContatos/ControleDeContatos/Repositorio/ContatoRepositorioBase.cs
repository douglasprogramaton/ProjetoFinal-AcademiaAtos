using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorioBase
    {
        public ContatoModel listarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);//para buscar o primeiro ou o item que esta dentro de contatos ,
                                                                          //com uma clausula que diz que eu quero todo mundo da tabela contato
                                                                          //onde x=>x.Id== ao Id.
        }
    }
}