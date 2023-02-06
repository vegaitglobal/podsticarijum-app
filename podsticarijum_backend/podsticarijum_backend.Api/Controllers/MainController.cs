using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Application.DtoExtensions;
using podsticarijum_backend.Application.EntityExtensions;
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
    /// Returns main content
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>200 with MainScreenDto object</returns>
    //TODO: Fix comments - add more info
    //TODO: better error handling (Logging #1 prio)
    [HttpGet("{id}")]
    public async Task<ActionResult<MainScreenDto>> Get([FromRoute] long id)
    {
        MainScreen? mainScreen = await _mainRepository.Get(id).ConfigureAwait(false);
        if (mainScreen == null)
        {
            return NotFound();
        }
        return Ok(mainScreen.ToDto());
    }


    //TODO: Proper validation of each field from the input Dto
    [HttpPost]
    public async Task<ActionResult<MainScreenDto>> Create([FromBody] MainScreenDto mainScreenDto)
    {
        if (mainScreenDtoInvalid(mainScreenDto))
        {
            return BadRequest();
        }

        MainScreen entity = mainScreenDto.ToDomainModel();

        try
        {
            List<MainScreen> activeMainScreens = await _mainRepository.GetActive().ConfigureAwait(false);
            if (activeMainScreens.Count != 0)
            {
                activeMainScreens.ForEach(ams => ams.Active = false);
                await _mainRepository.Update(activeMainScreens);
            }

            var insertedObjectId = await _mainRepository.Insert(entity).ConfigureAwait(false);
            mainScreenDto.Id = insertedObjectId;
            return Ok(mainScreenDto);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mainScreenDto"></param>
    /// <returns>204 if object is successfully updated.</returns>
    /// <returns>404 if no object to update.</returns>
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] MainScreenDto mainScreenDto)
    {
        MainScreen? mainScreen = await _mainRepository.Get(mainScreenDto.Id);
        if (mainScreen == null)
        {
            return NotFound();
        }
        try
        {
            await _mainRepository.Update(mainScreenDto.ToDomainModel());
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    private static bool mainScreenDtoInvalid(MainScreenDto mainScreenDto)
        => mainScreenDto == null || mainScreenDto.ButtonText == null || mainScreenDto.Content == null;

}

