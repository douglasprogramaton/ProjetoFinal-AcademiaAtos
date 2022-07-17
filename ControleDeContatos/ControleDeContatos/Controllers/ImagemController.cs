
using CadastrosBiblioteca.Models;
using CadastrosBiblioteca.Repositorio;
using ControleDeContatos.NovaPasta3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Controllers;

public class ImagemController : Controller
{
    private readonly BancoContext db;

    private readonly IWebHostEnvironment env;

    private readonly IProcessadorImagens pi;

    public ImagemController(BancoContext db,
        IWebHostEnvironment environment,
        IProcessadorImagens processadorImagem)
    {
        this.db = db;
        this.env = environment;
        this.pi = processadorImagem;
    }

    public IActionResult Index(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var galeria = db.Galerias.Find(id);
        if (galeria == null)
        {
            return NotFound();
        }
        db.Entry(galeria).Collection(g => g.Imagens).Load();
        ViewBag.IdGaleria = id.Value;
        ViewBag.TituloGaleria = galeria.Titulo;
        return View(galeria.Imagens.ToList());
    }

    public IActionResult Cadastrar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var galeria = db.Galerias.Find(id);
        if (galeria == null)
        {
            return NotFound();
        }
        var novaImagem = new ImagemModel() { IdGaleria = galeria.IdGaleria };
        return View(novaImagem);
    }

    private string ObterCaminhoImagem(string pastaImagens, int idImagem, string extensao)
    {
        // <APPDIR>/wwwroot/imagens
        string caminhoPastaImagens = env.WebRootPath + pastaImagens;
        var nomeArquivo = $"{idImagem:D6}{extensao}"; // 000001.webp
                                                      // <APPDIR>/wwwroot/imagens/000001.webp
        var caminhoArquivoImagem = Path.Combine(caminhoPastaImagens, nomeArquivo);
        return caminhoArquivoImagem;
    }

    [HttpPost]
    public IActionResult Cadastrar(ImagemModel imagem)
    {
        if (ModelState.IsValid)
        {
            db.Imagens.Add(imagem);
            if (db.SaveChanges() > 0)
            {
                string caminhoArquivoImagem = ObterCaminhoImagem("\\Images\\", imagem.IdImagem, ".webp");
                pi.SalvarUploadImagemAsync(caminhoArquivoImagem, imagem.ArquivoImagem).Wait();
            }
            return RedirectToAction("Index", "Imagem", new { id = imagem.IdGaleria });
        }
        return View(imagem);
    }

    public IActionResult Alterar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var imagem = db.Imagens.Find(id);
        if (imagem == null)
        {
            return NotFound();
        }
        return View(imagem);
    }

    [HttpPost]
    public IActionResult Alterar(ImagemModel imagem)
    {
        ModelState.Remove("ArquivoImagem");
        if (ModelState.IsValid)
        {
            db.Entry(imagem).State = EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                if (imagem.ArquivoImagem != null)
                {
                    string caminhoArquivoImagem = ObterCaminhoImagem("\\Images\\", imagem.IdImagem, ".webp");
                    pi.SalvarUploadImagemAsync(caminhoArquivoImagem, imagem.ArquivoImagem).Wait();
                }
            }
            return RedirectToAction("Index", new { id = imagem.IdGaleria });
        }
        return View(imagem);
    }

    public IActionResult Excluir(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var imagem = db.Imagens.Find(id);
        if (imagem == null)
        {
            return NotFound();
        }
        return View(imagem);
    }

    [HttpPost, ActionName("Excluir")]
    public IActionResult ExecutarExclusao(int id)
    {
        var imagem = db.Imagens.Find(id);
        db.Remove(imagem);
        if (db.SaveChanges() > 0)
        {
            string caminhoArquivoImagem = ObterCaminhoImagem("\\Images\\", id, ".webp");
            pi.ExcluirImagemAsync(caminhoArquivoImagem);
        }
        return RedirectToAction("Index", "Imagem", new { id = imagem.IdGaleria });
    }

    [HttpGet]
    public IActionResult AplicarEfeito(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var imagem = db.Imagens.Find(id);
        if (imagem == null)
        {
            return NotFound();
        }
        return View("Efeitos", imagem);
    }

    [HttpPost]
    public IActionResult AplicarEfeito(int id, string efeito)
    {
        string caminhoArquivoImagem = ObterCaminhoImagem("\\Images\\", id, ".webp");
        switch (efeito)
        {
            case "rr":
                pi.AplicarEfeitoAsync(caminhoArquivoImagem,
                    EfeitoImagem.RotacionarDireita).Wait();
                break;
            case "rl":
                pi.AplicarEfeitoAsync(caminhoArquivoImagem,
                    EfeitoImagem.RotacionarEsquerda).Wait();
                break;
            case "ih":
                pi.AplicarEfeitoAsync(caminhoArquivoImagem,
                    EfeitoImagem.InverterHorizontal).Wait();
                break;
            case "iv":
                pi.AplicarEfeitoAsync(caminhoArquivoImagem,
                    EfeitoImagem.InverterVertical).Wait();
                break;
            case "gs":
                pi.AplicarEfeitoAsync(caminhoArquivoImagem,
                    EfeitoImagem.EscalaDeCinza).Wait();
                break;
            case "sp":
                pi.AplicarEfeitoAsync(caminhoArquivoImagem,
                    EfeitoImagem.Sepia).Wait();
                break;
            case "ng":
                pi.AplicarEfeitoAsync(caminhoArquivoImagem,
                    EfeitoImagem.Negativo).Wait();
                break;
            case "df":
                pi.AplicarEfeitoAsync(caminhoArquivoImagem,
                    EfeitoImagem.Desfoque).Wait();
                break;
        }
        return RedirectToAction("AplicarEfeito", new { id = id });
    }
}

    