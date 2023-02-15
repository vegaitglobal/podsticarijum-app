using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.EntityExtensions;

public static class ContentExtensions
{
    public static ContentDto ToDto(this Content content)
        => new(id: content.Id, contentType: content.ContentType, text: content.Text);
}
