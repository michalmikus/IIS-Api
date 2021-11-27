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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin,Emploee")]
    [Route("api/carrier/employees")]
    [ApiController]
    public class EmploeeControler : ControllerBase
    {
        private readonly IRepository<EmploeeEntity> repository;
        private readonly IMapper mapper;
        private readonly UserManager<UserEntity> userManager;
        private readonly IAuthenticationService service;

        public EmploeeControler(IRepository<EmploeeEntity> repository, IMapper mapper, UserManager<UserEntity> userManager, IAuthenticationService service)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userManager = userManager;
            this.service = service;
        }
        // GET: api/<ConnectionControler>
        [HttpGet]
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

        // POST api/<ConnectionControler>
        [HttpPost]
        public EmploeeDetailModel Post(Guid carrierId,[FromBody] EmploeeDetailModel model)
        {         
            var result = repository.Insert(mapper.Map<EmploeeEntity>(model));
            return mapper.Map<EmploeeDetailModel>(result);
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
