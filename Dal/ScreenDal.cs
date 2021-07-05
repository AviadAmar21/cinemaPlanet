using CinemaPlanet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaPlanet.Dal
{
    public class ScreenDal : DbContext
    {

        public DbSet<Screen> Screens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().ToTable("tblScreen");

        }
    }
}