using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repository;

namespace NZWalks.Controllers
{
    [ApiController]
    [Route("Walks")]
    public class WalksController : Controller
    {
        private readonly IWalksRepository _walksRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalksRepository walksRepository, IMapper mapper)
        {
            _walksRepository = walksRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walkData = await _walksRepository.GetAllWalksAsync();

            var walkModel = _mapper.Map<List<WalkModel>>(walkData);

            return Ok(walkModel);
        }

        [HttpGet]
        [Route("{Id:int}")]
        [ActionName("GetWalkByIdAsync")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetWalkByIdAsync(int Id)
        {
            var walkData = await _walksRepository.GetWalkByIdAsync(Id);

            if (walkData == null)
            {
                NotFound();
            }

            var walkModel = _mapper.Map<WalkModel>(walkData);

            return Ok(walkModel);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddWalkAsyc(AddWalkModel walkModel)
        {
            var walkData = new Walk()
            {
                Name = walkModel.Name,
                Length = walkModel.Length,
                RegionID = walkModel.RegionID,
                WalkDifficultyID = walkModel.WalkDifficultyID

            };

            walkData = await _walksRepository.AddWalkAsync(walkData);

            var walkModelData = new WalkModel()
            {
                WalkID = walkData.WalkID,
                Name = walkData.Name,
                Length = walkData.Length,
                RegionID = walkData.RegionID,
                WalkDifficultyID = walkData.WalkDifficultyID
            };

            return CreatedAtAction(nameof(GetWalkByIdAsync), new { Id = walkModelData.WalkID }, walkModelData);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteWalks(int Id)
        {
            var walkData = await _walksRepository.DeleteWalkAsync(Id);

            if (walkData == null)
            {
                return NotFound();
            }

            var walkModel = new WalkModel()
            {
                WalkID = walkData.WalkID,
                Name = walkData.Name,
                Length = walkData.Length
            };

            return Ok(walkModel);
        }

        [HttpPut]
        [Route("{Id:int}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateWalksAsync([FromRoute] int Id, [FromBody]UpdateWalkModel updateWalk)
        {
            var walkData = new Walk()
            {
                Name = updateWalk.Name,
                Length = updateWalk.Length,
                RegionID = updateWalk.RegionID,
                WalkDifficultyID = updateWalk.WalkDifficultyID
            };

            walkData = await _walksRepository.UpdateWalkAsync(Id, walkData);

            if (walkData == null)
            {
                return NotFound();
            }

            var walkModel = new WalkModel()
            {
                WalkID = walkData.WalkID,
                Name = walkData.Name,
                Length = walkData.Length,
                RegionID = walkData.RegionID,
                WalkDifficultyID = walkData.WalkDifficultyID
            };

            return Ok(walkModel);
        }
    }
}
