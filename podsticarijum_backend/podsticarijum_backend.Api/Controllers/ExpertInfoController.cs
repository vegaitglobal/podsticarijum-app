using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertInfoController : ControllerBase
    {
        private readonly IExpertRepository _expertRepository;

        public ExpertInfoController(IExpertRepository expertRepository)
        {
            _expertRepository = expertRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpertInfoDto>> Get([FromRoute] long id) 
        {
            ExpertInfo? expert = await _expertRepository.GetExpertInfo(expertInfoId: id).ConfigureAwait(false);

            if (expert == null)
            {
                return NotFound();
            }

            return Ok(expert.ToDto());
        }

        [HttpGet]
        public async Task<ActionResult<List<ExpertInfoDto>>> GetAll()
        {
            List<ExpertInfo> experts = await _expertRepository.GetAllExpertInfo().ConfigureAwait(false);

            return Ok(experts.ToDto());
        }
    }
}
