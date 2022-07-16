using CadastrosBiblioteca.Repositorio;
using ControleDeContatos.NovaPasta3;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosBiblioteca.Controllers
{
    public class ImagemController :Controller
    {
        private readonly BancoContext _bancoContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public ImagemController(BancoContext bancoContext, IWebHostEnvironment webHostEnvironment)
        {
            _bancoContext = bancoContext;
            _webHostEnvironment = webHostEnvironment;
            
        }
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var galeria = _bancoContext.Galerias.Find(id);
            if (galeria == null)
            {
                return NotFound();
            }
            _bancoContext.Entry(galeria).Collection(g => g.Imagens).Load();
            ViewBag.IdGaleria = id.Value;
            ViewBag.TituloGaleria = galeria.Titulo;
#pragma warning disable CS8604 // Possível argumento de referência nula.
            return View(galeria.Imagens.ToList());
#pragma warning restore CS8604 // Possível argumento de referência nula.
        } 

    }   
}
