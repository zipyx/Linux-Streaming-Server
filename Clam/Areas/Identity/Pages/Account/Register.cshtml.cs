using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Clam.Models;

namespace Clam.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ClamUserAccountRegister> _signInManager;
        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private readonly RoleManager<ClamRoles> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            RoleManager<ClamRoles> roleManager,
            UserManager<ClamUserAccountRegister> userManager,
            SignInManager<ClamUserAccountRegister> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            // ############################################################ Additional Added 28/03/20
            [Display(Name = "First Name")]
            [Required]
            [DataType(DataType.Text)]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            [Required]
            [DataType(DataType.Text)]
            public string LastName { get; set; }

            [Display(Name = "Gender")]
            public string Gender { get; set; }

            [Display(Name = "Date of Birth")]
            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
            public DateTime Birthday { get; set; }

            [Required]
            [Display(Name = "Username")]
            public string UserName { get; set; }

            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} digits long.", MinimumLength = 11)]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "I Agree")]
            public bool AcceptTermsAndConditions { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ClamUserAccountRegister
                {
                    UserName = Input.UserName,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    Gender = Input.Gender,
                    PhoneNumber = Input.PhoneNumber,
                    Birthday = Input.Birthday,
                    AcceptTermsAndConditions = Input.AcceptTermsAndConditions
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (!(await _roleManager.RoleExistsAsync("Owner")) && (user.UserName.Equals("zipyx")))
                {

                    // List of Roles
                    List<string> roleTitles = new List<string>()
                    {
                        "Member", "Student", "Contributor", "Moderator", "Admin", "Engineer", "Developer", "Owner"
                    };
                    List<ClaimAccountRegister> ownerClaims = new List<ClaimAccountRegister>();
                    // Roles Created
                    foreach (var item in roleTitles)
                    {
                        var role = new ClamRoles { Name = item };
                        await _roleManager.CreateAsync(role);
                    }

                    // Add All roles to Owner
                    await _userManager.AddToRolesAsync(user, roleTitles);

                    // Add User Claims
                    foreach (Claim claim in ClaimsStore.AllClaims.ToList())
                    {
                        ownerClaims.Add(new ClaimAccountRegister() { ClaimType = claim.Type, ClaimValue = claim.Value, IsSelected = true });
                        await _userManager.AddClaimAsync(user, claim);
                    }

                    // Add Role Claims
                    foreach (var role in roleTitles)
                    {
                        if (role.Equals("Owner"))
                        {
                            foreach (Claim claim in ClaimsStore.RoleClaims.ToList())
                            {
                                var foundRole = await _roleManager.FindByNameAsync(role);
                                await _roleManager.AddClaimAsync(foundRole, claim);
                            }
                            break;
                        }
                    }

                    //await _userManager.AddClaimsAsync(user, ownerClaims.Where(x => x.IsSelected).Select(y => new Claim(y.ClaimType, y.ClaimValue)));

                }
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
