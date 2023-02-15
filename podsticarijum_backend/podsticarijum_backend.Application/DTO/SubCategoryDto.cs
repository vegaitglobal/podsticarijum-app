using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.DTO;

public class SubCategoryDto
{
    public SubCategoryDto(long id, CategoryDto? categoryDto, string mainNavMenuText, string mainText, string additionalText, string checkMoreButtonText, string checkMorePageTitle, string checkMorePageText, string developmentSupportingActivitiesButtonText, string atypicalDevelopmentSignsText, bool active)
    {
        Id = id;
        CategoryDto = categoryDto;
        MainNavMenuText = mainNavMenuText;
        MainText = mainText;
        AdditionalText = additionalText;
        CheckMoreButtonText = checkMoreButtonText;
        CheckMorePageTitle = checkMorePageTitle;
        CheckMorePageText = checkMorePageText;
        DevelopmentSupportingActivitiesButtonText = developmentSupportingActivitiesButtonText;
        AtypicalDevelopmentSignsText = atypicalDevelopmentSignsText;
        Active = active;
    }

    public long Id { get; set; }

    /// <summary>
    /// Related category object to this subcategory
    /// </summary>
    public CategoryDto? CategoryDto { get; set; }

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

    public bool Active { get; set; }
}
