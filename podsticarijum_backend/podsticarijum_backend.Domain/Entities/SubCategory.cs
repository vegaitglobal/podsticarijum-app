namespace podsticarijum_backend.Domain.Entities;

public class SubCategory : EntityTimestamps
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected SubCategory()
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    public SubCategory(
        Category category,
        string mainNavMenuText,
        string mainText,
        string additionalText,
        string checkMoreButtonText,
        string checkMorePageTitle,
        string checkMorePageText,
        string developmentSupportingActivitiesButtonText,
        string atypicalDevelopmentSignsText,
        string greenActivityPageTitle,
        string redActivityPageTitle,
        bool active)
    {
        Category = category ?? throw new ArgumentNullException(nameof(category));
        MainNavMenuText = mainNavMenuText ?? throw new ArgumentNullException(nameof(mainNavMenuText));
        MainText = mainText ?? throw new ArgumentNullException(nameof(mainText));
        AdditionalText = additionalText ?? throw new ArgumentNullException(nameof(additionalText));
        CheckMoreButtonText = checkMoreButtonText ?? throw new ArgumentNullException(nameof(checkMoreButtonText));
        CheckMorePageTitle = checkMorePageTitle ?? throw new ArgumentNullException(nameof(checkMorePageTitle));
        CheckMorePageText = checkMorePageText ?? throw new ArgumentNullException(nameof(checkMorePageText));
        DevelopmentSupportingActivitiesButtonText = developmentSupportingActivitiesButtonText ??
                                                    throw new ArgumentNullException(nameof(developmentSupportingActivitiesButtonText));
        AtypicalDevelopmentSignsText = atypicalDevelopmentSignsText ?? throw new ArgumentNullException(nameof(atypicalDevelopmentSignsText));
        RedActivityPageTitle = redActivityPageTitle ?? throw new ArgumentNullException(redActivityPageTitle);
        GreenActivityPageTitle = greenActivityPageTitle ?? throw new ArgumentNullException(greenActivityPageTitle);
        Active = active;
    }

    public long Id { get; set; }

    /// <summary>
    /// Related category object to this subcategory
    /// </summary>
    public Category Category { get; set; }

    /// <summary>
    /// Text in the main nav menu button/label
    /// </summary>
    public string MainNavMenuText { get; set; }

    /// <summary>
    /// Text sitting at the top of main page
    /// </summary>
    public string MainText { get; set; }

    /// <summary>
    /// Text sitting at the bottom of main page
    /// </summary>
    public string AdditionalText { get; set; }

    /// <summary>
    /// "More" button text
    /// </summary>
    public string CheckMoreButtonText { get; set; }

    /// <summary>
    /// Text for the page where we can see detailed information 
    /// and select to check more about development 
    /// and signs of deviation
    /// </summary>
    public string CheckMorePageTitle { get; set; }

    /// <summary>
    /// Text for the page where we can see detailed information 
    /// and select to check more about development 
    /// and signs of deviation
    /// </summary>
    public string CheckMorePageText { get; set; }

    public string DevelopmentSupportingActivitiesButtonText { get; set; }

    public string AtypicalDevelopmentSignsText { get; set; }

    public string GreenActivityPageTitle { get; set; } = string.Empty;

    public string RedActivityPageTitle { get; set; } = string.Empty;

    public bool Active { get; set; }
}
