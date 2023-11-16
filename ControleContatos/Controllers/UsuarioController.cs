using ControleContatos.Models;
using ControleContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        //Views da tela (vizualizaçoes)
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepository.BuscarContatos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {

            return View();
        }

        public IActionResult EditarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepository.buscarPorId(id);
            return View(usuario);
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepository.buscarPorId(id);
            return View(usuario);
        }

        //Views da tela (vizualizaçoes)

        //Implemetaçoes dos methodos do CRUD ex:Salvar
        [HttpPost]
        public IActionResult Salvar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Salvar(usuario);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Criar", usuario);

            }
            catch (Exception ex)
            {
                TempData["MensagemError"] = $"Não conseguimos cadastrar seu contato, " +
                    $"tente novamente ou verifique os erros, detalhe do error: {ex.Message}";
                return RedirectToAction("Index");
            }


        }
        [HttpPost]
        public IActionResult Alterar(UsuarioModel  usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("EditarConfirmacao", usuario);

            }
            catch (Exception ex)
            {
                TempData["MensagemError"] = $"Não conseguimos alterar seu contato, " +
                    $"tente novamente ou verifique os erros, detalhe do error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {

            //Ultilizando Mensagens 
            try
            {
                bool apagado = _usuarioRepository.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else { TempData["MensagemError"] = "Não foi possivel apagar seu contato! verifique os erros"; }

                return RedirectToAction("Index");

            }

            catch (Exception ex)
            {
                TempData["MensagemError"] = $"Não conseguimos apagar seu contato, " +
                    $"tente novamente ou verifique os erros, detalhe do error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
