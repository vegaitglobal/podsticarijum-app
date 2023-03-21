namespace podsticarijum_backend.Domain.Entities;

public class SubCategorySpecificContent : EntityTimestamps
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public SubCategorySpecificContent()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    public SubCategorySpecificContent(
        SubCategory subCategory,
        string paragraphText,
        ParagraphSign paragraphSign)
    {
        SubCategory = subCategory ?? throw new ArgumentNullException(nameof(subCategory));
        ParagraphText = paragraphText ?? throw new ArgumentNullException(nameof(paragraphText));
        ParagraphSign = paragraphSign;
    }

    public long Id { get; set; }

    public SubCategory SubCategory { get; set; }

    public string ParagraphText { get; set; }

    public ParagraphSign ParagraphSign { get; set; }
}
