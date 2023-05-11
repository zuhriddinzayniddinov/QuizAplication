using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("temploye");
        }
    }
}
