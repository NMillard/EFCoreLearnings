using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations {
    public class BookConfig : IEntityTypeConfiguration<Book> {
        public void Configure(EntityTypeBuilder<Book> builder) {
            builder.ToTable("Books");
            builder.HasKey("id");
        }
    }
}