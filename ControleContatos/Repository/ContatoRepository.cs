using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repository
{   
    //Service
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepository(BancoContext bancoContext) { 
            _bancoContext = bancoContext;
        }

        public List<ContatoModel> BuscarContatos()
        {
           return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Salvar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            // parte que comita as informaçoes
            _bancoContext.SaveChanges();
            return contato;
        }
    }
}
