using System.Linq;
using Microsoft.AspNetCore.Mvc;
using firstapp.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstapp.Controllers
{
    public class UserController : Controller
    {
		private UniContext context;
		public UserController(UniContext context)
		{
			this.context = context;
		}
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(this.context.Usuarios.ToList());
        }
    }
}
