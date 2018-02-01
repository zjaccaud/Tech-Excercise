using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApp1.Models.ContactModel;

namespace WebApp1.Data
{
    public class ContactContext : DbContext
    {
        public DbSet<Contacts> Contact { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=ec2-18-221-1-66.us-east-2.compute.amazonaws.com;database=contacts;user=myuser;password=mypass");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.FirstName);
                entity.Property(e => e.LastName).IsRequired();
            });
        }
    }

    
}
