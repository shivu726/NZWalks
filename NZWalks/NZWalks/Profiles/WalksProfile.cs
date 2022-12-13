using AutoMapper;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Walk, WalkModel>().ReverseMap();

            CreateMap<WalkDifficulty, WalkDifficultyModel>().ReverseMap();
        }
    }
}
