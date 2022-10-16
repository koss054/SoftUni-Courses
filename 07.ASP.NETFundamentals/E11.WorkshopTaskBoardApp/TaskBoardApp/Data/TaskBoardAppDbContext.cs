using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using TaskBoardApp.Data.Entities;

namespace TaskBoardApp.Data
{
    public class TaskBoardAppDbContext : IdentityDbContext<User>
    {
        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
            this.Database.MigrateAsync();
        }

        public DbSet<Board> Boards { get; set; }

        //Using the path of Task, because it's ambigious with as system method named Task
        public DbSet<Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Entities.Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}