using ControleContatos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace ControleContatos.Filters
{   
    //Logia onde a gente valida se o Usuario esta logado(Filtro)
    public class PaginaPraUsuarioLogado : ActionFilterAttribute
    {
        public override  void OnActionExecuting(ActionExecutingContext context)
        {
            var sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller","Login"}, { "action", "Index"} });
            }
            else
            {
                var usuario = JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);
                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
            }
            base.OnActionExecuting(context);
        }
        
        
    }
}
