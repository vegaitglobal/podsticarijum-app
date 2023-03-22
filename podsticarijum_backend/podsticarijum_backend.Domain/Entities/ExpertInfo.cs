using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace podsticarijum_backend.Domain.Entities;

public class ExpertInfo
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected ExpertInfo()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    public ExpertInfo(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public long Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }
}
