using Microsoft.AspNetCore.Mvc;
using TransportIS.DAL.Entities;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.BL.Models.DetailModels;
using TransportIS.BL.Repository;
using AutoMapper;
using TransportIS.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/carriers")]
    [ApiController]
    public class CarrierControler : ControllerBase
    {
        private readonly IRepository<CarrierEntity> repository;
        private readonly IMapper mapper;
        private readonly IRepository<ConnectionEntity> repositoryCon;
        private readonly IRepository<EmploeeEntity> repositoryEmp;
        private readonly IRepository<VehicleEntity> repositoryVeh;
        private readonly IRepository<TimeTableEntity> repositoryTT;

        public CarrierControler
            (
                IRepository<CarrierEntity> repository, IMapper mapper,
                IRepository<ConnectionEntity> repositoryCon, IRepository<EmploeeEntity> repositoryEmp,
                IRepository<VehicleEntity> repositoryVeh, IRepository<TimeTableEntity> repositoryTT
                
            )
        {
            this.repository = repository;
            this.mapper = mapper;
            this.repositoryCon = repositoryCon;
            this.repositoryEmp = repositoryEmp;
            this.repositoryVeh = repositoryVeh;
            this.repositoryTT = repositoryTT;
        }

        // GET: api/<ConnectionControler>
        [HttpGet("all")]
        public IList<CarrierListModel> GetAll()
        {
           var query = repository.GetQueryable();

            var projection = mapper.ProjectTo<CarrierListModel>(query);

            return projection.ToList();
        }

        // GET api/<ConnectionControler>/5
        [HttpGet("{id}")]
        public CarrierDetailModel Get(Guid id)
        {
            var entity = repository.GetEntityById(id);
            return mapper.Map<CarrierDetailModel>(entity);
        }

        // POST api/<ConnectionControler>
        [HttpPost]
        public CarrierDetailModel Post([FromBody] CarrierDetailModel model)
        {   
            var result =  repository.Insert(mapper.Map<CarrierEntity>(model));
            return mapper.Map<CarrierDetailModel>(result);
        }

        // PUT api/<ConnectionControler>/5
        [HttpPut("{id}")]
        public CarrierDetailModel Put(Guid id, [FromBody] CarrierDetailModel model)
        {
            var entity = repository.GetEntityById(id);

            if (model.CarrierName != null && model.CarrierName != "")
                entity.CarrierName = model.CarrierName;

            if (model.TaxNumber != null && model.TaxNumber != "")
                entity.TaxNumber = model.TaxNumber;

            if (model.PublicRelationsContact != null && model.PublicRelationsContact != "")
                entity.PublicRelationsContact = model.PublicRelationsContact;

            if (model.TelephoneNumber != null && model.TelephoneNumber != "")
                entity.TelephoneNumber = model.TelephoneNumber;


            if (entity != null)
            { 
                repository.Update(entity);
                repository.SaveChanges();
            }
            return model;
        }

        // DELETE api/<ConnectionControler>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var entity = repository.GetEntityById(id);


            if (entity != null)
            {
                foreach (var connection in entity.Connections)
                {
                    foreach(var timetables in connection.Stops)
                    {
                        repositoryTT.Delete(timetables.Id);
                    }
                    repositoryCon.Delete(connection.Id);

                }
                foreach (var employee in entity.Emploees)
                {
                    repositoryEmp.Delete(employee.Id);
                }
                foreach (var vehicle in entity.Vehicles)
                {
                    repositoryVeh.Delete(vehicle.Id);
                }
            }
            repository.Delete(id);
        }
    }
}
