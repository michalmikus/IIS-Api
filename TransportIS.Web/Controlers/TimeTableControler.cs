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
        private readonly IRepository<ConnectionEntity> connectionRepository;

        public TimeTableControler(IRepository<TimeTableEntity> repository, IMapper mapper, IRepository<ConnectionEntity> connectionRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.connectionRepository = connectionRepository;
        }
        // GET: api/<ConnectionControler>
        [HttpGet]
        public IList<TimeTableListModel> Get()
        {
            var query = repository.GetQueryable();

            var projection = mapper.ProjectTo<TimeTableListModel>(query);

            return projection.ToList();
        }

        // GET: api/<ConnectionControler>
        [HttpGet("info/{connectionId}/{intValue}")]
        public string GetURL(Guid connectionId,int value)
        {
            var connection = connectionRepository.GetQueryable().FirstOrDefault(predicate => predicate.Id == connectionId);

            var carrierId = connection.CarrierId.ToString();

            var url = "api/carrier/" + carrierId + "/connection/" + connectionId + "/passangers/"+value;

            return url;
        }

        [HttpGet("times/{connectionId}/{timeString}")]
        public IList<TimeTableListModel> GetTimes(Guid connectionId,string timeString)
        {
            var time = DateTime.Parse(timeString);
            var query = repository.GetQueryable().Where(predicate => predicate.ConnectionId == connectionId && predicate.TimeOfDeparture.TimeOfDay > time.TimeOfDay);

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
