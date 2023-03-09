namespace podsticarijum_backend.Application.DTO;

public class CategoryFullDto
{
    public CategoryFullDto(long id, string navMenuText, string description)
    {
        Id = id;
        NavMenuText = navMenuText;
        Description = description;
    }

    public long Id { get; set; }

    public string NavMenuText { get; set; }

    public string Description { get; set; }

    public List<SubCategoryDto> SubCategories { get; set; } = new();
}

