using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniEcommerce.Entity;
using MiniEcommerce.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniEcommerce.UI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var signResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                if (signResult.Succeeded)
                {
                    return RedirectToAction("Index", "ProductAdmin");
                }
            }

            ModelState.AddModelError("", "Bilinmeyen bir hata oldu.");
            return View(model);
        }

        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Bu kullanıcı adı ile daha önce hesap oluşturulmamış");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/admin/products");
            }

            ModelState.AddModelError("", "Girilen kullanıcı adı veya parola yanlış");
            return View(model);
        }
    }
}
