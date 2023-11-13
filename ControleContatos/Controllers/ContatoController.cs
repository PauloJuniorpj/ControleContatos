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

        public IActionResult EditarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepository.buscarPorId(id);
            return View(contato);
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepository.buscarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {   
            _contatoRepository.Apagar(id);
            return RedirectToAction("Index");
        }
        // Metodos so de leitura ou seja GET

        
        [HttpPost]
        public IActionResult Salvar(ContatoModel contato)
        {
            _contatoRepository.Salvar(contato);
            return RedirectToAction("Index");
        }
       
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            _contatoRepository.Atualizar(contato);
            return RedirectToAction("Index");
        }
    }
}
