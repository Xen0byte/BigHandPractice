namespace UnitTests.ControllerTests;

[TestFixture]
internal class UsersControllerTests
{
    private UsersController _controller = null!;
    private const int UsersCount = 100;

    [SetUp]
    public void SetUp()
    {
        Mock<PracticeDatabaseContext> mockDatabaseContext = new();
        Mock<ILogger<UsersController>> mockLogger = new();
        Mock<IRequestInfo> mockRequestInfo = new();

        List<User> mockUsers = new DataGeneratorService().GenerateUsers(UsersCount);

        mockDatabaseContext.Setup(context => context.Users).ReturnsDbSet(mockUsers);

        _controller = new UsersController(mockLogger.Object, mockDatabaseContext.Object, mockRequestInfo.Object);
    }

    [Test]
    public async Task GetUsers_ShouldReturnUsers_IfThereAreUsers()
    {
        IActionResult result = await _controller.GetUsers();

        if (result is not OkObjectResult) Assert.Fail();

        List<User>? response = (result as OkObjectResult)?.Value as List<User>;

        Assert.That(response?.Count ?? 0, Is.EqualTo(UsersCount));
    }
}
