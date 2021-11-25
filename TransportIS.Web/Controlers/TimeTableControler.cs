using Microsoft.AspNetCore.Mvc;
using TransportIS.DAL.Entities;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/TimeTables")]
    [ApiController]
    public class TimeTableControler : ControllerBase
    {
        private readonly IRepository<TimeTableEntity> repository;
        private readonly IMapper mapper;

        public TimeTableControler(IRepository<TimeTableEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        // GET: api/<ConnectionControler>
        [HttpGet]
        public IList<TimeTableListModel> Get()
        {
            var query = repository.GetQueryable();

            var projection = mapper.ProjectTo<TimeTableListModel>(query);

            return projection.ToList();
        }

        [HttpGet("times/{id}")]
        public IList<TimeTableListModel> GetTimes(Guid id)
        {
            var query = repository.GetQueryable().Where(predicate => predicate.Connection.Id == id);

            var projection = mapper.ProjectTo<TimeTableListModel>(query);

            return projection.ToList();
        }

        // GET api/<ConnectionControler>/5
        [HttpGet("{id}")]
        public TimeTableDetailModel Get(Guid id)
        {
            var entity = repository.GetEntityById(id);
            return mapper.Map<TimeTableDetailModel>(entity);
        }

        // POST api/<ConnectionControler>
        [HttpPost]
        public TimeTableDetailModel Post([FromBody] TimeTableDetailModel model)
        {
            var result = repository.Insert(mapper.Map<TimeTableEntity>(model));
            return mapper.Map<TimeTableDetailModel>(result);
        }

        // PUT api/<ConnectionControler>/5
        [HttpPut("{id}")]
        public TimeTableDetailModel Put(Guid id, [FromBody] TimeTableDetailModel model)
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
