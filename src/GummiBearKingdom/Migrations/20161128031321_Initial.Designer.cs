using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Migrations
{
    [DbContext(typeof(GummiBearKingdomContext))]
    [Migration("20161128031321_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GummiBearKingdom.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<int?>("ProductsId");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.HasKey("BlogId");

                    b.HasIndex("ProductsId");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("GummiBearKingdom.Models.Product", b =>
                {
                    b.Property<int>("ProductsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Coo");

                    b.Property<int>("Cost");

                    b.Property<string>("Name");

                    b.HasKey("ProductsId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GummiBearKingdom.Models.Blog", b =>
                {
                    b.HasOne("GummiBearKingdom.Models.Product")
                        .WithMany("Blogs")
                        .HasForeignKey("ProductsId");
                });
        }
    }
}
