// <auto-generated />
using MicrosWPSShopping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MicrosWPSShopping.ProductApi.Migrations
{
    [DbContext(typeof(SQLContext))]
    partial class SQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MicrosWPSShopping.ProductApi.Model.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Category_name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Image_url");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            Id = 2L,
                            CategoryName = "poder",
                            Description = "Hadouken do kakaroto",
                            ImageUrl = "A imagem que choca",
                            Price = 10m,
                            name = "Hadouken"
                        },
                        new
                        {
                            Id = 3L,
                            CategoryName = "poder",
                            Description = "Hadouken do kakaroto",
                            ImageUrl = "A imagem que choca",
                            Price = 20m,
                            name = "Hadouken2"
                        },
                        new
                        {
                            Id = 4L,
                            CategoryName = "poder",
                            Description = "Hadouken do kakaroto",
                            ImageUrl = "A imagem que choca",
                            Price = 30m,
                            name = "Hadouken4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
