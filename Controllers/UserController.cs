using System.Linq;
using Microsoft.AspNetCore.Mvc;
using firstapp.Data;
using firstapp.Models;
using Microsoft.Extensions.Logging;
using firstapp.Tools;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstapp.Controllers
{
    public class UserController : Controller
    {
		private UniContext context;
        private ILoggerFactory _Factory;

		public UserController(UniContext context, ILoggerFactory factory)
		{
            this._Factory = factory;
			this.context = context;
		}
        // GET: /<controller>/
        public IActionResult Index()
        {
            var logger = _Factory.CreateLogger("User");
            logger.LogWarning("LogWarning");    
            return View(this.context.Usuarios.ToList());
        }
        public IActionResult New()
        {
            return View();
        }

        [ActionName("Delete")]
        public IActionResult Delete(int? id){
            var logger = _Factory.CreateLogger("User");
            logger.LogWarning("Usuario " + id + " casi borrado");
            if (id == null)
                return NotFound();
            
            User usuario = context.Usuarios.Single(m => m.IDUser == id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        //POST: User/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id){
            User usuario = context.Usuarios.SingleOrDefault(m => m.IDUser == id);
            var logger = _Factory.CreateLogger("User");
            
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
            logger.LogWarning("Usuario " + usuario.IDUser + " borrado.");

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(User usuario){
            var logger = _Factory.CreateLogger("User");
            Hashing thing = new Hashing();


            if(ModelState.IsValid){
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                logger.LogWarning("Usuario " + usuario.IDUser + " creado.");
                logger.LogWarning("Salt for Password: " + thing.GetSalt());
                string aux = thing.Hash(usuario.Password, thing.GetSalt()).ToString();
                logger.LogWarning("Hash of Password: " + aux);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }
    }
}
