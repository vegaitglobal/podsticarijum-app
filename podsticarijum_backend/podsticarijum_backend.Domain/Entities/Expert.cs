namespace podsticarijum_backend.Domain.Entities;

public class Expert : EntityTimestamps
{
    protected Expert()
    {

    }

    public Expert(SubCategory subCategory, string firstName, string lastName, string email)
    {
        SubCategory = subCategory ?? throw new ArgumentNullException(nameof(subCategory));
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }

    public long Id { get; set; }

    public SubCategory SubCategory { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }
}
