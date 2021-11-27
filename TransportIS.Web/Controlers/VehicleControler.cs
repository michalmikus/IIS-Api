using Microsoft.AspNetCore.Mvc;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using AutoMapper;
using TransportIS.BL.Models.ListModels;
using TransportIS.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin,Carrier")]
    [Route("api/carrier/{carrierId}/vehicles")]
    [ApiController]
    public class VehicleControler : ControllerBase
    {
        private readonly IRepository<VehicleEntity> repository;
        private readonly IMapper mapper;

        public VehicleControler(IRepository<VehicleEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IList<VehicleListModel> GetAll(Guid carrierId)
        {
            var query = repository.GetQueryable().Where(predicate => predicate.CarrierId == carrierId);

            var projection = mapper.ProjectTo<VehicleListModel>(query);

            return projection.ToList();
        }

        // GET: api/<ConnectionControler>
        [HttpGet]
        public IList<VehicleListModel> Get(Guid carrierId)
        {
            var query = repository.GetQueryable().Where(predicate => predicate.CarrierId == carrierId);

            var projection = mapper.ProjectTo<VehicleListModel>(query);

            return projection.ToList();
        }

        // GET api/<ConnectionControler>/5
        [HttpGet("{id}")]
        public VehicleDetailModel GetById(Guid id)
        {
            var entity = repository.GetEntityById(id);
            return mapper.Map<VehicleDetailModel>(entity);
        }

        // POST api/<ConnectionControler>
        [HttpPost]
        public VehicleDetailModel Post(Guid carrierId,[FromBody] VehicleDetailModel model)
        {
            model.CarrierId = carrierId;
            var result = repository.Insert(mapper.Map<VehicleEntity>(model));
            return mapper.Map<VehicleDetailModel>(result);
        }

        // PUT api/<ConnectionControler>/5
        [HttpPut("{id}")]
        public VehicleDetailModel Put(Guid id, [FromBody] VehicleDetailModel model)
        {
            var entity = repository.GetEntityById(id);
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
