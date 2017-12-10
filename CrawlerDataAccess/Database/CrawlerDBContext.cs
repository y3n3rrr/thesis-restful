namespace CrawlerDataAccess.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CrawlerDBContext : DbContext
    {
        public CrawlerDBContext()
            : base("name=CrawlerDBContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
