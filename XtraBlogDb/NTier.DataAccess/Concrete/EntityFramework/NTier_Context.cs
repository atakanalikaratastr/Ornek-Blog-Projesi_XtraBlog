using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.DataAccess.Concrete.EntityFramework
{
    public class NTier_Context : DbContext
    {
        public NTier_Context() : base("XtraBlogDbEntities")
        {

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<BlogToTag> BlogToTag { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<About>().ToTable("Abouts");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Blog>().ToTable("Blogs");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Tag>().ToTable("Tags");
            modelBuilder.Entity<Title>().ToTable("Titles");
            modelBuilder.Entity<BlogToTag>().HasKey(de => new { de.BlogId, de.TagId }).ToTable("BlogToTag");

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        
    }
}
