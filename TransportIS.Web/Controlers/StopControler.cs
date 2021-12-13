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

        private readonly IRepository<TimeTableEntity> timeTableRepository;

        public StopControler(IRepository<StopEntity> repository, IMapper mapper, IRepository<TimeTableEntity> timeTableRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.timeTableRepository = timeTableRepository;
        }
        // GET: api/<ConnectionControler>
        [HttpGet]
        public IList<StopListModel> Get()
        {
            var query = repository.GetQueryable();

            var projection = mapper.ProjectTo<StopListModel>(query);

            return projection.ToList();
        }

        [HttpGet("forConnection")]
        public IList<StopListModel> GetConnectionStops(Guid connectionId)
        {
            var stops = timeTableRepository.GetQueryable().Where(table => table.ConnectionId == connectionId);

            IList<StopListModel> stopList = new List<StopListModel>();

            foreach(var stop in stops)
            {
                var stopID = stop.StopId.ToString();
                

                if (stopID != null)
                {
                    var stopInConnection = repository.GetEntityById(Guid.Parse(stopID));

                    if (stopInConnection != null)
                    {
                        stopList.Add(mapper.Map<StopListModel>(stopInConnection));
                    }
                }
            }
            return stopList;
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
        public StopDetailModel Post(Guid carrierId, [FromBody] StopDetailModel model)
        {
            model.CarrierId = carrierId;
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
            var timetables = timeTableRepository.GetQueryable().Where(table => table.StopId == id);

            var list = timetables.ToList();
            if (list != null)
            {
                foreach(var timetable in list)
                {
                    timeTableRepository.Delete(timetable.Id);
                }
            }
            repository.Delete(id);
        }
    }
}
