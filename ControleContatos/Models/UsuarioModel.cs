using ControleContatos.Enums;

namespace ControleContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Login {  get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public PerfilEnum perfil { get; set; }
    }
}
