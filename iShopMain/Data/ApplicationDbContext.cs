using Duende.IdentityServer.EntityFramework.Options;
using iShopMain.Models.Entity.UserInfo;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace iShopMain.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AppUser> users { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Information> informations { get; set; }
        public DbSet<Role> roles { get; set; }
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
            ApplicationDbInitializer.Initialize(this);
        }

    }
}
