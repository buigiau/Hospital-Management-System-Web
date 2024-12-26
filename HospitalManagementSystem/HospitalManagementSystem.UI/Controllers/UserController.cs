using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Core.DTO;
using Microsoft.AspNetCore.Identity;
using HospitalManagementSystem.Core.Domain.IndentityEntities;
using HospitalManagementSystem.Core.Enums;
using HospitalManagementSystem.UI.Areas.Admin.Controllers;

namespace HospitalManagementSystem.UI.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<ApplicationRole> _roleManager;
		public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(LoginDTO loginDTO, string? ReturnUrl)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);
				return View(loginDTO);
			}

			var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);

			if (result.Succeeded)
			{
				ApplicationUser user = await _userManager.FindByEmailAsync(loginDTO.Email);
				if (user != null)
				{
					// Check user roles and redirect accordingly
					if (await _userManager.IsInRoleAsync(user, UserTypeOptions.Admin.ToString()))
					{
						return RedirectToAction("Index", "Home", new { area = "Admin" });
					}
					else if (await _userManager.IsInRoleAsync(user, UserTypeOptions.Doctor.ToString()))
					{
						return RedirectToAction("Index", "Home", new { area = "Doctor" });
					}
					else if (await _userManager.IsInRoleAsync(user, UserTypeOptions.Patient.ToString()))
					{
						var id = user.Id;
						return RedirectToAction("Index", "Home", new { area = "Patient", id });
					}
				}

				// Redirect to the original URL if provided and valid
				if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
				{
					return LocalRedirect(ReturnUrl);
				}

				// Default redirection
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}

			ModelState.AddModelError("Login", "Incorrect account or password!");
			ViewBag.Errors = "Incorrect account or password!";
			return View(loginDTO);
		}

		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return Redirect("/User/Login");
		}

	}
}
