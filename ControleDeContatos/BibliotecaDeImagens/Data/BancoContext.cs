using CadastrosBiblioteca.Models;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.NovaPasta3
{
    public class BancoContext:DbContext
    {                                                                
       public BancoContext(DbContextOptions<BancoContext> options ):base(options)// neste caso estou passando a informação de options para o DbContext
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImagemModel>().ToTable("Imagem");
            modelBuilder.Entity<GaleriaModel>().ToTable("Galeria");
        }
        public DbSet<ContatoModel> Contatos { get; set; }// criando a tabela contato informando que a classe ContatoModel é a classe que representa a tabela no banco de dados 
        public DbSet<UsuarioModel>Usuarios { get; set; }
        public DbSet<ImagemModel> Imagens { get; set; }
        public DbSet<GaleriaModel> Galerias { get; set; }

    }
}
