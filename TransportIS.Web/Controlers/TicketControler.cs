using Microsoft.AspNetCore.Mvc;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using AutoMapper;
using TransportIS.DAL.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/carrier/{carrierId}/connection/{connectionId}/passenger/{passengerId}/ticket")]
    [ApiController]
    public class TicketControler : ControllerBase   
    {
        private readonly IRepository<TicketEntity> repository;

        private readonly IMapper mapper;
        private readonly IRepository<StopEntity> stopRepository;
        private readonly IRepository<ConnectionEntity> connectionRepository;

        public TicketControler(IRepository<TicketEntity> repository, IMapper mapper,IRepository<StopEntity> stopRepository, IRepository<ConnectionEntity> connectionRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.stopRepository = stopRepository;
            this.connectionRepository = connectionRepository;
        }
        // GET: api/<ConnectionControler>
        [HttpGet]
        public IList<StopListModel> GetStops(Guid connectionId)
        {
            var currentConnection = connectionRepository.GetEntityById(connectionId);

            IList<StopListModel> stopListModels = new List<StopListModel>();

            foreach(var stop in currentConnection.Stops)
            {
                stopListModels.Add(mapper.Map<StopListModel>(stop));
            }

            return stopListModels;
        }

        // GET api/<ConnectionControler>/5
        [HttpGet("{id}")]
        public TicketDetailModel Get(Guid id)
        {
            var entity = repository.GetEntityById(id);
            return mapper.Map<TicketDetailModel>(entity);
        }

        // POST api/<ConnectionControler>
        [HttpPost]
        public TicketDetailModel Post([FromBody] TicketDetailModel model)
        {
            var result = repository.Insert(mapper.Map<TicketEntity>(model));
            return mapper.Map<TicketDetailModel>(result);
        }

        // PUT api/<ConnectionControler>/5
        [HttpPut("{id}")]
        public TicketDetailModel Put(Guid id, [FromBody] TicketDetailModel model)
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
