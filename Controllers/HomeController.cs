using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrudApp.Models;
using CrudApp.Data;

namespace CrudApp.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> Logger { get; }
        private ApplicationDatabase Database { get; }

        public HomeController(ILogger<HomeController> logger, ApplicationDatabase db)
        {
            Logger = logger;
            Database = db;
        }

        public IActionResult Index()
        {
            ViewData["Funcionarios"] = Database.Funcionario.ToList();
            return View();
        }

        public IActionResult Novo()
        {
            ViewData["Estados"] = Database.Estado.ToList();
            return View();
        }

        public IActionResult Alterar(int key)
        {
            var funcionario = Database.Funcionario
                .Where(f => f.PK_Funcionario == key)
                .ToList()
                .DefaultIfEmpty(null)
                .SingleOrDefault();

            ViewData["Estados"] = Database.Estado.ToList();
            ViewData["Funcionario"] = funcionario;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult NovoFuncionario(string name, string email, DateTime date, decimal salary, int state)
        {
            Database.Funcionario.Add(new Funcionario
            {
                FK_Estado = state,
                Nome = name,
                Email = email,
                DataNascimento = date,
                Salario = salary,
            });

            Database.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AlterarFuncionario(int key, string name, string email, DateTime date, decimal salary, int state)
        {
            Database.Funcionario.Update(new Funcionario
            {
                PK_Funcionario = key,
                FK_Estado = state,
                Nome = name,
                Email = email,
                DataNascimento = date,
                Salario = salary,
            });

            Database.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ExcluirFuncionario(int key)
        {
            var funcionario = Database.Funcionario
                .Where(f => f.PK_Funcionario == key)
                .ToList()
                .DefaultIfEmpty(null)
                .SingleOrDefault();

            if (funcionario != null)
            {
                Database.Funcionario.Remove(funcionario);
                Database.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
