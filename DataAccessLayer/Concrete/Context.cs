using EntityLayer.Concrete;
using System.Data.Entity;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {

        public DbSet<Category> Categories { get; set; }

        public DbSet<Content> Contents { get; set; }

        public DbSet<Heading> Headings { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
