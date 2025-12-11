using Microsoft.EntityFrameworkCore;

namespace EF10_AWDBLibrary;

public class AdventureWorksContext : DbContext
{
    public AdventureWorksContext()
    {
        //blank
    }

    public AdventureWorksContext(DbContextOptions options)
    : base(options)
    {
        //blank
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.Options.Extensions.OfType<SqlServerOptionsExtension>().Any())
    //    {
    //        var config = new ConfigurationBuilder()
    //            .SetBasePath(AppContext.BaseDirectory)
    //            .AddJsonFile("appsettings.json")
    //            .Build();

    //        var connStr = config.GetConnectionString("AWDbConnection");
    //        optionsBuilder.UseSqlServer(connStr);
    //    }
    //}
}
