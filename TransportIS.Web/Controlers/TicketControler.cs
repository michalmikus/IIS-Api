using Microsoft.AspNetCore.Mvc;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using AutoMapper;
using TransportIS.DAL.Entities;
using TransportIS.DAL.Enums;

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
        private readonly IRepository<TicketEntity> ticketRepository;

        public TicketControler
            (
                IRepository<TicketEntity> repository, IMapper mapper,
                IRepository<StopEntity> stopRepository,
                IRepository<ConnectionEntity> connectionRepository,
                IRepository<TicketEntity> ticketRepository
            )
        {
            this.repository = repository;
            this.mapper = mapper;
            this.stopRepository = stopRepository;
            this.connectionRepository = connectionRepository;
            this.ticketRepository = ticketRepository;
        }
        // GET: api/<ConnectionControler>
        [HttpGet]
        public IList<StopListModel> GetStops(Guid connectionId)
        {
            var currentConnection = connectionRepository.GetEntityById(connectionId);

            IList<StopListModel> stopListModels = new List<StopListModel>();

            foreach (var stop in currentConnection.Stops)
            {
                stopListModels.Add(mapper.Map<StopListModel>(stop));
            }

            return stopListModels;
        }

        [HttpGet("all")]
        public IList<TicketListModel> GetAllTickets(Guid passengerId)
        {
            var tickets = ticketRepository.GetQueryable().Where(ticket => ticket.PassengerId == passengerId);

            var projection = mapper.ProjectTo<TicketListModel>(tickets);

            return projection.ToList();
        }

        [HttpGet("allForCarrier")]
        public IList<TicketListModel> GetAllTickets(Guid passengerId, Guid carrierId)
        {
            var tickets = ticketRepository.GetQueryable().Where(ticket => ticket.CarrierId == carrierId);

            var projection = mapper.ProjectTo<TicketListModel>(tickets);

            return projection.ToList();
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
        public TicketDetailModel Post(Guid passengerId, Guid carrierId,[FromBody] TicketDetailModel model)
        {
            var boardingStop = stopRepository.GetEntityById(model.BoardingStopId);
            var destinationStop = stopRepository.GetEntityById(model.DestinationStopId);

            model.PassengerId = passengerId;
            model.BoardingStopName = boardingStop.Name;
            model.DestinationStopName = destinationStop.Name;
            model.CarrierId = carrierId;
             
            var entity = mapper.Map<TicketEntity>(model);
            var result = repository.Insert(entity);
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
