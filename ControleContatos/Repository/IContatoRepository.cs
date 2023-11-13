using ControleContatos.Models;

namespace ControleContatos.Repository
{
    // Seguindo a ideia do Padrao Repository 
    public interface IContatoRepository
    {   
        ContatoModel buscarPorId(int id);
        List<ContatoModel> BuscarContatos();    
        ContatoModel Salvar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
