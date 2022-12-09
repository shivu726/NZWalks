using AutoMapper;
using NZWalks.Models.Domain;
using NZWalks.Models.Domain.DTO;

namespace NZWalks.Profiles
{
    public class RegionProfile: Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionModel>().ReverseMap();

            // .ForMember(dest => dest.RegID, options => options.MapFrom(src => src.Id));    // when field name is different between each class for Ex; Id and RegID..
        }
    }
}
