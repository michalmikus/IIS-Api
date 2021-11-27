using TransportIS.BL.Models.DetailModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.BL.Models.DetailModels
{

    public class EmployeeRegistrationDetail
    {
        public EmploeeDetailModel EmployeeModel { get; set; }

        public UserDetailModel UserDetail { get; set; }
    }
}
