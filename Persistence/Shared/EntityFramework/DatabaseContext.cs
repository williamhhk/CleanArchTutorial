using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using Domain.Common;

namespace Persistence.Shared.EntityFramework
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Sale> Sales { get; set; }

        public DatabaseContext() : base("CleanArchitecture")
        {
            //Database.SetInitializer(new DatabaseInitializer());
        }

        public new IDbSet<T> Set<T>() where T : class, IEntity
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Configurations.Add(new CustomerConfiguration());
            //modelBuilder.Configurations.Add(new EmployeeConfiguration());
            //modelBuilder.Configurations.Add(new ProductConfiguration());
            //modelBuilder.Configurations.Add(new SaleConfiguration());
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
