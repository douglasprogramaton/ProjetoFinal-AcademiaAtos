using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
  
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio) 
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
          List<ContatoModel>contatos= _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {

            return View();
        }
        public IActionResult Editar(int id)
        {
           ContatoModel contato= _contatoRepositorio.listarPorId(id);
            return View(contato);
        }
        public IActionResult Apagar(int id)
        {
            ContatoModel contato = _contatoRepositorio.listarPorId(id);
            return View(contato);
        }
         public IActionResult Apagarconfirmar(int id)
        {
            try
            {
                bool apagado=_contatoRepositorio.ApagarContato(id);

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

        [HttpPost]// tipo ou seja estou acinado como post que é um método de que recebe a informação e cadastra a informação
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {

                if (ModelState.IsValid)//se a validação do passa a cadastrar a informação no banco e depois redireciona para a index
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";//está é uma variavel temporaria para que possa reculperar o valor da mesma la na view
                    return RedirectToAction("Index");// redirecionamento para página Index
                }
                return View(contato);

            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel cadastrar seu contato, Tente novamente, detalhe do erro:{erro.Message}!";
                return RedirectToAction("index");
            }

        }
        [HttpPost]// tipo ou seja estou acinado como post que é um método de que recebe a informação e cadastra a informação
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");// redirecionamento para página Index

                }
                return View("Editar", contato); //forçando o nome da View para editar


            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possivel Alterar seu contato, Tente novamente, detalhe do erro:{erro.Message}!";
                return RedirectToAction("Index");
            }
          
        }

    }
}
