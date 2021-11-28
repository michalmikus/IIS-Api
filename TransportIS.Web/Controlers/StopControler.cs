using Microsoft.AspNetCore.Mvc;
using TransportIS.DAL.Entities;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/carrier/{carrierId}/connection/{connectionID}/stops")]
    [ApiController]
    public class StopControler : ControllerBase
    {
        private readonly IRepository<StopEntity> repository;
        private readonly IMapper mapper;

        public StopControler(IRepository<StopEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        // GET: api/<ConnectionControler>
        [HttpGet]
        public IList<StopListModel> Get()
        {
            var query = repository.GetQueryable();

            var projection = mapper.ProjectTo<StopListModel>(query);

            return projection.ToList();
        }

        // GET api/<ConnectionControler>/5
        [HttpGet("{id}")]
        public StopDetailModel Get(Guid id)
        {
            var entity = repository.GetEntityById(id);
            return mapper.Map<StopDetailModel>(entity);
        }

        // POST api/<ConnectionControler>
        [HttpPost]
        public StopDetailModel Post(Guid connectionId, [FromBody] StopDetailModel model)
        {
            model.ConnectionId = connectionId;
            var result = repository.Insert(mapper.Map<StopEntity>(model));
            return mapper.Map<StopDetailModel>(result);
        }

        // PUT api/<ConnectionControler>/5
        [HttpPut("{id}")]
        public StopDetailModel Put(Guid id, [FromBody] StopDetailModel model)
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
            repository.Delete(id);
        }
    }
}
