using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repository
{
    //Service
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsuarioModel Salvar(UsuarioModel usuario)
        {   
            //Rn envolvendo a data de cadastro
            usuario.DataCadastro = DateTime.UtcNow;
            _bancoContext.Usuarios.Add(usuario);
            // parte que comita as informaçoes
            _bancoContext.SaveChanges();
            return usuario;
        }


        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = buscarPorId(usuario.Id);
            if (usuario == null)
            {
                throw new System.Exception("Houve um erro na atualização do usuário!");
            }
            usuarioDb.Name = usuario.Name;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Senha = usuario.Senha;
            usuarioDb.Email = usuario.Email;
            //RN envolvendo a atualização de cadastro do usuario
            usuarioDb.DataAtualizacao = DateTime.UtcNow;

            _bancoContext.Usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();

            return usuarioDb;
        }

        public List<UsuarioModel> BuscarContatos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel buscarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

       

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = buscarPorId(id);
            if (usuarioDb == null)
            {
                throw new System.Exception("Houve um erro na exlusao do usuário");
            }

            _bancoContext.Usuarios.Remove(usuarioDb);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
