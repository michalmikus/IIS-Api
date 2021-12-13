using Microsoft.AspNetCore.Mvc;
using TransportIS.DAL.Entities;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using TransportIS.BL.Repository;
using AutoMapper;
using TransportIS.DAL;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/carrier/{carrierId}/connection")]
    [ApiController]
    public class ConnectionControler : ControllerBase
    {
        private readonly IRepository<ConnectionEntity> repository;
        private readonly IMapper mapper;

        public ConnectionControler(IRepository<ConnectionEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        // GET: api/<ConnectionControler>
        [HttpGet("all")]
        public IList<ConnectionListModel> GetAll(Guid carrierId)
        {
            var query = repository.GetQueryable().Where(predicate => predicate.CarrierId == carrierId) ;

            var projection = mapper.ProjectTo<ConnectionListModel>(query);

            return projection.ToList();
        }
        

        // GET api/<ConnectionControler>/5
        [HttpGet("{id}")]
        public ConnectionDetialModel Get(Guid id)
        {
            var entity = repository.GetEntityById(id);
            return mapper.Map<ConnectionDetialModel>(entity);
        }

        // POST api/<ConnectionControler>
        [HttpPost]
        public ConnectionDetialModel Post(Guid carrierId,[FromBody] ConnectionDetialModel model)
        {
            model.CarrierId = carrierId;
            var result =  repository.Insert(mapper.Map<ConnectionEntity>(model));
            return mapper.Map<ConnectionDetialModel>(result);
        }

        // PUT api/<ConnectionControler>/5
        [HttpPut("{id}")]
        public ConnectionDetialModel Put(Guid id, [FromBody] ConnectionDetialModel model)
        {
            var entity = repository.GetEntityById(id);

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
            var entity = repository.GetEntityById(id);
    


            repository.Delete(id);
        }
    }
}
