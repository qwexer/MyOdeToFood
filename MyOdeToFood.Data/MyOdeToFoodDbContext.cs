using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyOdeToFood.Core;

namespace MyOdeToFood.Data
{
    public class MyOdeToFoodDbContext : DbContext
    {
        public MyOdeToFoodDbContext(DbContextOptions<MyOdeToFoodDbContext> options)
            : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}