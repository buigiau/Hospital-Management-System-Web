using HospitalManagementSystem.Core.Domain.IndentityEntities;
using HospitalManagementSystem.Core.DTO;
using HospitalManagementSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalManagementSystem.UI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	/*[Authorize(Roles = "Admin")]*/
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<ApplicationRole> _roleManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterDTO registerDTO)
		{
			if (ModelState.IsValid == false)
			{
				ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);
				return View(registerDTO);
			}

			ApplicationUser user = new ApplicationUser() { Email = registerDTO.Email, PhoneNumber = registerDTO.Phone, UserName = registerDTO.Email, PersonName = registerDTO.PersonName };

			IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);
			if (result.Succeeded)
			{
				//Check status of radio button
				if (registerDTO.UserType == Core.Enums.UserTypeOptions.Admin)
				{
					//Create 'Admin' role
					if (await _roleManager.FindByNameAsync(UserTypeOptions.Admin.ToString()) is null)
					{
						ApplicationRole applicationRole = new ApplicationRole() { Name = UserTypeOptions.Admin.ToString() };
						await _roleManager.CreateAsync(applicationRole);
					}

					//Add the new user into 'Admin' role
					await _userManager.AddToRoleAsync(user, UserTypeOptions.Admin.ToString());
				}
				else if (registerDTO.UserType == Core.Enums.UserTypeOptions.Doctor)
				{
					//Create 'Doctor' role
					if (await _roleManager.FindByNameAsync(UserTypeOptions.Doctor.ToString()) is null)
					{
						ApplicationRole applicationRole = new ApplicationRole() { Name = UserTypeOptions.Doctor.ToString() };
						await _roleManager.CreateAsync(applicationRole);
					}

					//Add the new user into 'Doctor' role
					await _userManager.AddToRoleAsync(user, UserTypeOptions.Doctor.ToString());
				}
				else
				{
					//Create 'Patient' role
					if (await _roleManager.FindByNameAsync(UserTypeOptions.Patient.ToString()) is null)
					{
						ApplicationRole applicationRole = new ApplicationRole() { Name = UserTypeOptions.Patient.ToString() };
						await _roleManager.CreateAsync(applicationRole);
					}

					//Add the new user into 'Patient' role
					await _userManager.AddToRoleAsync(user, UserTypeOptions.Patient.ToString());
				}

				// Thêm claim cho AccountID
				// Add Claim for AccountID
				var accountId = user.Id; // Lấy ID của người dùng
				await _userManager.AddClaimAsync(user, new Claim("AccountID", accountId.ToString())); // Chuyển đổi thành string
																									  //Sign in
				await _signInManager.SignInAsync(user, isPersistent: false);

				/*return RedirectToAction(nameof(HomeController.Index), "Home");*/
				return RedirectToAction("Login", "User", new { area = "" });
			}
			else
			{
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("Register", error.Description);
				}

				return View(registerDTO);
			}
		}
	} 
}
