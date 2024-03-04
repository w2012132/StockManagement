using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockManagementAPI.Model;
using System;

namespace StockManagementAPI.Database
{
    public class SM_DBContext: IdentityDbContext<IdentityUser>
    {
        public SM_DBContext(DbContextOptions<SM_DBContext> options) : base(options)
        {
        }

        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Model configuration code here
        //    // For example, to configure a one-to-many relationship between Category and Products
        //    modelBuilder.Entity<Category>()
        //        .HasMany(c => c.Products)
        //        .WithOne(p => p.Category)
        //        .HasForeignKey(p => p.CategoryId);
        //}
    }
}
