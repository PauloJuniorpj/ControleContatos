using ControleContatos.Models;

namespace ControleContatos.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel buscarPorId(int id);
        List<UsuarioModel> BuscarContatos();
        UsuarioModel Salvar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);
    }
}
