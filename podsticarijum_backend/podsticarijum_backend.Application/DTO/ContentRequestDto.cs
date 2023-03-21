﻿using System.Text.Json.Serialization;
using podsticarijum_backend.Domain;

namespace podsticarijum_backend.Application.DTO;

public class ContentRequestDto
{
    public ContentRequestDto(string contentType, string text)
    {
        ContentType = contentType;
        Text = text;
    }

    [JsonIgnore]
    public long Id { get; init; }

    public string ContentType { get; init; }

    public string Text { get; set; }
}
