using Microsoft.AspNetCore.Mvc;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using AutoMapper;
using TransportIS.DAL.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/carrier/{carrierId}/connection/{connectionId}/passenger/{passengerId}/{reservedSeats}/ticket")]
    [ApiController]
    public class TicketControler : ControllerBase   
    {
        private readonly IRepository<TicketEntity> repository;
        private readonly IMapper mapper;

        public TicketControler(IRepository<TicketEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        // GET: api/<ConnectionControler>
        [HttpGet]
        public IList<TicketListModel> Get()
        {
            var query = repository.GetQueryable();

            var projection = mapper.ProjectTo<TicketListModel>(query);

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
