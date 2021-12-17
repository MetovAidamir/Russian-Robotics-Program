using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;


namespace Russian_Robotics.Models
{
    class context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=WorkCSV;Integrated Security=True;");
        }
        public DbSet<PriceItems> PriceItems { get; set; }
    }
}
