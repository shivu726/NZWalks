using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
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
        [Authorize(Roles ="reader")]
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

        [HttpGet]
        [Route("{Id:int}")]
        [ActionName("GetRegionById")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetRegionById(int Id)
        {
            var region = await _regionRepository.GetRegionAsync(Id);


            if (region == null)
            {
                return NotFound();
            }

            var regionModel = _mapper.Map<RegionModel>(region);

            return Ok(regionModel);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddRegionAsync(AddRegionModel addRegion)
        {
            // Request (DTO) to domain model...

            var region = new Region()
            {
                Code = addRegion.Code,
                Area = addRegion.Area,
                Name = addRegion.Name,
                Lat = addRegion.Lat,
                Long = addRegion.Long,
                Population = addRegion.Population
            };

            // Pass details to repository...
            region = await _regionRepository.AddRegionAsync(region);

            // conver back to DTO..

            var regionModel = new RegionModel()
            {
                RegID = region.RegID,
                Code = region.Code,
                Area = region.Area,
                Name = region.Name,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population
            };

            return CreatedAtAction(nameof(GetRegionById), new { Id = regionModel.RegID }, regionModel);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteRegionAsync(int Id)
        {
            var region = await _regionRepository.DeleteRegionAsync(Id);

            if (region == null)
            {
                return NotFound();
            }

            var regionModel = new RegionModel()
            {
                RegID = region.RegID,
                Code = region.Code,
                Area = region.Area,
                Name = region.Name,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population
            };

            return Ok(regionModel);
        }

        [HttpPut]
        [Route("{Id:int}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] int Id, [FromBody]UpdateRegionModel updateModel)
        {
            // Convert DTO to Domain model

            var region = new Region()
            {
                Code = updateModel.Code,
                Area = updateModel.Area,
                Name = updateModel.Name,
                Lat = updateModel.Lat,
                Long = updateModel.Long,
                Population = updateModel.Population
            };

            // Update to repository..
            region = await _regionRepository.UpdateRegionAsync(Id, region);

            // Null check..
            if (region == null)
            {
                return NotFound();
            }

            // Convert Domain to DTO..

            var updateRegModel = new RegionModel()
            {
                RegID = region.RegID,
                Code = region.Code,
                Area = region.Area,
                Name = region.Name,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population
            };

            // return OK...
            return Ok(updateRegModel);
        }
    }
}
