using ControleContatos.Models;
using ControleContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }   

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Entrar(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                 UsuarioModel usuario =  _usuarioRepository.BuscarPorLogin(model.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(model.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Senha do usuário é inválida, Por favor, tente novamente.";
                        }
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente";
                }
                return View("Index");
            }
            catch (Exception ex) {
                TempData["MensagemError"] = $"Não conseguimos realizar seu login, " +
                   $"tente novamente, detalhe do error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
