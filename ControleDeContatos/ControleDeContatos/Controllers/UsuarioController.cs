

using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;


namespace ControleDeContatos.Controllers
{

    [SomenteAdmin]
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
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario=_usuarioRepositorio.listarPorId(id);
            return View(usuario);
        }
        public IActionResult Apagar(int id)
        {
           UsuarioModel usuario = _usuarioRepositorio.listarPorId(id);
            return View(usuario);
        }
        public IActionResult Apagarconfirmar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.ApagarContato(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Não foi possivel apagar seu usuário, Tente novamente";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel apagar seu usuario, Tente novamente, detalhe do erro:{erro.Message}!";
                return RedirectToAction("Index");
            }


        }
        [HttpPost]// tipo ou seja estou acinado como post que é um método de que recebe a informação e cadastra a informação
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {

                if (ModelState.IsValid)//se a validação do passa a cadastrar a informação no banco e depois redireciona para a index
                {
                    usuario =_usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";//está é uma variavel temporaria para que possa reculperar o valor da mesma la na view
                    return RedirectToAction("Index");// redirecionamento para página Index
                }
                return View(usuario);

            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel criar seu usuario, Tente novamente, detalhe do erro:{erro.Message}!";
                return RedirectToAction("index");
            }

        }
        [HttpPost]// tipo ou seja estou acinado como post que é um método de que recebe a informação e cadastra a informação
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel() 
                    {
                    Id=usuarioSemSenhaModel.Id,
                    Name=usuarioSemSenhaModel.Name,
                    Login=usuarioSemSenhaModel.Login,
                    Email=usuarioSemSenhaModel.Email,
                    Perfil=usuarioSemSenhaModel.Perfil

                    };

                    usuario =  _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");// redirecionamento para página Index

                }
                return View( usuario); //forçando o nome da View para editar


            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel Alterar seu Usuário, Tente novamente, detalhe do erro:{erro.Message}!";
                return RedirectToAction("Index");
            }

        }


    }
}
