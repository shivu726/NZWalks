using AutoMapper;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Profiles
{
    public class WalkDifficultyProfiles : Profile
    {
        public WalkDifficultyProfiles()
        {
            CreateMap<WalkDifficulty, WalkDifficultyModel>().ReverseMap();
        }
    }
}
