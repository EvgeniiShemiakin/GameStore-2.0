using Microsoft.AspNetCore.Mvc;
using GameStore_2._0.Models.Account;
using Microsoft.AspNetCore.Identity;
using GameStore_2._0.DBModels;
using Microsoft.AspNetCore.Authorization;
using GameStore_2._0.Models.Reps;
using GameStore_2._0.Models;


namespace GameStore_2._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IOrdersRepository ordersRepository;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IOrdersRepository ordersRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ordersRepository = ordersRepository;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var userVM = new UserVM
            {
                Email = user.Email,
                Phone = user.PhoneNumber,
                Discount = user.Discount,
                BuySum = user.BuySum,
                Orders = ordersRepository.GetByUserId(user.Id),
                Role = userManager.GetRolesAsync(user).Result.Contains("Admin") ? "Admin" : "User",
                Id = user.Id
            };

            return View(userVM);
        }
        public IActionResult Login(string? returnUrl = null)
        {
            return View(new Login() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Пользователь не найден.");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Неверный пароль.");
                return View(model);
            }
            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            {
                return LocalRedirect(model.ReturnUrl);
            }
            return RedirectToAction("Index", "Account");
        }
        public IActionResult Register(string? returnUrl = null)
        {
            return View(new Register() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User { Email = model.Email, UserName = model.Email, PhoneNumber = model.Phone };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return LocalRedirect(model.ReturnUrl);
                }
                return RedirectToAction("Index", "Account");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public IActionResult ChangePassword(string? userId = null)
        {
            if (User.IsInRole("Admin"))
                return View(new ChangePassword { UserId = userId });
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.UserId != null)
            {
                if (User.IsInRole("Admin"))
                {
                    var anotherUser = await userManager.FindByIdAsync(model.UserId);
                    var newHashedPasswordd = userManager.PasswordHasher.HashPassword(anotherUser, model.NewPassword);
                    anotherUser.PasswordHash = newHashedPasswordd;
                    await userManager.UpdateAsync(anotherUser);
                    return RedirectToAction("AllUsers", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Account");
                }
            }

            var user = await userManager.GetUserAsync(User);
            var newHashedPassword = userManager.PasswordHasher.HashPassword(user, model.NewPassword);
            user.PasswordHash = newHashedPassword;
            await userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Account");
        }
        [Authorize]
        public IActionResult ChangeEmail(string? userId = null)
        {
            if (User.IsInRole("Admin"))
                return View(new ChangeEmail { UserId = userId});
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangeEmail(ChangeEmail model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.UserId != null)
            {
                if (User.IsInRole("Admin"))
                {
                    var anotherUser = await userManager.FindByIdAsync(model.UserId);
                    anotherUser.Email = model.Email;
                    anotherUser.UserName = model.Email;
                    await userManager.UpdateAsync(anotherUser);
                    return RedirectToAction("AllUsers", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Account");
                }
            }
            var user = await userManager.GetUserAsync(User);
            user.Email = model.Email;
            user.UserName = model.Email;
            await userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Account");
        }
        [Authorize]
        public IActionResult ChangePhone(string? userId = null)
        {
            if (User.IsInRole("Admin"))
                return View(new ChangePhone { UserId = userId });
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePhone(ChangePhone model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.UserId != null)
            {
                if (User.IsInRole("Admin"))
                {
                    var anotherUser = await userManager.FindByIdAsync(model.UserId);
                    anotherUser.PhoneNumber = model.Phone;
                    await userManager.UpdateAsync(anotherUser);
                    return RedirectToAction("AllUsers", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Account");
                }
            }

            var user = await userManager.GetUserAsync(User);
            user.PhoneNumber = model.Phone;
            await userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Account");
        }
        [Authorize]
        public IActionResult Orders()
        {
            var userId = userManager.GetUserId(User);
            var orders = ordersRepository.GetByUserId(userId);
            return View(orders);
        }
        [Authorize]
        public IActionResult OrderInfo(Guid id)
        {
            var order = ordersRepository.GetById(id);
            return View(order);
        }

    }
}