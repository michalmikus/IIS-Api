using TransportIS.BL.Models.DetailModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportIS.Web.Controlers
{
    public partial class AccountControler
    {
        public class RegistrationDetail
        {
            public EmploeeDetailModel EmployeeModel { get; set; }

            public UserDetailModel UserDetail { get; set; }
        }
    }
}
