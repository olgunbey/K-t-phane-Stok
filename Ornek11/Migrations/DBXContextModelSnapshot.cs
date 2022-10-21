﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ornek11.Migrations
{
    [DbContext(typeof(DBXContext))]
    partial class DBXContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KitapAciklama", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("KitapAcciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("KitapAciklama");
                });

            modelBuilder.Entity("Kitaplar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("KitapAD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Kitaplar");
                });

            modelBuilder.Entity("KitaplarFiyatOZ", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("KitapFiyat")
                        .HasColumnType("int");

                    b.Property<int>("KitapStok")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("KitaplarFiyatOZ");
                });

            modelBuilder.Entity("KitapAciklama", b =>
                {
                    b.HasOne("Kitaplar", "Kitaplar")
                        .WithOne("KitapAciklama")
                        .HasForeignKey("KitapAciklama", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kitaplar");
                });

            modelBuilder.Entity("KitaplarFiyatOZ", b =>
                {
                    b.HasOne("Kitaplar", "Kitaplar")
                        .WithOne("KitaplarFıyatOZ")
                        .HasForeignKey("KitaplarFiyatOZ", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kitaplar");
                });

            modelBuilder.Entity("Kitaplar", b =>
                {
                    b.Navigation("KitapAciklama")
                        .IsRequired();

                    b.Navigation("KitaplarFıyatOZ")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
