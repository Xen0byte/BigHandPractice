namespace UnitTests.Contracts;

public interface IDataGenerator
{
    public List<User> GenerateUsers(int amount);
}
