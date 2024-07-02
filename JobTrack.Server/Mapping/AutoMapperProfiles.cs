using AutoMapper;
using JobTrack.Server.Models.DTO;
using JobTrack.Server.Models.Entities;

namespace JobTrack.Server.Mapping
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationDto, Application>().ReverseMap();
            CreateMap<EditApplicationDto, Application>().ReverseMap();
        }
    }
}
