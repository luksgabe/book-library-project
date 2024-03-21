using BookLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Infra.Data.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("book_id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(b => b.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(b => b.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(b => b.TotalCopies)
                .HasColumnName("total_copies")
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(b => b.CopiesInUse)
                .HasColumnName("copies_in_use")
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(b => b.Type)
                .HasColumnName("type")
                .HasColumnType("varchar(50)")
                .IsRequired(false);

            builder.Property(b => b.Isbn)
                .HasColumnName("isbn")
                .HasColumnType("varchar(80)")
                .IsRequired(false);

            builder.Property(b => b.Category)
                .HasColumnName("category")
                .HasColumnType("varchar(50)")
                .IsRequired(false);
        }
    }
}
