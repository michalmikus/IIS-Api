using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TransportIS.BL.Models.DetailModels;
using TransportIS.DAL.Entities;

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
                    new ClaimsPrincipal(new ClaimsIdentity(roles)),
                    new AuthenticationProperties()
                );
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
    }
}
