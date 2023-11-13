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
            
            try
            {
                bool apagado = _contatoRepository.Apagar(id);
                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else { TempData["MensagemError"] = "Não foi possivel apagar seu contato! verifique os erros"; }

                return RedirectToAction("Index");

            }

            catch (Exception ex) {
                TempData["MensagemError"] = $"Não conseguimos apagar seu contato, " +
                    $"tente novamente ou verifique os erros, detalhe do error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        // Metodos so de leitura ou seja GET

        
        [HttpPost]
        public IActionResult Salvar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Salvar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Criar", contato);

            }
            catch(Exception ex) {
                TempData["MensagemError"] = $"Não conseguimos cadastrar seu contato, " +
                    $"tente novamente ou verifique os erros, detalhe do error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
       
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("EditarConfirmacao", contato);

            }
            catch (Exception ex)
            {
                TempData["MensagemError"] = $"Não conseguimos alterar seu contato, " +
                    $"tente novamente ou verifique os erros, detalhe do error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
