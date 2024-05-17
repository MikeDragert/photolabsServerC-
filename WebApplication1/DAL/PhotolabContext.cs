
using Photolabs.Models;
using Microsoft.EntityFrameworkCore;

namespace Photolabs.DAL {
  public class PhotolabContext : DbContext {
    public PhotolabContext(DbContextOptions<PhotolabContext> options) : base(options) {
    }

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Photo> Photos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.UseIdentityColumns();
      new PhotolabsInitializer().Seed(modelBuilder);
    }
  }
}
