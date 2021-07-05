using CinemaPlanet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaPlanet.Dal
{
    public class CartDal : DbContext
    {

       public DbSet <Cart> Carts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cart>().ToTable("tblCart");

        }

    }
}