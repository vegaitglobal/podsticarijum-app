using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.DtoExtensions;

public static class MainScreenDtoExtensions
{
    public static MainScreenDto FromDomainModel(this MainScreen entity)
        => new MainScreenDto()
        {
            Id = entity.Id,
            ButtonText = entity.ButtonText,
            Content = entity.Content
        };

    public static MainScreen ToDomainModel(this MainScreenDto mainScreenDto)
        => new MainScreen(content: mainScreenDto.Content,
                          buttonText: mainScreenDto.ButtonText,
                          active: true);
        
}
