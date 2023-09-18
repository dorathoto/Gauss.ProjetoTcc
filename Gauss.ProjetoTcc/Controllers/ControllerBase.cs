using Gauss.ProjetoTcc.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Gauss.ProjetoTcc.Controllers
{
    [Authorize]
    public class ControllerBase : Controller
    {
        public readonly ApplicationDbContext _context;
        public RT.Comb.ICombProvider _comb;
        public Guid UserGuid { get; set; }

        public ControllerBase(ApplicationDbContext context, RT.Comb.ICombProvider comb)
        {
            _comb = comb;
            _context = context;

        }

        /// <summary>
        /// podemos pensar em deixar o userId do usuario logado diponível geral pra todos.
        /// </summary>
        /// <param name="context"></param>
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    var userid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    UserGuid = _comb.Create(Guid.Parse(userid), DateTime.UtcNow);
        //}
    }
}
