
using Photolabs.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Photolabs.DAL
{
  public class PhotolabContext : DbContext
  {
    public PhotolabContext() : base("PhotolabsContext") {
    }

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Photo> Photos { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
  }
}
