﻿#nullable disable
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Repository;

public class DataSeeder : IDataSeeder
{
    private readonly PodsticarijumContext _podsticarijumContext;

    public DataSeeder(PodsticarijumContext podsticarijumContext)
    {
        _podsticarijumContext = podsticarijumContext;
    }

    public async Task EnsureInitialSeed()
    {
        if (_podsticarijumContext.Category.Count() < 5)
        {
            for (int i = 0; i < 5; i++)
            {
                _podsticarijumContext.Category
                .Add(
                    new Category(
                        $"Category {i}",
                        $"Cat{i} Description"));
            }
        }

        if (_podsticarijumContext.SubCategory.Count() < 25)
        {
            foreach (Category category in _podsticarijumContext.Category)
            {
                for (int i = 0; i < 5; i++)
                {
                    _podsticarijumContext.SubCategory.Add(
                        new SubCategory(
                            category: category,
                            mainNavMenuText: $"SubCategory {category.Id}/{i}",
                            additionalText: "added text",
                            mainText: "main text",
                            checkMoreButtonText: "check more",
                            checkMorePageTitle: "title",
                            checkMorePageText: "text text text",
                            developmentSupportingActivitiesButtonText:
                            "supporting activities 1 2 3",
                            atypicalDevelopmentSignsText: "not so typical",
                            greenActivityPageTitle: "green activity page title", 
                            redActivityPageTitle: "red activity page title",
                            active: true)
                        );
                }
            }
        }

        if (_podsticarijumContext.SubCategorySpecificContent.Count() < 55)
        {
            foreach (SubCategory subCategory in _podsticarijumContext.SubCategory)
            {
                for (int i = 0; i < 5; i++)
                {
                    _podsticarijumContext.Add(
                        new SubCategorySpecificContent(
                        subCategory: subCategory,
                        paragraphText: "paragraph texttt",
                        paragraphSign: Domain.ParagraphSign.GreenFlag));

                    _podsticarijumContext.Add(
                        new SubCategorySpecificContent(
                        subCategory: subCategory,
                        paragraphText: "paragraph texttt",
                        paragraphSign: Domain.ParagraphSign.RedFlag));
                }
            }
        }

        if (_podsticarijumContext.Faq.Count() < 50)
        {
            foreach (SubCategory subCategory in _podsticarijumContext.SubCategory)
            {
                for (int i = 0; i < 6; i++)
                {
                    _podsticarijumContext.Faq.Add(
                        new Faq(
                            subCategory: subCategory,
                            question: "How are you, sir?",
                            answer: "Very fine, sir!?"
                        ));
                }
            }
        }

        if (_podsticarijumContext.Expert.Count() < 5)
        {
            foreach (SubCategory subCategory in _podsticarijumContext.SubCategory)
            {
                _podsticarijumContext.Expert.Add(
                        new Expert(subCategory: subCategory,
                            firstName: "Expert",
                            lastName: "Expertovic",
                            email: "validEmail@validprovider.com",
                            description: "description for expert"));
            }
        }

        if (_podsticarijumContext.ExpertInfo.Count() < 10)
        {
            for(int i = 0; i < 10; i++)
            {
                _podsticarijumContext.Add(
                    new ExpertInfo(
                        title: "Tajtl" + i.ToString(),
                        content: "Kontent!" + i.ToString()
                        )
                    );
            }
        }

        if (_podsticarijumContext.Content.Where(c => c.ContentType == Domain.ContentType.MainScreen).Count() == 0)
        {
            _podsticarijumContext.Content.Add(
                new Content(
                    contentType: Domain.ContentType.MainScreen,
                    text: "Content for main/initial screen",
                    additionalText: "additional text"
                ));
        }

        if (_podsticarijumContext.Content
            .Where(c => c.ContentType != Domain.ContentType.MainScreen).Count() < 5)
        {
            _podsticarijumContext.Content.Add(
                new Content(
                    contentType: Domain.ContentType.Donations,
                    text: "Content for main/initial screen",
                    additionalText: "additional text"
                ));
        }

        if (_podsticarijumContext.Content.Where(c => c.ContentType == Domain.ContentType.MainScreen).Count() == 0)
        {
            _podsticarijumContext.Content.Add(
                new Content(
                    contentType: Domain.ContentType.AboutUs,
                    text: "About us text",
                    additionalText: "About us - unused additional text"
                ));
        }

        if (_podsticarijumContext.Content.Where(c => c.ContentType == Domain.ContentType.MainScreen).Count() == 0)
        {
            _podsticarijumContext.Content.Add(
                new Content(
                    contentType: Domain.ContentType.Information,
                    text: "Information texttexttext",
                    additionalText: "Information additional text - unused"
                ));
        }

        await _podsticarijumContext.SaveChangesAsync();
    }

    public async Task EnsureSuperuserSeeded()
    {

        if (_podsticarijumContext.User.Count() < 1)
        {
            _podsticarijumContext.User.Add(
                new User()
                {
                    Username = "superuser",
                    Password = Environment.GetEnvironmentVariable("DB_PASSWORD")
                }
                );
            await _podsticarijumContext.SaveChangesAsync();
        }
    }

}
