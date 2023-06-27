namespace UnitTests.Services;

internal class DataGeneratorService : IDataGenerator
{
    private readonly Faker _faker;

    internal DataGeneratorService() => _faker = new Faker();

    public List<User> GenerateUsers(int amount)
    {
        List<User> users = new();

        for (int i = 0; i < amount; i++)
        {
            users.Add(new User()
            {
                FirstName = _faker.Name.FirstName(),
                LastName = _faker.Name.LastName(),
                Age = _faker.Random.Number(100)
            });
        }

        return users;
    }
}
