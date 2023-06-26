namespace API;

public class EntryPoint
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Database stuff
        string connectionString = builder.Configuration.GetConnectionString("SQLite") ?? "Data Source = TEMPORARY.SQLITE";

        builder.Services.AddDbContext<PracticeDatabaseContext>(contextOptions =>
        {
            contextOptions.UseSqlite(connectionString, connectionOptions =>
            {
                connectionOptions.MigrationsAssembly("API");
            });
        });

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddScoped<IRequestInfo, RequestInfoService>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
