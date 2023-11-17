﻿using ControleContatos.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ControleContatos.Helper
{
    public class SessaoUsuario : ISessao
    {   
        private readonly IHttpContextAccessor _contextAccessor;

        public SessaoUsuario(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }

            return JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioModel model)
        {
            string valor = JsonSerializer.Serialize(model);

            _contextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
