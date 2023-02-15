using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using podsticarijum_backend.Domain;

namespace podsticarijum_backend.Application.DTO;

public class ContentDto
{
    public ContentDto(long id, ContentType contentType, string text)
    {
        Id = id;
        ContentType = contentType;
        Text = text;
    }

    public long Id { get; set; }

    public ContentType ContentType { get; init; }

    public string Text { get; set; }
}
