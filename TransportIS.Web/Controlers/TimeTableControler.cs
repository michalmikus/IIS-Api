using Microsoft.AspNetCore.Mvc;
using TransportIS.DAL.Entities;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using AutoMapper;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/TimeTables")]
    [ApiController]
    public partial class TimeTableControler : ControllerBase
    {
        private readonly IRepository<TimeTableEntity> repository;
        private readonly IMapper mapper;
        private readonly IRepository<ConnectionEntity> connectionRepository;
        private readonly IRepository<StopEntity> stopRepository;

        public TimeTableControler(IRepository<TimeTableEntity> repository, IMapper mapper, IRepository<ConnectionEntity> connectionRepository, IRepository<StopEntity> stopRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.connectionRepository = connectionRepository;
            this.stopRepository = stopRepository;
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
        [HttpGet("info/{connectionId}")]
        public ResponseDetail GetURL(Guid connectionId)
        {
            var connection = connectionRepository.GetQueryable().FirstOrDefault(predicate => predicate.Id == connectionId);

            var carrierId = connection.CarrierId.ToString();

            return new ResponseDetail
            { 
                Url = "api/carrier/" + carrierId + "/connection/" + connectionId + "/passengers/" 
            };
        }

        [HttpGet("times/{connectionId}/{timeString}")]
        public IList<TimeTableListModel> GetTimes(Guid connectionId, string timeString)
        {
            var time = DateTime.Parse(timeString);
            var query = repository.GetQueryable().Where(predicate => predicate.ConnectionId == connectionId && predicate.TimeOfDeparture.TimeOfDay > time.TimeOfDay);

            var projection = mapper.ProjectTo<TimeTableListModel>(query);

            return projection.ToList();
        }

        [HttpGet("times/{connectionId}")]
        public IList<StopListModel> GetStops(Guid connectionId)
        {
            var query = repository.GetQueryable().Where(table => table.ConnectionId == connectionId).ToList();


            IList<StopListModel> stopList = new List<StopListModel>();

            foreach (var time in query)
            {
                var entity = stopRepository.GetEntityById(time.StopId);
                stopList.Add(mapper.Map<StopListModel>(entity));
            }

            return stopList;
        }

        // GET api/<ConnectionControler>/5
        [HttpGet("{id}")]
        public TimeTableDetailModel Get(Guid id)
        {
            var entity = repository.GetEntityById(id);
            return mapper.Map<TimeTableDetailModel>(entity);
        }

        // POST api/<ConnectionControler>
        [HttpPost("{connectionId}")]
        public TimeTableDetailModel Post(Guid connectionId,[FromBody] TimeTableDetailModel model)
        {
            model.ConnectionId = connectionId;
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
