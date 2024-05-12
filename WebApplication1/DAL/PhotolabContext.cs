
using Photolabs.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace Photolabs.DAL {
  public class PhotolabContext : DbContext {
    public PhotolabContext(DbContextOptions<PhotolabContext> options) : base(options) {
    }

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Photo> Photos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      int dummy = 1;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.UseIdentityColumns();
      new PhotolabsInitializer().Seed(modelBuilder);
      //modelBuilder.Entity<Person>().Property(person => person.Id).HasIdentityOptions(startValue: 100);

      //modelBuilder.Entity<Person>().HasData(
      //    new Person(1, "MikieD", "Mike", "Dragert", "blue", 2, 0),
      //    new Person(2, "James", "James", "Young", "blue", 2, 0),
      //    new Person(3, "Rossco", "Ross", "Struthers", "green", 0, 0)
      //);
    }
  }
}
