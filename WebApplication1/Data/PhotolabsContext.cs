using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Photolabs.Models;

namespace Photolabs.DAL
{
    public class PhotolabsContext : DbContext
    {
        public PhotolabsContext (DbContextOptions<PhotolabsContext> options)
            : base(options)
        {
        }

        public DbSet<Photolabs.Models.Photo> Photo { get; set; } = default!;

        public DbSet<Photolabs.Models.Topic>? Topic { get; set; }

        public DbSet<Photolabs.Models.UserAccount>? UserAccount { get; set; }
    }
}
