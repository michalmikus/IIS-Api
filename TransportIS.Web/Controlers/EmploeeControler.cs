using Microsoft.AspNetCore.Mvc;
using TransportIS.DAL.Entities;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using TransportIS.DAL.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin,Carrier,Emploee")]
    [Route("api/carrier/employees")]
    [ApiController]
    public class EmploeeControler : ControllerBase
    {

        public class Composite
        {
            public EmploeeDetailModel EmployeeModel { get; set; }

            public UserDetailModel UserDetail { get; set; }
        }

        private readonly IRepository<EmploeeEntity> repository;
        private readonly IMapper mapper;
        private readonly UserManager<UserEntity> userManager;
        private readonly RoleManager<RoleEntity> roleManager;
        private readonly IAuthenticationService service;

        public EmploeeControler
            (
                IRepository<EmploeeEntity> repository,
                IMapper mapper,
                UserManager<UserEntity> userManager,
                RoleManager<RoleEntity> roleManager,
                IAuthenticationService service
            )
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.service = service;
        }
        // GET: api/<ConnectionControler>

        [Authorize(Roles = "Admin,Carrier")]
        [HttpGet("all")]
        public IList<EmploeeListModel> GetAll()
        {
            var carrierId = new Guid(userManager.GetUserId(Request.HttpContext.User));

            var query = repository.GetQueryable().Where(predicate => predicate.CarrierId == carrierId);

            var projection = mapper.ProjectTo<EmploeeListModel>(query);

            return projection.ToList();
        }

        // GET api/<ConnectionControler>/5
        [HttpGet("{id}")]
        public EmploeeDetailModel Get(Guid id)
        {
            var entity = repository.GetEntityById(id);
            return mapper.Map<EmploeeDetailModel>(entity);
        }

        // POST api/<ConnectionControler>
        [HttpPost]
        public async Task<EmploeeDetailModel>  Post([FromBody] Composite composite)
        {
            EmploeeDetailModel employeeModel = composite.EmployeeModel;
            UserDetailModel userModel = composite.UserDetail;

            var carrierId = new Guid(userManager.GetUserId(Request.HttpContext.User));
            employeeModel.carrierId = carrierId;

            userModel.Id = employeeModel.Id;
            userModel.Email = employeeModel?.Email;

            await CreateAccAsync(userModel);

            var result = repository.Insert(mapper.Map<EmploeeEntity>(employeeModel));
            return mapper.Map<EmploeeDetailModel>(result);
        }

        public async Task CreateAccAsync(UserDetailModel model)
        {
            var user = new UserEntity
            {
                Id = model.Id,
                Email = model.Email,
                UserName = model.Name,
                SecurityStamp = model.Id.ToString()


            };

            await roleManager.CreateAsync(new RoleEntity { Name = nameof(AppRoles.Emploee) });

            await userManager.CreateAsync(user, model.Password);

            await userManager.AddToRoleAsync(user, nameof(AppRoles.Emploee));
        }

        // PUT api/<ConnectionControler>/5
        [HttpPut("{id}")]
        public EmploeeDetailModel Put(Guid id, [FromBody] EmploeeDetailModel model)
        {
            var entity = repository.GetEntityById(id);
            mapper.Map(model, entity);

            if (entity != null)
                repository.Update(entity);


            return model;
        }

        [HttpPut]
        public EmploeeDetailModel Update([FromBody] EmploeeDetailModel model)
        {
            var id = new Guid(userManager.GetUserId(Request.HttpContext.User));
            
            var entity = repository.GetQueryable().FirstOrDefault(predicate => predicate.Id == id);

            model.Id = id;
            model.Email = entity.Email;

            mapper.Map(model, entity);

            if (entity != null)
                repository.Update(entity);

            return model;
        }

        // DELETE api/<ConnectionControler>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            repository.Delete(id);
        }
    }
}
