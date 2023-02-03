namespace podsticarijum_backend.Domain.Entities;

public class Faq : EntityTimestamps
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Faq()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    public Faq(Category category, string question, string answer)
    {
        Category = category ?? throw new ArgumentNullException(nameof(category));
        Question = question ?? throw new ArgumentNullException(nameof(question));
        Answer = answer ?? throw new ArgumentNullException(nameof(answer));
    }

    public long Id { get; set; }

    public Category Category { get; set; }

    public string Question { get; set; }

    public string Answer { get; set; }
}
