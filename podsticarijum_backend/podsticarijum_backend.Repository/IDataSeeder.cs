namespace podsticarijum_backend.Repository;

public interface IDataSeeder
{
    Task EnsureInitialSeed();

    Task EnsureSuperuserSeeded();
}
