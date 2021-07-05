using CinemaPlanet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaPlanet.Dal
{
    public class MovieDal : DbContext
    {
        public DbSet<Movie> Movies { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().ToTable("tblMovie");
           
        }

        
    }
}