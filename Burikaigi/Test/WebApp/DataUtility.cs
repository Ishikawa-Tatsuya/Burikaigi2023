using Burikaigi.Server.Data;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Test.WebApp
{
    public static class DataUtility
    {
        public class OperationalStoreOptionsMock : IOptions<OperationalStoreOptions>
        {
            public OperationalStoreOptions Value => new();
        }

        public static ApplicationDbContext CreateWriteDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(File.ReadAllText(@"c:\aaa\info.txt"));
            return new ApplicationDbContext(optionsBuilder.Options, new OperationalStoreOptionsMock());
        }
    }
}
