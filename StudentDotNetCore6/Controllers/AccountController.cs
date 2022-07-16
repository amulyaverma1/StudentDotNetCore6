using Microsoft.AspNetCore.Mvc;
using StudentDotNetCore6.Models;
using StudentDotNetCore6.Repository;

namespace StudentDotNetCore6.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel signupModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(signupModel);

                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);

                    }
                    return View(signupModel);

                }

                ModelState.Clear();
                ViewBag.Message = String.Format("User Added Successfully!");
                return View();
            }
            return View();
        }


        //[Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        //[Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError("", "Invalid credential");
            }
            return View(signInModel);
        }


        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Login","Account");
        }

    }
}
