namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly PracticeDatabaseContext _context;
    private readonly IRequestInfo _requestInfo;

    public UsersController(ILogger<UsersController> logger, PracticeDatabaseContext context, IRequestInfo requestInfo)
    {
        _logger = logger;
        _context = context;
        _requestInfo = requestInfo;
    }

    [HttpPost(Name = "Create User")]
    public async Task<IActionResult> CreateUser(UserForCreate payload)
    {
        _requestInfo.LogRequestInfo(Request);

        User user = new()
        {
            FirstName = payload.FirstName,
            LastName = payload.LastName,
            Age = payload.Age
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        
        return Ok(user.Id);
    }

    [HttpGet(Name = "Get Users")]
    public async Task<IActionResult> GetUsers()
    {
        _requestInfo.LogRequestInfo(Request);

        return Ok(await _context.Users.ToListAsync());
    }

    [HttpGet("Age", Name = "Get Users By Age")]
    public async Task<IActionResult> GetUsersByAge(int age)
    {
        _requestInfo.LogRequestInfo(Request);

        return Ok(await _context.Users.Where(user => user.Age == age).ToListAsync());
    }
}
