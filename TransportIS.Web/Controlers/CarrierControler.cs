using Microsoft.AspNetCore.Mvc;
using TransportIS.DAL.Entities;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using TransportIS.BL.Repository;
using AutoMapper;
using TransportIS.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/carriers")]
    [ApiController]
    public class CarrierControler : ControllerBase
    {
        private readonly IRepository<CarrierEntity> repository;
        private readonly IMapper mapper;
        private Guid CurrentCarrierId { get; set; }

        public CarrierControler(IRepository<CarrierEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // GET: api/<ConnectionControler>
        [Authorize(Roles ="Admin")]
        [HttpGet("all")]
        public IList<CarrierListModel> GetAll()
        {
           var query = repository.GetQueryable();

            var projection = mapper.ProjectTo<CarrierListModel>(query);

            return projection.ToList();
        }

        // GET api/<ConnectionControler>/5
        [HttpGet]
        public CarrierDetailModel Get()
        {
            var entity = repository.GetEntityById(CurrentCarrierId);
            return mapper.Map<CarrierDetailModel>(entity);
        }

        // POST api/<ConnectionControler>
        [HttpPost]
        public CarrierDetailModel Post([FromBody] CarrierDetailModel model)
        {   
            var result =  repository.Insert(mapper.Map<CarrierEntity>(model));
            CurrentCarrierId = model.Id;
            RedirectToPage("/api/carriers/{modelId}");
            return mapper.Map<CarrierDetailModel>(result);
        }

        // PUT api/<ConnectionControler>/5
        [HttpPut("{id}")]
        public CarrierDetailModel Put(Guid id, [FromBody] CarrierDetailModel model)
        {
            var entity = repository.GetEntityById(id);

            model.Id = id;

            mapper.Map(model, entity );
            
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
