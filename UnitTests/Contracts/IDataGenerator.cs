namespace UnitTests.Contracts;

internal interface IDataGenerator
{
    public List<User> GenerateUsers(int amount);
}
