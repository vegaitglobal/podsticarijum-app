using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Application;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.DtoExtensions;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers;

[Route("api/sub-category")]
[ApiController]
public class SubCategoryController : ControllerBase
{
    private readonly IPodsticarijumMailService _mailService;

    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly IExpertRepository _expertRepository;
    public SubCategoryController(
        IExpertRepository expertRepository,
        ISubCategoryRepository subCategoryRepository,
        IPodsticarijumMailService mailService)
    {
        _expertRepository = expertRepository ?? throw new ArgumentNullException(nameof(expertRepository));
        _subCategoryRepository = subCategoryRepository ?? throw new ArgumentNullException(nameof(subCategoryRepository));
        _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
    }

    /// <summary>
    /// Fetch active subcategories 
    /// </summary>
    /// <returns>Ok result with list of sub categories</returns>
    /// <returns>404 if no categories were found</returns>
    [HttpGet()]
    public async Task<ActionResult<SubCategory>> Get()
    {
        List<SubCategory> subCategories = await _subCategoryRepository.GetAll().ConfigureAwait(false);

        return Ok(subCategories.ToDto());
    }

    [HttpPost("{subCategoryId}/email")]
    public async Task<ActionResult> SendEmail([FromRoute] long subCategoryId, [FromBody] MailDto emailDto)
    {
        try
        {
            if (emailDto == null || emailDto.Subject == null || emailDto.Body == null)
            {
                return BadRequest("Email data is not correctly sent.");
            }
            if (!string.IsNullOrEmpty(emailDto.AppPackageName) || string.IsNullOrWhiteSpace(emailDto.AppPackageName))
            {
                _mailService.AppPackageName = emailDto.AppPackageName;
            }

            var expert = await _expertRepository.GetExpertForSubCategory(subCategoryId).ConfigureAwait(false);

            if (expert == null)
            {
                return BadRequest("Experts not found.");
            }

            await _mailService.sendEmail(ToMailAddress: expert.Email, subject: emailDto.Subject, body: emailDto.Body);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest("There was an error.");
        }
    }

    [HttpGet("{subCategoryId}/expert")]
    public async Task<ActionResult<List<Expert?>>> GetExpertBySubCategoryId([FromRoute] long subCategoryId)
    {
        Expert? expert = await _expertRepository.GetExpertForSubCategory(subCategoryId).ConfigureAwait(false);
        if (expert == null)
        {
            return NotFound();
        }

        return Ok(expert);
    }

    [HttpPost("{subCategoryId}/expert")]
    public async Task<ActionResult<ExpertDto>> CreateExpert([FromRoute] long subCategoryId, [FromBody] ExpertRequestDto expertRequestDto)
    {
        if (expertRequestDto == null || expertRequestDto.Email == null)
        {
            return BadRequest("Expert data is not sent.");
        }

        SubCategory? subCategory = await _subCategoryRepository.Get(subCategoryId, tracking: true).ConfigureAwait(false);
        if (subCategory == null)
        {
            return BadRequest("SubCategory is not correct.");
        }
        expertRequestDto.SubCategoryDto = subCategory.ToDto();
        expertRequestDto.SubCategoryDto.Id = subCategory.Id;
        var expertDto = new 
            ExpertDto(
                subCategory.ToDto(),
                firstName: expertRequestDto.FirstName,
                lastName: expertRequestDto.LastName,
                email: expertRequestDto.Email,
                description: expertRequestDto.Description);
        var expert = expertDto.ToDomainModel();
        expert.SubCategory = subCategory;

        var expertInsertedId = await _expertRepository.Insert(expert).ConfigureAwait(false);
        expertDto.Id = expertInsertedId;
        return Ok(expertDto);
    }

    [HttpDelete("{subCategoryId}")]
    public async Task<ActionResult> Delete([FromRoute] long subCategoryId)
    {
        SubCategory? subCategory = await _subCategoryRepository.Get(subCategoryId).ConfigureAwait(false);

        if (subCategory == null)
        {
            return NotFound();
        }
        await _subCategoryRepository.Delete(subCategory);

        return NoContent();
    }

    [HttpGet("{subCategoryId}/SubCategorySpecificContent")]
    public async Task<ActionResult> GetSubcategorySpecificContent(
        [FromRoute] long subCategoryId,
        [FromQuery] ParagraphSign paragraphSign = ParagraphSign.Default
        )
    {
        List<SubCategorySpecificContent> subCategorySpecificContent = await
            _subCategoryRepository.GetSubCategorySpecific(
                subCategoryId, 
                paragraphSign);

        return Ok(subCategorySpecificContent.ToDto());
    }

}
