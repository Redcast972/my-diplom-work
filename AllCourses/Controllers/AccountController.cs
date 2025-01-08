using AllCourses.Domain.Repositories.Abstract;
using AllCourses.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AllCourses.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserAvatarsRepository userAvatarsRepository;

        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr, RoleManager<IdentityRole> roleMgr, IUserAvatarsRepository usrAvatarsRepository)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            roleManager = roleMgr;
            userAvatarsRepository = usrAvatarsRepository;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return Redirect("/");
                    }
                    ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неправильный логин или пароль");
                }
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hasher = new PasswordHasher<IdentityUser>();
                var user = new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    NormalizedUserName = model.UserName.ToUpper(),
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, model.Password),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    
                };

                userAvatarsRepository.SaveDefaultAvatarAsync("png", Guid.Parse(user.Id));
                
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Назначаем роль пользователю
                    await userManager.AddToRoleAsync(user, "student");

                    // Перенаправляем на страницу логина после успешной регистрации
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        public IActionResult Accessdenied()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
