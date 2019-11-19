using IoTPortal.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<IoTUser> Users { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Register> Registrations { get; set; }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }
        public DataContext()
            : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:iotportal2019.database.windows.net,1433;Initial Catalog=iotportal;Persist Security Info=False;User ID=lars;Password=BOLLand123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
