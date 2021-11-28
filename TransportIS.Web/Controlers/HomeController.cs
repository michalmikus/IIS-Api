using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransportIS.BL.Models.DetailModels;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.DAL.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRepository<ConnectionEntity> repository;
        private readonly IMapper mapper;

        public HomeController(IRepository<ConnectionEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IList<ConnectionListModel> Get()
        {
            var query = repository.GetQueryable();

            var projection = mapper.ProjectTo<ConnectionListModel>(query);

            return projection.ToList();
        }
    }
}
