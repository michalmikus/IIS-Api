using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using TransportIS.BL.Models.DetailModels;
using TransportIS.DAL.Entities;
using TransportIS.DAL.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/account")]
    [ApiController]
    public class AccountControler : ControllerBase
    {
        private readonly UserManager<UserEntity> userManager;
        private readonly IAuthenticationService service;
        private readonly RoleManager<RoleEntity> userRoleManager;

        public AccountControler(UserManager<UserEntity> userManager, IAuthenticationService service, RoleManager<RoleEntity> userRoleManager)
        {
            this.userManager = userManager;
            this.service = service;
            this.userRoleManager = userRoleManager;
        }

        //httpcontext obsahuje user identety a ta ma claimy

        [HttpPost("sign-in")]
        public async Task SignInAsync([FromBody] CredentialsDetailModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return;
            }


            if (await userManager.CheckPasswordAsync(user, model.Password))
            {
                var roles = await GetClaimsAsync(user);

                await service.SignInAsync(
                    HttpContext,
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(new ClaimsIdentity(roles, CookieAuthenticationDefaults.AuthenticationScheme)),
                    new AuthenticationProperties()
                );
            }
            else
            {
                HttpContext.Response.StatusCode = 401;
            }
            
        }

        public async Task<IList<Claim>> GetClaimsAsync(UserEntity user)
        {
            var role = await userManager.GetRolesAsync(user);

            if (role.FirstOrDefault() == null)
                throw new Exception("Cannot login, user has no role ");

            return new List<Claim> {
                new Claim(ClaimTypes.Email, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, role.FirstOrDefault()),
            };
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserDetailModel model)
        {
            var user = new UserEntity
            {
                Id = model.Id,
                Email = model.Email,
                UserName = model.Name,
                SecurityStamp = model.Id.ToString()
            };

            await userRoleManager.CreateAsync(new RoleEntity { Name = nameof(AppRoles.User)});

            var userId = model.Id;

            var result = await userManager.CreateAsync(user, model.Password);
            
            await userManager.AddToRoleAsync(user, nameof(AppRoles.User));
            

            if (result.Succeeded)
            {
                return RedirectToPage("/api/user/{userId}");
            }
            else
            {
                return Content((HttpContext.Response.StatusCode=406).ToString());
            }
        }

        [HttpPost("register-carrier")]
        public async Task<IActionResult> RegisterCarrierAsync([FromBody] UserDetailModel model)
        {
            var user = new UserEntity
            {
                Id = model.Id,
                Email = model.Email,
                UserName = model.Name,
                SecurityStamp = model.Id.ToString()

            };

            await userRoleManager.CreateAsync(new RoleEntity { Name = nameof(AppRoles.Carrier) });

            var carrierId = model.Id;

            var result = await userManager.CreateAsync(user, model.Password);

            await userManager.AddToRoleAsync(user, nameof(AppRoles.Carrier));


            if (result.Succeeded)
            {
                return RedirectToPage("/api/carriers");
            }
            else
            {
                return Content((HttpContext.Response.StatusCode = 406).ToString());
            }
        }


        [HttpPost("register-emploee")]
        public async Task<IActionResult> RegisterEmploeeAsync([FromBody] UserDetailModel model)
        {
            var user = new UserEntity
            {
                Id = model.Id,
                Email = model.Email,
                UserName = model.Name,
                SecurityStamp = model.Id.ToString()


            };

            await userRoleManager.CreateAsync(new RoleEntity { Name = nameof(AppRoles.Emploee) });

            var userId = model.Id;

            var result = await userManager.CreateAsync(user, model.Password);

            await userManager.AddToRoleAsync(user, nameof(AppRoles.Emploee));


            if (result.Succeeded)
            {
                return RedirectToPage("/api/user/{userId}");
            }
            else
            {
                return Content((HttpContext.Response.StatusCode = 406).ToString());
            }
        }
    }
}
