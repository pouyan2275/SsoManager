using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Bases.Data;

public class DbContextFactory
{
    private readonly Dictionary<string, string> _connectionStrings;
    private readonly string _conString;

    public DbContextFactory(Dictionary<string, string> connectionStrings)
    {
        _connectionStrings = connectionStrings;
    }
    public UsersDbContext Create(string key)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException();

        var connStr = _connectionStrings[key] ?? throw new ArgumentNullException("Connection string not found");
        var optionsBuilder = new DbContextOptionsBuilder<UsersDbContext>();
        optionsBuilder.UseSqlServer(connStr);
        return new UsersDbContext(optionsBuilder.Options);
    }
}
