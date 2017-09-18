namespace ProductWebAPI.DAL
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SistranContext : DbContext
    {
        // Your context has been configured to use a 'SistranContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProductWebAPI.DAL.SistranContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SistranContext' 
        // connection string in the application configuration file.
        public SistranContext()
            : base("name=SistranContext")
        {
            InitializeDatabase();
        }

        protected virtual void InitializeDatabase()
        {
            Database.SetInitializer(new SistranInitializer());
            if (!Database.Exists())
            {
                Database.Initialize(true);
            }
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.a

        public DbSet<Product> Products { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}