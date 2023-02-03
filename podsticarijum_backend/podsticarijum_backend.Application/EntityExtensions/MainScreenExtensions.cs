using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.EntityExtensions;

public static class MainScreenExtensions
{
    public static MainScreenDto ToDto(this MainScreen entity)
        => new MainScreenDto(content: entity.Content,
                             buttonText: entity.ButtonText,
                             active: entity.Active);
}
