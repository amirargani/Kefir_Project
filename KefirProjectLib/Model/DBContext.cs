using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


public class DBContext : DbContext
{
    public DBContext() : base("Data Source=.;Initial Catalog=KefirDB;Integrated Security=true")
    {
        Configuration.LazyLoadingEnabled = false;
        Configuration.ProxyCreationEnabled = false;
    }
    static DBContext()
    {
        Database.SetInitializer(
            new MigrateDatabaseToLatestVersion<DBContext, MigrationConfig>()
            );
    }


    public DbSet<Abstract> Abstracts { get; set; }
    public DbSet<ContactUs> ContactUs { get; set; }
    public DbSet<Expert> Experts { get; set; }
    public DbSet<Gallery> Gallery { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<NewsPicture> NewsPictures { get; set; }
    public DbSet<Progress> Progresses { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Slide> Slides { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Faq> Faqs{ get; set; }
    public DbSet<Setting> Setting{ get; set; }
}
