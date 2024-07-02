namespace JobTrack.Server.Models.Entities
{
    public class Application
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string JobTitle { get; set; }

        public string? JobDescription { get; set; }

        public string? JobLink { get; set; }
    }
}
