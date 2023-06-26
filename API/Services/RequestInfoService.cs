namespace API.Services;

public class RequestInfoService : IRequestInfo
{
    public void LogRequestInfo(HttpRequest request)
    {
        string requestMethod = request.Method;
        string requestFullPath = request.Host + request.Path;
        string address = request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "0.0.0.0";

        Console.WriteLine($"{address} @ {requestMethod} {requestFullPath}");
    }
}
