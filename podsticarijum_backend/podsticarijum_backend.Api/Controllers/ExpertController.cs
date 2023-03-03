using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers
{
    [Route("api/expert")]
    [ApiController]
    public class ExpertController : ControllerBase
    {
        private readonly IExpertRepository _expertRepository;

        public ExpertController(IExpertRepository expertRepository)
        {
            _expertRepository = expertRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpertDto>> Get([FromRoute] long id)
        {
            Expert? expert = await _expertRepository.Get(expertId: id).ConfigureAwait(false);

            if (expert == null)
            {
                return NotFound();
            }
            return Ok(expert.ToDto());
        }

        [HttpGet]
        public async Task<ActionResult<List<ExpertDto>>> GetAll()
        {
            List<Expert> experts = await _expertRepository.GetAll().ConfigureAwait(false);

            return Ok(experts.ToDto());
        }

        [HttpDelete("{expertId}")]
        public async Task<ActionResult> Delete([FromRoute] long expertId)
        {
            Expert? expert = await _expertRepository.Get(expertId).ConfigureAwait(false);
            if (expert == null)
            {
                return NotFound();
            }
            await _expertRepository.Delete(expert);

            return NoContent();
        }
    }
}
