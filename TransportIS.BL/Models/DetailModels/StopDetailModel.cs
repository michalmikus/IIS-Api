namespace TransportIS.BL.Models.DetailModels
{
    public class StopDetailModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Location { get; set; }

        public Guid CarrierId { get; set; }

        public Guid ResponsibleEmploeeId  { get; set; }

    }
}
