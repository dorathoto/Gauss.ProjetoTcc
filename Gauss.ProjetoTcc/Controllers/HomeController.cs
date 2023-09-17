using Gauss.ProjetoTcc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gauss.ProjetoTcc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Usuario> _userManager;
        public RT.Comb.ICombProvider _comb;

        public HomeController(ILogger<HomeController> logger, UserManager<Usuario> userManager, RT.Comb.ICombProvider comb)
        {
            _logger = logger;
            _userManager = userManager;
            _comb = comb;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddUser()
        {
            var usuario = new Usuario
            {
                Id = _comb.Create(),
                UserName = "gauss@gauss.com.br",
                NomeCompleto = "gauss projeto TCC",
                Email = "gauss@gauss.com.br",
                EmailConfirmed = true,
            };
            var add = await _userManager.CreateAsync(usuario, "Gauss@2023");
            return Content("Add usuario com sucesso");
        }

    }
}