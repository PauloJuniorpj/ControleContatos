using ControleContatos.Data;
using ControleContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleContatos.Repository
{   
    //Service
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepository(BancoContext bancoContext) { 
            _bancoContext = bancoContext;
        }

        public bool Apagar(int id)
        {   
            ContatoModel contatodb = buscarPorId(id);
            if (contatodb == null)
            {
                throw new System.Exception("Houve um erro na exlusao do contato");
            }

            _bancoContext.Contatos.Remove(contatodb);
            _bancoContext.SaveChanges();

            return true;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatodb = buscarPorId(contato.Id);
            if(contato == null)
            {
                throw new System.Exception("Houve um erro na atualização do contato!");
            }
            contatodb.Name = contato.Name;
            contatodb.Celular = contato.Celular;
            contatodb.Email = contato.Email;

            _bancoContext.Contatos.Update(contatodb);
            _bancoContext.SaveChanges();

            return contatodb;
        }

        public List<ContatoModel> BuscarContatos()
        {
           return _bancoContext.Contatos.ToList();
        }

        public ContatoModel buscarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
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
