namespace UnitTests.ControllerTests;

[TestFixture]
internal class HttpRequestTests
{
    private HttpClient _client = null!;

    [SetUp]
    public void SetUp()
    {
        _client = new HttpClient();
    }

    [Test]
    [TestCase("TestUser", "TestPassword", "test@email.com", 527)]
    public async Task Post_ShouldReturnCorrectStringContent(string username, string password, string email, int expectedContentLength)
    {
        Dictionary<string, object> user = new() { {"username", username }, { "password", password }, { "email", email } };
        StringContent payload = new(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

        using HttpResponseMessage response = await _client.PostAsync("https://httpbin.org/post", payload);
        string responseContent = await response.Content.ReadAsStringAsync();

        Assert.That(responseContent?.Length ?? 0, Is.EqualTo(expectedContentLength));
    }

    [Test]
    [TestCase("TestUser", "TestPassword", "test@email.com")]
    public async Task Post_ShouldReturnCorrectObjectContent(string username, string password, string email)
    {
        UserForTestRequest user = new() { UserName = username, Password = password, Email = email };

        using HttpResponseMessage response = await _client.PostAsJsonAsync("https://httpbin.org/post", user);
        Dictionary<string, object> responseContent = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>() ?? new Dictionary<string, object>();

        string responseContentSerialized = JsonSerializer.Serialize(responseContent["json"]);
        UserForTestRequest responseContentDeserialized = JsonSerializer.Deserialize<UserForTestRequest>(responseContentSerialized) ?? new UserForTestRequest();

        Assert.Multiple(() =>
        {
            Assert.That(responseContentDeserialized.UserName, Is.EqualTo(user.UserName));
            Assert.That(responseContentDeserialized.Password, Is.EqualTo(user.Password));
            Assert.That(responseContentDeserialized.Email, Is.EqualTo(user.Email));
        });
    }
}
