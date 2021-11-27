namespace TransportIS.BL.Models.DetailModels
{
    public class UserDetailModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public Guid? EmployeeId { get; set; }

        public Guid? PassengerId { get; set; }
    }
}
