using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repository;

namespace NZWalks.Controllers
{
    [ApiController]
    [Route("WalkDifficulty")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository _difficultyRepository;
        private readonly IMapper _mapper;

        public WalkDifficultyController(IWalkDifficultyRepository difficultyRepository, IMapper mapper)
        {
            _difficultyRepository = difficultyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllWalkDifficulty()
        {
            var walkDiffi = await _difficultyRepository.GetAllWalkDifficultyAsync();
            var walkDiffModel = _mapper.Map<List<WalkDifficultyModel>>(walkDiffi);

            return Ok(walkDiffModel);
        }

        [HttpGet]
        [Route("{Id:int}")]
        [ActionName("GetWalkDifficultyById")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetWalkDifficultyById(int Id)
        {
            var walkDiff = await _difficultyRepository.GetWalkDifficultyByIdAsync(Id);

            if (walkDiff == null)
            {
                return NotFound();
            }

            var walkModel = _mapper.Map<WalkDifficultyModel>(walkDiff);
            return Ok(walkModel);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddWalkDifficulty(AddWalkDifficultyModel difficultyModel)
        {
            var walkDifficulty = new WalkDifficulty()
            {
                Code = difficultyModel.Code
            };

            walkDifficulty = await _difficultyRepository.AddWalkDifficultyAsync(walkDifficulty);

            var walkDifficultyModel = new WalkDifficultyModel()
            {
                ID = walkDifficulty.ID,
                Code = walkDifficulty.Code
            };

            return CreatedAtAction(nameof(GetWalkDifficultyById), new { Id = walkDifficultyModel.ID }, walkDifficultyModel);
        }

        [HttpPut]
        [Route("{Id:int}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateWalkDifficulty([FromRoute]int Id, [FromBody]UpdateWalkDifficultyModel difficultyModel)
        {
            var updateWalkDiffi = new WalkDifficulty()
            {
                Code = difficultyModel.Code
            };

            updateWalkDiffi = await _difficultyRepository.UpdateWalkDiffcultyAsync(Id, updateWalkDiffi);

            if (updateWalkDiffi == null)
            {
                return NotFound();
            }

            var walkDifficultyModel = new WalkDifficultyModel()
            {
                ID = updateWalkDiffi.ID,
                Code = updateWalkDiffi.Code
            };

            return Ok(walkDifficultyModel);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteWalkDifficulty(int Id)
        {
            var deleteWalkDifficulty = await _difficultyRepository.DeleteWalkDifficulty(Id);
            if (deleteWalkDifficulty == null)
            {
                return NotFound();
            }

            var walkDiffModel = new WalkDifficultyModel()
            {
                ID = deleteWalkDifficulty.ID,
                Code = deleteWalkDifficulty.Code
            };

            return Ok(walkDiffModel);
        }
    }
}
