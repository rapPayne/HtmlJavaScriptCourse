using System;
using System.Data.Entity;
using System.Data.EntityClient;
using Core;

namespace Infrastructure
{
    public class NorthwindContext : DbContext
    {
        //public static string _connString = @"Data Source=.\SQLEXPRESS;AttachDbFilename='C:\Users\Rap\Documents\Visual Studio 2012\Projects\HtmlJavaScriptCourse\Infrastructure\App_Data\NORTHWND.MDF';Integrated Security=True;User Instance=True";
        //public static string _connString = @"Data Source='C:\Users\Rap\Documents\Visual Studio 2012\Projects\HtmlJavaScriptCourse\Infrastructure\App_Data\Northwind.sdf';Persist Security Info=False;";
        //public static string _connString = @"Data Source=.\SQLEXPRESS;AttachDbFilename='|DataDirectory|NORTHWND.MDF';Database=Northwnd;Integrated Security=SSPI;User Instance=True";
        //public static string _connString = @"Data Source=.\SQLEXPRESS;AttachDbFilename='\App_Data\NORTHWND.MDF';Integrated Security=True;User Instance=True";
        //public static string _connString = @"Data Source='|DataDirectory|Northwind.sdf';Persist Security Info=False;";
        //private NorthwindContext()
        //    : base(_connString)
        //{
        //}        
        #region Singleton pattern
        private static NorthwindContext _northwindContext;
        public static NorthwindContext GetNorthwindContext()
        {
            _northwindContext = (_northwindContext ?? new NorthwindContext());
            return _northwindContext;
        }
        #endregion

        public DbSet<BlogEntry> BlogEntries { get; set; }
        public DbSet<BlogResponse> BlogResponses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetail>().HasKey(a => new { a.ProductId, a.OrderId });
        }
    }
}
