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
        public DbSet<Device> Employees { get; set; }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }
        public DataContext()
            : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:blazoriot.database.windows.net,1433;Initial Catalog=iotdb;Persist Security Info=False;User ID=iotdb;Password=Blazordb2019;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
