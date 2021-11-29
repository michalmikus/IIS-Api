using Microsoft.AspNetCore.Mvc;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using AutoMapper;
using TransportIS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using TransportIS.DAL.Enums;
using static TransportIS.Web.Controlers.TimeTableControler;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/carrier/{carrierId}/connection/{connectionId}/passengers")]
    [ApiController]
    public class PassengerControler : ControllerBase
    {
        private readonly IRepository<PassengerEntity> repository;
        private readonly IMapper mapper;
        private readonly UserManager<UserEntity> userManager;
        private readonly RoleManager<RoleEntity> roleManager;

        public PassengerControler(IRepository<PassengerEntity> repository, IMapper mapper, UserManager<UserEntity> userManager,
                RoleManager<RoleEntity> roleManager)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        // GET: api/<ConnectionControler>
        [HttpGet("all")]
        public IList<PassengerListModel> Get()
        {
            var query = repository.GetQueryable();

            var projection = mapper.ProjectTo<PassengerListModel>(query);

            return projection.ToList();
        }

        [HttpPost("register-passenger")]
        public async Task<IdentityDetail?> RegisterPassengerAsync(Guid carrierId,Guid connectionId, [FromBody] PassengerRegistrationDetail registrationDetail)
        {
            var modelId = Guid.NewGuid();
            var user = new UserEntity
            {
                Email = registrationDetail.UserDetail.Email,
                UserName = registrationDetail.UserDetail.Name,
                SecurityStamp = Guid.NewGuid().ToString(),
                PassangerId = modelId
                
            };

            await roleManager.CreateAsync(new RoleEntity { Name = nameof(AppRoles.Passenger) });

            var result = await userManager.CreateAsync(user, registrationDetail.UserDetail.Password);

            if (!result.Succeeded)
            {
                HttpContext.Response.StatusCode = 406;
            }

            await userManager.AddToRoleAsync(user, nameof(AppRoles.Passenger));

            var userEntity = userManager.Users.FirstOrDefault(email => email.Email == registrationDetail.UserDetail.Email);

            var passengerModel = new PassengerDetailModel
            {
                Id = modelId,
                Email = userEntity.Email,
                Address = registrationDetail.PassengerModel.Address,
                UserId = userEntity.Id,
                ConnectionId = connectionId,
                PhoneNumber = registrationDetail.PassengerModel.PhoneNumber
            };


            if (result.Succeeded)
            {
                repository.Insert(mapper.Map<PassengerEntity>(passengerModel));

                return new IdentityDetail
                {
                    UserId = userEntity.Id,
                    UserType = nameof(AppRoles.Passenger)
                } ;
            }
            else
            {
                HttpContext.Response.StatusCode = 406;
                return null;
            }
        }

        // GET api/<ConnectionControler>/5
        [HttpGet("{id}")]
        public PassengerDetailModel Get(Guid id)
        {
            var entity = repository.GetEntityById(id);
            return mapper.Map<PassengerDetailModel>(entity);
        }

        // POST api/<ConnectionControler>
        [HttpPost]
        public PassengerDetailModel Post(Guid connectionId,[FromBody] PassengerDetailModel model)
        {
            model.ConnectionId = connectionId;
            var result = repository.Insert(mapper.Map<PassengerEntity>(model));
            return mapper.Map<PassengerDetailModel>(result);
        }

        // PUT api/<ConnectionControler>/5
        [HttpPut("{id}")]
        public PassengerDetailModel Put(Guid id, [FromBody] PassengerDetailModel model)
        {
            var entity = repository.GetEntityById(id);
            mapper.Map(model, entity);

            if (entity != null)
                repository.Update(entity);
            repository.SaveChanges();

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
