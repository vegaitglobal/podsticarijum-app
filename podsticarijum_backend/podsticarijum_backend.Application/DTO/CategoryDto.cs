namespace podsticarijum_backend.Application.DTO;

public class CategoryDto
{
    public CategoryDto(long id, string navMenuText, string description)
    {
        Id = id;
        NavMenuText = navMenuText;
        Description = description;
    }

    public long Id { get; set; }

    public string NavMenuText { get; set; }

    public string Description { get; set; }
}
