namespace TransportIS.BL.Models.DetailModels
{
    public class UserDetailModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
