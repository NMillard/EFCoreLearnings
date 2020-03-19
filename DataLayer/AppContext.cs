using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer {
    internal class AppContext : DbContext {
        public AppContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
            // Find classes that implements IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        }
    }
}