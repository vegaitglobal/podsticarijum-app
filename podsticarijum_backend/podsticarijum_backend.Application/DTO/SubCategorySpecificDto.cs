﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using podsticarijum_backend.Domain;

namespace podsticarijum_backend.Application.DTO;

public class SubCategorySpecificDto
{
    public SubCategorySpecificDto(long id, SubCategoryDto subCategoryDto, string pageTitle, string paragraphText, ParagraphSign paragraphSign)
    {
        Id = id;
        SubCategoryDto = subCategoryDto;
        PageTitle = pageTitle;
        ParagraphText = paragraphText;
        ParagraphSign = paragraphSign;
    }

    public long Id { get; set; }

    public SubCategoryDto SubCategoryDto { get; set; }

    public string PageTitle { get; set; }

    public string ParagraphText { get; set; }

    public ParagraphSign ParagraphSign { get; set; }
}