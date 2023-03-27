using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.DtoExtensions;
using podsticarijum_backend.Application.EntityExtensions;
using podsticarijum_backend.Domain;
using podsticarijum_backend.Domain.Entities;
using podsticarijum_backend.Repository.Abstractions;

namespace podsticarijum_backend.Api.Controllers;

[Route("api/main-screen")]
[ApiController]
public class MainController : ControllerBase
{
    private readonly IMainRepository _mainRepository;

    public MainController(IMainRepository mainRepository)
    {
        _mainRepository = mainRepository;
    }
    /// <summary>
    /// Get all or multiple content entries. Can be filtered by contentType route param.
    /// </summary>
    /// <param name="contentType">MainScreen</param>
    /// <param name="contentType">Donations</param>
    /// <param name="contentType">AboutUs</param>
    /// </remarks>
    /// <param name="contentType"></param>
    /// <returns>List<ContentDto></returns>
    [HttpGet]
    public async Task<ActionResult<List<ContentDto>>> GetMultiple([FromQuery] string? contentType)
    {
        ContentType contentTypeEnum;
        bool enumParsed = Enum.TryParse(contentType, ignoreCase: true, out contentTypeEnum);

        List<Content> contents = new();

        if (enumParsed)
        {
            contents = await _mainRepository.GetContentByType(contentTypeEnum).ConfigureAwait(false);
        }
        else
        {
            contents = await _mainRepository.GetAll().ConfigureAwait(false);
        }

        return Ok(contents.ToDto());
    }

    /// <summary>
    /// Returns main content
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>200 with MainScreenDto object</returns>
    //TODO: Fix comments - add more info
    //TODO: better error handling (Logging #1 prio)
    [HttpGet("{id}")]
    public async Task<ActionResult<ContentDto>> Get([FromRoute] long id)
    {
        Content? content = await _mainRepository.GetContentById(id).ConfigureAwait(false);
        if (content == null)
        {
            return NotFound();
        }
        return Ok(content.ToDto());
    }
}

