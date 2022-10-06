namespace ForumApp.Data
{
    using Microsoft.EntityFrameworkCore;

    using Entities;

    public class ForumAppDbContext : DbContext
    {
        private Post FirstPost { get; set; }

        private Post SecondPost { get; set; }

        private Post ThirdPost { get; set; }


        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedPosts();
            builder
                .Entity<Post>()
                .HasData(this.FirstPost,
                         this.SecondPost,
                         this.ThirdPost);

            base.OnModelCreating(builder);
        }

        private void SeedPosts()
        {
            this.FirstPost = new Post()
            {
                Id = 1,
                Title = "First Post",
                Content = "Content for the first post. Very interesting and informative, for sure."
            };

            this.SecondPost = new Post()
            {
                Id = 2,
                Title = "How to Cook Better",
                Content = "An age old question. How do you do it? Some say watch cookings shows. But it's most effective to just do it. Sponsored by Nike."
            };

            this.ThirdPost = new Post()
            {
                Id = 3,
                Title = "A Third Post??",
                Content = "How is this possible? Incredible! A third post on this formum."
            };
        }
    }
}
