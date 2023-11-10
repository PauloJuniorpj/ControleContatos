using ControleContatos.Models;

namespace ControleContatos.Repository
{
    // Seguindo a ideia do Padrao Repository 
    public interface IContatoRepository
    {   
        List<ContatoModel> BuscarContatos();    
        ContatoModel Salvar(ContatoModel contato);
    }
}
