namespace API.Database;

public class PracticeDatabaseContext : DbContext
{
    public PracticeDatabaseContext() : base() { } // Needed For Mocking The Database Context

    public PracticeDatabaseContext(DbContextOptions options) : base(options) { }

    public virtual DbSet<User> Users { get; set; } = null!;
}
