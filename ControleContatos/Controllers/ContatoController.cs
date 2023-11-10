using ControleContatos.Models;
using ControleContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        //Construtor
        public ContatoController(IContatoRepository contatoRepository) {
            _contatoRepository = contatoRepository;
        }


        //gets methodos so de leitura
        public IActionResult Index()
        {   List<ContatoModel> contatos = _contatoRepository.BuscarContatos();
            return View(contatos);
        }

        public IActionResult Criar()
        {

        return View();
        }

        public IActionResult Editar()
        {
               return View();
        }

        public IActionResult Deletar()
        {
            return View();
        }
        // Metodos so de leitura ou seja GET

        //Posts
        [HttpPost]
        public IActionResult Salvar(ContatoModel contato)
        {
            _contatoRepository.Salvar(contato);
            return RedirectToAction("Index");
        }
    }
}
