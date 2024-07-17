using EpiShipment.Models.Dto;
using EpiShipment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EpiShipment.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _userSvc;
        private readonly AuthService _authSvc;
        public AuthController(UserService userSvc, AuthService authSvc)
        {
            _userSvc = userSvc;
            _authSvc = authSvc;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username, Password")] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                return View();
            }

            var user = _userSvc.GetUser(model);
            if (user == null)
            {
                TempData["Error"] = "Utente non trovato";
                return View();
            }
            _authSvc.Login(user);
            TempData["Success"] = "Login effettuato con successo";
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            _authSvc.Logout();
            TempData["Success"] = "Logout effettuato con successo";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Username, Password")] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                return View();
            }

            var user = _userSvc.AddUser(model);
            if (user == null)
            {
                TempData["Error"] = "Errore nella registrazione";
                return View();
            }
            TempData["Success"] = "Registrazione effettuata con successo";
            return RedirectToAction("Index", "Home");
        }
    }
}
