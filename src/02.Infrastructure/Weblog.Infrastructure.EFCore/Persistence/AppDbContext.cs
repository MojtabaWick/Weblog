using Microsoft.EntityFrameworkCore;
using Weblog.Domain.Core._common;
using Weblog.Domain.Core.AuthorAgg.Entities;
using Weblog.Domain.Core.CategoryAgg.Entities;
using Weblog.Domain.Core.CommentAgg.Entities;
using Weblog.Domain.Core.PostAgg.Entities;

namespace Weblog.Infrastructure.EFCore.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ApplyAuditFields();
            return base.SaveChanges();
        }

        private void ApplyAuditFields()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:

                        entry.Entity.UpdatedAt = DateTime.Now;

                        // Soft Delete
                        if (entry.Entity.IsDeleted && entry.Entity.DeletedAt == null)
                        {
                            entry.Entity.DeletedAt = DateTime.Now;
                        }

                        break;
                }
            }
        }
    }
}