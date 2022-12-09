using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain.DTO;
using NZWalks.Repository;

namespace NZWalks.Controllers
{
    [ApiController]
    [Route("Regions")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetALlRegions()
        {
            var region = await _regionRepository.GetALlRegionsAsync();

            // Return contract model or DTO instead of domain model..

            //var regionModel = new List<RegionModel>();
            //region.ToList().ForEach(region =>
            //{
            //    var regionList = new RegionModel()
            //    {
            //        RegID = region.RegID,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population
            //    };
            //    regionModel.Add(regionList);
            //});


            var regionModel = _mapper.Map<List<RegionModel>>(region);

            return Ok(regionModel);
        }
    }
}
