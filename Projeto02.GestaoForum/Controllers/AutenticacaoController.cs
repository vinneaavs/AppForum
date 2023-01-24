using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto02.GestaoForum.Models;
using System.Collections.Specialized;

namespace Projeto02.GestaoForum.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public AutenticacaoController(UserManager<IdentityUser> userManager,
                                      SignInManager<IdentityUser> signInManager,
                                      RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            var roles = roleManager.Roles.ToList();
            var listRoles = roles.Select(r => r.Name).ToList();
            ViewBag.Roles = new SelectList(listRoles);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                // criando o usuário
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                // incluir o usuário
                var result = await userManager.CreateAsync(user, model.Senha);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.Perfil))
                    {
                        var appRole = await roleManager.FindByNameAsync(model.Perfil);
                        if (appRole != null)
                        {
                            await userManager.AddToRoleAsync(user, model.Perfil);
                        }
                    }
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string? ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogonViewModel model, string? ReturnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Senha,
                    isPersistent: model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    //return RedirectToAction("Index", "Home");
                    return ReturnUrl == null ? Redirect("/Home/Index") : Redirect(ReturnUrl);
                }
                ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            var erro = "Sem permissão necessária !";
            return View("_Erro", new Exception(erro));
        }
    }
}
