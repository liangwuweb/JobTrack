using System.ComponentModel.DataAnnotations;

namespace JobTrack.Server.Models.DTO
{
    public class ApplicationDto
    {
        public Guid Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string JobTitle { get; set; }

        public string? JobDescription { get; set; }

        public string? JobLink { get; set; }
    }
}
