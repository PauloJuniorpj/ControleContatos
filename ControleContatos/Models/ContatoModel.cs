using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do contato")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage ="O e-email informado não e valido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Dite o celular do contato")]
        public string Celular { get; set; }
    }
}
