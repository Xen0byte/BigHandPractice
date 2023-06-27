namespace UnitTests.Models;

[Serializable]
internal class UserForTestRequest
{
    [JsonPropertyName("username")]
    internal string UserName { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    internal string Password { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    internal string Email { get; set; } = string.Empty;
}
