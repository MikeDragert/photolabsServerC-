using Microsoft.AspNetCore.Identity;
//using Photolabs.Controllers;
using Photolabs.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Photolabs.DAL {
  public class PhotolabsInitializer {
    public void Seed(ModelBuilder modelBuilder) {

      modelBuilder.UseIdentityColumns();
      modelBuilder.Entity<Topic>().Property(person => person.Id).HasIdentityOptions(startValue: 100);
      modelBuilder.Entity<UserAccount>().Property(person => person.Id).HasIdentityOptions(startValue: 100);
      modelBuilder.Entity<Photo>().Property(person => person.Id).HasIdentityOptions(startValue: 100);


      modelBuilder.Entity<Topic>().HasData(
        new Topic{Id=1, Title="People",  Slug="people"},
        new Topic{Id=2, Title="Nature",  Slug="nature"},
        new Topic{Id=3, Title="Travel",  Slug="travel"},
        new Topic{Id=4, Title="Animals", Slug="animals"},
        new Topic{Id=5, Title="Fashion", Slug="fashion"}
      );

      modelBuilder.Entity<UserAccount>().HasData(
        new UserAccount{Id=1, FullName="John Doe", Username="jdoe", ProfileUrl="profile-1.jpg"},
        new UserAccount{Id=2, FullName="Alice Wonderland", Username="awond", ProfileUrl="profile-2.jpg"},
        new UserAccount{Id=3, FullName="Sita Dennis", Username="sitad", ProfileUrl="profile-3.jpg"},
        new UserAccount{Id=4, FullName="Sasha Mateo", Username="matte", ProfileUrl="profile-4.jpg"},
        new UserAccount{Id=5, FullName="Anita Austi", Username="anita", ProfileUrl="profile-5.jpg"},
        new UserAccount{Id=6, FullName="Lukas Souza", Username="lsouza", ProfileUrl="profile-6.jpg"},
        new UserAccount{Id=7, FullName="Jose Alejandro", Username="josea", ProfileUrl="profile-7.jpg"},
        new UserAccount{Id=8, FullName="Dwayne Jacob", Username="jdwayne", ProfileUrl="profile-8.jpg"},
        new UserAccount{Id=9, FullName="Allison Saeng", Username="saeng", ProfileUrl="profile-9.jpg"},
        new UserAccount{Id=10,FullName= "Adrea Santos", Username="santa", ProfileUrl="profile-10.jpg" }
      );

      modelBuilder.Entity<Photo>().HasData(
        new Photo{Id=1,  FullUrl="Image-1-Full.jpeg", RegularUrl="Image-1-Regular.jpeg", City="Montreal", Country="Canada"},
        new Photo{Id=11, FullUrl="people-1-full.jpg", RegularUrl="people-1-regular.jpg", City="Toronto", Country="Canada"},
        new Photo{Id=12, FullUrl="people-2-full.jpg", RegularUrl="people-2-regular.jpg", City="Vancouver", Country="Canada"},
        new Photo{Id=13, FullUrl="people-3-full.jpg", RegularUrl="people-3-regular.jpg", City="Calgary", Country="Canada"},
        new Photo{Id=14, FullUrl="people-4-full.jpg", RegularUrl="people-4-regular.jpg", City="Victoria", Country="Canada"},
        new Photo{Id=15, FullUrl="people-5-full.jpg", RegularUrl="people-5-regular.jpg", City="Ottawa", Country="Canada"},
        new Photo{Id=16, FullUrl="people-6-full.jpg", RegularUrl="people-6-regular.jpg", City="Montreal", Country="Canada"},
        new Photo{Id=17, FullUrl="people-7-full.jpg", RegularUrl="people-7-regular.jpg", City="Toronto", Country="Canada"},
        new Photo{Id=18, FullUrl="people-8-full.jpg", RegularUrl="people-8-regular.jpg", City="Vancouver", Country="Canada"},
        new Photo{Id=19, FullUrl="people-9-full.jpg", RegularUrl="people-9-regular.jpg", City="Calgary", Country="Canada"},
        new Photo{Id=21, FullUrl="nature-1-full.jpg", RegularUrl="nature-1-regular.jpg", City="Toronto", Country="Canada"},
        new Photo{Id=22, FullUrl="nature-2-full.jpg", RegularUrl="nature-2-regular.jpg", City="Vancouver", Country="Canada"},
        new Photo{Id=23, FullUrl="nature-3-full.jpg", RegularUrl="nature-3-regular.jpg", City="Calgary", Country="Canada"},
        new Photo{Id=24, FullUrl="nature-4-full.jpg", RegularUrl="nature-4-regular.jpg", City="Victoria", Country="Canada"},
        new Photo{Id=25, FullUrl="nature-5-full.jpg", RegularUrl="nature-5-regular.jpg", City="Ottawa", Country="Canada"},
        new Photo{Id=26, FullUrl="nature-6-full.jpg", RegularUrl="nature-6-regular.jpg", City="Montreal", Country="Canada"},
        new Photo{Id=27, FullUrl="nature-7-full.jpg", RegularUrl="nature-7-regular.jpg", City="Toronto", Country="Canada"},
        new Photo{Id=28, FullUrl="nature-8-full.jpg", RegularUrl="nature-8-regular.jpg", City="Vancouver", Country="Canada"},
        new Photo{Id=29, FullUrl="nature-9-full.jpg", RegularUrl="nature-9-regular.jpg", City="Calgary", Country="Canada"},
        new Photo{Id=31, FullUrl="travel-1-full.jpg", RegularUrl="travel-1-regular.jpg", City="Toronto", Country="Canada"},
        new Photo{Id=32, FullUrl="travel-2-full.jpg", RegularUrl="travel-2-regular.jpg", City="Vancouver", Country="Canada"},
        new Photo{Id=33, FullUrl="travel-3-full.jpg", RegularUrl="travel-3-regular.jpg", City="Calgary", Country="Canada"},
        new Photo{Id=34, FullUrl="travel-4-full.jpg", RegularUrl="travel-4-regular.jpg", City="Victoria", Country="Canada"},
        new Photo{Id=35, FullUrl="travel-5-full.jpg", RegularUrl="travel-5-regular.jpg", City="Ottawa", Country="Canada"},
        new Photo{Id=36, FullUrl="travel-6-full.jpg", RegularUrl="travel-6-regular.jpg", City="Montreal", Country="Canada"},
        new Photo{Id=37, FullUrl="travel-7-full.jpg", RegularUrl="travel-7-regular.jpg", City="Toronto", Country="Canada"},
        new Photo{Id=38, FullUrl="travel-8-full.jpg", RegularUrl="travel-8-regular.jpg", City="Vancouver", Country="Canada"},
        new Photo{Id=41, FullUrl="animals-1-full.jpg", RegularUrl="animals-1-regular.jpg", City="Toronto", Country="Canada"},
        new Photo{Id=42, FullUrl="animals-2-full.jpg", RegularUrl="animals-2-regular.jpg", City="Vancouver", Country="Canada"},
        new Photo{Id=43, FullUrl="animals-3-full.jpg", RegularUrl="animals-3-regular.jpg", City="Calgary", Country="Canada"},
        new Photo{Id=44, FullUrl="animals-4-full.jpg", RegularUrl="animals-4-regular.jpg", City="Victoria", Country="Canada"},
        new Photo{Id=45, FullUrl="animals-5-full.jpg", RegularUrl="animals-5-regular.jpg", City="Ottawa", Country="Canada"},
        new Photo{Id=46, FullUrl="animals-6-full.jpg", RegularUrl="animals-6-regular.jpg", City="Montreal", Country="Canada"},
        new Photo{Id=47, FullUrl="animals-7-full.jpg", RegularUrl="animals-7-regular.jpg", City="Toronto", Country="Canada"},
        new Photo{Id=48, FullUrl="animals-8-full.jpg", RegularUrl="animals-8-regular.jpg", City="Vancouver", Country="Canada"},
        new Photo{Id=49, FullUrl="animals-9-full.jpg", RegularUrl="animals-9-regular.jpg", City="Calgary", Country="Canada"},
        new Photo{Id=51, FullUrl="fashion-1-full.jpg", RegularUrl="fashion-1-regular.jpg", City="Toronto", Country="Canada"},
        new Photo{Id=52, FullUrl="fashion-2-full.jpg", RegularUrl="fashion-2-regular.jpg", City="Vancouver", Country="Canada"},
        new Photo{Id=53, FullUrl="fashion-3-full.jpg", RegularUrl="fashion-3-regular.jpg", City="Calgary", Country="Canada"},
        new Photo{Id=54, FullUrl="fashion-4-full.jpg", RegularUrl="fashion-4-regular.jpg", City="Victoria", Country="Canada"},
        new Photo{Id=55, FullUrl="fashion-5-full.jpg", RegularUrl="fashion-5-regular.jpg", City="Ottawa", Country="Canada"},
        new Photo{Id=56, FullUrl="fashion-6-full.jpg", RegularUrl="fashion-6-regular.jpg", City="Montreal", Country="Canada"},
        new Photo{Id=57, FullUrl="fashion-7-full.jpg", RegularUrl="fashion-7-regular.jpg", City="Toronto", Country="Canada"},
        new Photo{Id=58, FullUrl="fashion-8-full.jpg", RegularUrl="fashion-8-regular.jpg", City="Vancouver", Country="Canada"},
        new Photo{Id=59, FullUrl="fashion-9-full.jpg", RegularUrl="fashion-9-regular.jpg", City="Calgary", Country="Canada"}
      );
    }
  }
}
