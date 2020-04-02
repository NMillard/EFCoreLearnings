using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations {
    internal class AuthorConfig : IEntityTypeConfiguration<Author> {
        
        public void Configure(EntityTypeBuilder<Author> builder) {
            builder.ToTable("Authors"); // Not required, but I like to explicitly state the table name
            
            builder.HasKey("id") // Tell EF to find the field called "id" and use it as primary key
                .HasName("PK_Authors"); // Primary key object name in the database (NOT column name)
            
            builder.Property(author => author.Name)
                .HasMaxLength(150) // setting max length can provide huge performance gains
                .IsRequired();
            
            
            // Tell EF to find the navigation property and use this for the books collection
            builder.Metadata
                .FindNavigation(nameof(Author.Books))
                // Convention based -> will find field named "books"
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(author => author.Status)
                .HasConversion(
                    value => value.ToString(), // How to convert when storing
                    convertedValue => Enum.Parse<AuthorStatus>(convertedValue)); // How to convert value from database when retrieving 

            // "RecommendationScore" is an owned type, and will only ever appear
            // as a navigation property on the "Author" type.
            builder.OwnsOne<RecommendationScore>(
                navigationName: nameof(Author.RecommendationScore),
                buildAction: recommendationBuilder => {
                recommendationBuilder.ToTable("AuthorRecommendationScores");
                
                // Required because "Score" has not setter
                recommendationBuilder.Property(ar => ar.Score);
            });
        }
    }
}