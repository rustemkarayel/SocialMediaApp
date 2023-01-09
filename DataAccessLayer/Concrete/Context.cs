using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=DESKTOP-M927P0K\\SQLEXPRESS ; database=DBSocialMedia ;Trusted_Connection=True; Encrypt=False;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SavedCollection> SavedCollections { get; set; }
        public DbSet<Saved> Saveds { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
