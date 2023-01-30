using System.Text.Json.Serialization;

namespace podsticarijum_backend.Application.DTO;

public class MainScreenDto
{
    [JsonIgnore]
    public long Id { get; set; }

    public string Content { get; set; }

    public string ButtonText { get; set; }

    public bool Active { get; set; }
}
