using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace podsticarijum_backend.Domain.Entities;

public class Content : EntityTimestamps
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Content()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    public Content(ContentType contentType, string text)
    {
        ContentType = contentType;
        Text = text;
    }

    public long Id { get; set; }

    public ContentType ContentType { get; init; }

    public string Text { get; set; }
}
