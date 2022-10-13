using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data.TypeConfigurations;
using SelfiesAWookies.Core.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Data
{

    public class SelfieContext : DbContext, IUnitOfWork
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SelfieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WookieEntityTypeConfiguration());

        }
        public SelfieContext([NotNullAttribute]DbContextOptions options) : base(options){ }
        public SelfieContext() : base() { }

        public DbSet<Selfie> Selfies { get; set;  } 
        public DbSet<Wookie> Wookies{ get; set;  } 
        public DbSet<Picture> Pictures{ get; set;  } 
    }
}
