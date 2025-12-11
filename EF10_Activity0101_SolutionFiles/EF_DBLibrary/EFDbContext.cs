using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;

namespace EF_DBLibrary;

public class EFDbContext : DbContext
{
    public EFDbContext()
    {
        //blank
    }

    public EFDbContext(DbContextOptions options)
    : base(options)
    {
        //blank
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.Options.Extensions.OfType<SqlServerOptionsExtension>().Any())
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connStr = config.GetConnectionString("EFDbConnection");
            optionsBuilder.UseSqlServer(connStr);
        }
    }
}
