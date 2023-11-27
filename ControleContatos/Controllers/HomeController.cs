﻿using ControleContatos.Filters;
using ControleContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControleContatos.Controllers
{   
    //Filtro onde esta as verificações se o Usuario esta logado;
    [PaginaPraUsuarioLogado]
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}