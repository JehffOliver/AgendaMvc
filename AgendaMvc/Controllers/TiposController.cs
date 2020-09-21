using System;
using System.Collections.Generic;
using AgendaMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMvc.Controllers
{
    public class TiposController : Controller
    {
        public IActionResult Index()
        {
            List<TipoContato> list = new List<TipoContato>();

            list.Add(new TipoContato {Id = 1, Name = "Amigos" });
            list.Add(new TipoContato {Id = 2, Name = "Trabalho" });
            list.Add(new TipoContato {Id = 3, Name = "Casa" });
            list.Add(new TipoContato {Id = 4, Name = "Outro" });

            return View(list);
        }
    }
}
