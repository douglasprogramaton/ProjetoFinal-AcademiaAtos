using CadastrosBiblioteca.Models;
using CadastrosBiblioteca.Repositorio;
using ControleDeContatos.NovaPasta3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastrosBiblioteca.Controllers
{
    public class GaleriasController : Controller
    {
        private readonly BancoContext _bancoContext;
        private readonly IGaleriaRepositorio _galeriaRepositorio;
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public GaleriasController(IGaleriaRepositorio galeriaRepositorio)
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        {
            _galeriaRepositorio = galeriaRepositorio;
        }
        public IActionResult Index()
        {
            List<GaleriaModel> galeria = _galeriaRepositorio.BuscarTodos();
            return View(galeria);

        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Apagar(int id)
        {
            GaleriaModel contato = _galeriaRepositorio.listarPorId(id);
            return View(contato);
        }
        public IActionResult Apagarconfirmar(int id)
        {
            try
            {
                bool apagado = _galeriaRepositorio.ApagarGaleria(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Não foi possivel cadastrar seu contato, Tente novamente";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel cadastrar seu contato, Tente novamente, detalhe do erro:{erro.Message}!";
                return RedirectToAction("Index");
            }


        }
        [HttpPost]
        public IActionResult Criar(GaleriaModel galeria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _galeriaRepositorio.Adicionar(galeria);
                    return RedirectToAction("Index");
                }
                return View(galeria);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel criar sua galeria , Tente novamente, detalhe do erro:{erro.Message}!";
                return RedirectToAction("index");
            }
        }
        public IActionResult Editar(int id)
        {
            GaleriaModel galeria = _galeriaRepositorio.listarPorId(id);
            return View(galeria);
        }
        [HttpPost]
        public IActionResult Editar(GaleriaModel galeria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _galeriaRepositorio.Atualizar(galeria);
                    TempData["MensagemSucesso"] = "Galeria alterada com sucesso!";
                    return RedirectToAction("Index");// redirecionamento para página Index

                }
                return View( galeria); //forçando o nome da View para editar


            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel Alterar sua galeira, Tente novamente, detalhe do erro:{erro.Message}!";
                return RedirectToAction("Index");
            }

        }
    }
}





