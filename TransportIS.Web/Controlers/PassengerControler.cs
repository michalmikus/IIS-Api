using Microsoft.AspNetCore.Mvc;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using AutoMapper;
using TransportIS.DAL.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/carrier/{carrierId}/connections/{connectionId}/Passengers")]
    [ApiController]
    public class PassengerControler : ControllerBase
    {
        private readonly IRepository<PassengerEntity> repository;
        private readonly IMapper mapper;

        public PassengerControler(IRepository<PassengerEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        // GET: api/<ConnectionControler>
        [HttpGet]
        public IList<PassengerListModel> Get()
        {
            var query = repository.GetQueryable();

            var projection = mapper.ProjectTo<PassengerListModel>(query);

            return projection.ToList();
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
        public PassengerDetailModel Post([FromBody] PassengerDetailModel model)
        {
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
