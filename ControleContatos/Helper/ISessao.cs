using ControleContatos.Models;

namespace ControleContatos.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel model);
        void RemoverSessaoUsuario();

        UsuarioModel BuscarSessaoDoUsuario();
    }
}
