namespace ForumApp.Data
{
    using Microsoft.EntityFrameworkCore;

    using Entities;

    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>();

            base.OnModelCreating(builder);
        }
    }
}
