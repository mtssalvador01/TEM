using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEM.Models;

namespace TecGas.Controllers
{
    public class Publico : Controller
    {

        private readonly Context _context;

        public Publico(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AcessoNegado()
        {
            return View();
        }

        public IActionResult Site()
        {
            return View();
        }

        public IActionResult Logout()
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Append("Usu_Email","", cookie);

            return RedirectToAction("Logar", "Publico");
        }

        
        public ActionResult Logar(string email, string senha)
        {
            string user = AutenticarUser(email, senha);

            if (user == "")
            {
                ViewBag.Error = "E-mail e/ou senha inválidos";
                return View();
            }
            else
            {
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddMinutes(5);
                Response.Cookies.Append("Usu_Email", user, cookie);
                return RedirectToAction("Index", "Home");
            }
        }

        public string AutenticarUser(string email, string senha)
        {
            var query = (from u in _context.Usu_Usuarios
                         where u.Usu_Email == email &&
                         u.Usu_Senha == senha
                         select u).SingleOrDefault();

            if (query == null)
            {
                return "";
            }
            else
            {
                return query.Usu_Email;

            }
        }


    }
}
