using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using TransportIS.BL.Models.DetailModels;
using TransportIS.BL.Repository;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.DAL.Entities;
using TransportIS.DAL.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/account")]
    [ApiController]
    public partial class AccountControler : ControllerBase
    {
        private readonly UserManager<UserEntity> userManager;
        private readonly IAuthenticationService service;
        private readonly RoleManager<RoleEntity> userRoleManager;
        private readonly IRepository<EmploeeEntity> emploeeRepository;
        private readonly IMapper mapper;

        public AccountControler
            (
                UserManager<UserEntity> userManager,
                IAuthenticationService service,
                RoleManager<RoleEntity> userRoleManager,
                IRepository<EmploeeEntity> emploeeRepository,
                IMapper mapper
            )
        {
            this.userManager = userManager;
            this.service = service;
            this.userRoleManager = userRoleManager;
            this.emploeeRepository = emploeeRepository;
            this.mapper = mapper;
        }

        //httpcontext obsahuje user identety a ta ma claimy

        [HttpPost("sign-in")]
        public async Task<IdentityDetail?> SignInAsync([FromBody] CredentialsDetailModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return null;
            }
            var result = await userManager.CheckPasswordAsync(user, model.Password);

            if (result)
            {
                var roles = await GetClaimsAsync(user);

                await service.SignInAsync(
                    HttpContext,
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(new ClaimsIdentity(roles, CookieAuthenticationDefaults.AuthenticationScheme)),
                    new AuthenticationProperties()
                );

                if (await userManager.IsInRoleAsync(user,nameof(AppRoles.Emploee)))
                {
                    return new IdentityDetail
                    {
                        UserId = user.EmployeeId,
                        UserType = nameof(AppRoles.Emploee)
                    };
                }
                if (await userManager.IsInRoleAsync(user, nameof(AppRoles.Passenger)))
                {
                    return new IdentityDetail
                    {
                        UserId = user.PassangerId,
                        UserType = nameof(AppRoles.Passenger)
                    };
                }
                return null;
            }
            else
            {
                Content("405");
                return null;
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

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserDetailModel model)
        {
    
            var user = new UserEntity
            {
                Id = model.Id,
                Email = model.Email,
                UserName = model.Name,
                SecurityStamp = model.Id.ToString()
            };

            await userRoleManager.CreateAsync(new RoleEntity { Name = nameof(AppRoles.Admin)});

            var userId = model.Id;

            var result = await userManager.CreateAsync(user, model.Password);
            
            await userManager.AddToRoleAsync(user, nameof(AppRoles.Admin));
            


            if (result.Succeeded)
            {
                return Content((HttpContext.Response.StatusCode = 200).ToString()); ;
            }
            else
            {
                return Content((HttpContext.Response.StatusCode=406).ToString());
            }
        }


        [HttpPost("sign-out")]
        public async Task<IActionResult> Logout()
        {
            await service.SignOutAsync(HttpContext,
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new AuthenticationProperties()
                   );
            return Content((HttpContext.Response.StatusCode = 200).ToString()); ;
        }
    }
}
