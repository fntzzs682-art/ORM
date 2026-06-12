using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Lesson3_CNLTWeb.Data
{
    // Design-time factory for EF Core tools (migrations)
    public class DesignTimeBookDbContextFactory : IDesignTimeDbContextFactory<BookDbContext>
    {
        public BookDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<BookDbContext>();
            var conn = configuration.GetConnectionString("BookConnection");
            optionsBuilder.UseSqlServer(conn);

            return new BookDbContext(optionsBuilder.Options);
        }
    }
}
