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
    [Route("api/carrier/{carrierId}/employees")]
    [ApiController]
    public class EmploeeControler : ControllerBase
    {


        private readonly IRepository<EmploeeEntity> repository;
        private readonly IRepository<TicketEntity> ticketRepository;
        private readonly IMapper mapper;
        private readonly UserManager<UserEntity> userManager;
        private readonly RoleManager<RoleEntity> roleManager;

        public EmploeeControler
            (
                IRepository<EmploeeEntity> repository,
                IRepository<TicketEntity> ticketRepository,
                IMapper mapper,
                UserManager<UserEntity> userManager,
                RoleManager<RoleEntity> roleManager
            )
        {
            this.repository = repository;
            this.ticketRepository = ticketRepository;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        // GET: api/<ConnectionControler>
        [HttpGet("all")]
        public IList<EmploeeListModel> GetAll(Guid carrierId)
        {
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


        [HttpPost("register-employee")]
        public async Task<IActionResult> RegisterEmploeeAsync(Guid carrierId, [FromBody] EmployeeRegistrationDetail registrationDetail)
        {
            var modelId = Guid.NewGuid();

            var user = new UserEntity
            {
                Email = registrationDetail.UserDetail.Email,
                UserName = registrationDetail.UserDetail.Name,
                SecurityStamp = Guid.NewGuid().ToString(),
                EmployeeId = modelId
            };

            await roleManager.CreateAsync(new RoleEntity { Name = nameof(AppRoles.Emploee) });

            var result = await userManager.CreateAsync(user, registrationDetail.UserDetail.Password);

            await userManager.AddToRoleAsync(user, nameof(AppRoles.Emploee));

            var userEntity = userManager.Users.FirstOrDefault(email => email.Email == registrationDetail.UserDetail.Email);

            var enomploeeModel = new EmploeeDetailModel
            {
                Id = modelId,
                Email = userEntity.Email,
                Role = registrationDetail.EmployeeModel.Role,
                CarrierId = carrierId,
                Address = registrationDetail.EmployeeModel.Address,
                UserId = userEntity.Id,
                FullName = registrationDetail.EmployeeModel.FullName
            };


            if (result.Succeeded)
            {
                repository.Insert(mapper.Map<EmploeeEntity>(enomploeeModel));

                return Content((HttpContext.Response.StatusCode = 200).ToString());
            }
            else
            {
                return Content((HttpContext.Response.StatusCode = 406).ToString());
            }
        }

        // PUT api/<ConnectionControler>/5
        [HttpPut("{id}")]
        public EmploeeDetailModel Put(Guid id, [FromBody] EmploeeDetailModel model)
        {
            var entity = repository.GetEntityById(id);   

            mapper.Map(model, entity);

            if (entity != null)
            {
                repository.Update(entity);
                repository.SaveChanges();
            }

            return model;
        }

        [HttpPut("{employeeId}/ticket/{id}")]
        public TicketDetailModel Put(Guid employeeId,Guid id, [FromBody] TicketDetailModel model)
        {
            var ticket = ticketRepository.GetEntityById(id);
            
            if (ticket != null)
            {
                ticket.ConfirmingEmploeeId = employeeId;
                ticketRepository.Update(ticket);
                ticketRepository.SaveChanges();

            }
            return mapper.Map<TicketDetailModel>(ticket);
        }

        [HttpPut]
        public EmploeeDetailModel Update([FromBody] EmploeeDetailModel model)
        {
            var id = new Guid(userManager.GetUserId(Request.HttpContext.User));
            
            var entity = repository.GetQueryable().FirstOrDefault(predicate => predicate.Id == id);

            model.Id = id;

            mapper.Map(model, entity);

            if (entity != null)
                repository.Update(entity);

            return model;
        }

        // DELETE api/<ConnectionControler>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var userEntity = userManager.Users.FirstOrDefault(predicate => predicate.EmployeeId == id);
           
            if (userEntity != null)
            {
                userManager.DeleteAsync(userEntity);
            }
            repository.Delete(id);
        }
    }
}
