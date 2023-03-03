namespace podsticarijum_backend.Domain.Entities;

public class Faq : EntityTimestamps
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Faq()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    public Faq(SubCategory subCategory, string question, string answer)
    {
        SubCategory = subCategory ?? throw new ArgumentNullException(nameof(subCategory));
        Question = question ?? throw new ArgumentNullException(nameof(question));
        Answer = answer ?? throw new ArgumentNullException(nameof(answer));
    }

    public long Id { get; set; }

    public SubCategory SubCategory { get; set; }

    public string Question { get; set; }

    public string Answer { get; set; }
}
