using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {

            return View();
        }
        [HttpPost]// tipo ou seja estou acinado como post que é um método de que recebe a informação e cadastra a informação
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {

                if (ModelState.IsValid)//se a validação do passa a cadastrar a informação no banco e depois redireciona para a index
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";//está é uma variavel temporaria para que possa reculperar o valor da mesma la na view
                    return RedirectToAction("Index");// redirecionamento para página Index
                }
                return View(usuario);

            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel usuario seu contato, Tente novamente, detalhe do erro:{erro.Message}!";
                return RedirectToAction("index");
            }

        }
        
    }
}
