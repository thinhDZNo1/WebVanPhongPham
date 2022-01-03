﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VanPhongPhamDTO.EntityFramework;

namespace VanPhongPhamDTO.Migrations
{
    [DbContext(typeof(VanPhongPhamContext))]
    [Migration("20210703012107_migration_v1")]
    partial class migration_v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VanPhongPhamDTO.Entities.About", b =>
                {
                    b.Property<int>("AB_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company_PN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("AB_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("About");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Categories", b =>
                {
                    b.Property<int>("Category_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Category_Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Category_Detail", b =>
                {
                    b.Property<int>("CD_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CD_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CD_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.HasKey("CD_Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("Category_Detail");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Target")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.News", b =>
                {
                    b.Property<int>("New_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("New_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("New_Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Order", b =>
                {
                    b.Property<int>("Order_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOrder")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Order_ID");

                    b.HasIndex("User_Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Order_ID")
                        .HasColumnType("int");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Order_ID");

                    b.HasIndex("Product_Id");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Producer", b =>
                {
                    b.Property<int>("Producer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Producer_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer_Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Producer_Id");

                    b.ToTable("Producer");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Products", b =>
                {
                    b.Property<int>("Product_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CD_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NewPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Producer_Id")
                        .HasColumnType("int");

                    b.Property<string>("Product_Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Product_Id");

                    b.HasIndex("CD_Id");

                    b.HasIndex("Producer_Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Promotion", b =>
                {
                    b.Property<int>("Promotion_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Category_DetailCD_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Promotion_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start_Day")
                        .HasColumnType("datetime2");

                    b.HasKey("Promotion_Id");

                    b.HasIndex("Category_DetailCD_Id");

                    b.ToTable("Promotion");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Regulations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Regulations");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Slider", b =>
                {
                    b.Property<int>("SLider_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SLider_Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slider_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SLider_Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Users", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("isActive")
                        .HasColumnType("int");

                    b.HasKey("User_Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Voucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<int>("Promotion_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Product_Id");

                    b.HasIndex("Promotion_Id");

                    b.ToTable("Voucher");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.About", b =>
                {
                    b.HasOne("VanPhongPhamDTO.Entities.Users", "Users")
                        .WithMany("About")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Category_Detail", b =>
                {
                    b.HasOne("VanPhongPhamDTO.Entities.Categories", "Categories")
                        .WithMany("Category_Detail")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Order", b =>
                {
                    b.HasOne("VanPhongPhamDTO.Entities.Users", "Users")
                        .WithMany("Order")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.OrderDetail", b =>
                {
                    b.HasOne("VanPhongPhamDTO.Entities.Order", "Order")
                        .WithMany("OrderDetail")
                        .HasForeignKey("Order_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VanPhongPhamDTO.Entities.Products", "Products")
                        .WithMany("Order")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Products", b =>
                {
                    b.HasOne("VanPhongPhamDTO.Entities.Category_Detail", "Category_Detail")
                        .WithMany("Products")
                        .HasForeignKey("CD_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VanPhongPhamDTO.Entities.Producer", "Producer")
                        .WithMany("Products")
                        .HasForeignKey("Producer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category_Detail");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Promotion", b =>
                {
                    b.HasOne("VanPhongPhamDTO.Entities.Category_Detail", null)
                        .WithMany("Promotion")
                        .HasForeignKey("Category_DetailCD_Id");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Regulations", b =>
                {
                    b.HasOne("VanPhongPhamDTO.Entities.Users", "Users")
                        .WithMany("Regulations")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Voucher", b =>
                {
                    b.HasOne("VanPhongPhamDTO.Entities.Products", "Products")
                        .WithMany("Voucher")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VanPhongPhamDTO.Entities.Promotion", "Promotion")
                        .WithMany("Voucher")
                        .HasForeignKey("Promotion_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Categories", b =>
                {
                    b.Navigation("Category_Detail");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Category_Detail", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Order", b =>
                {
                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Producer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Products", b =>
                {
                    b.Navigation("Order");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Promotion", b =>
                {
                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("VanPhongPhamDTO.Entities.Users", b =>
                {
                    b.Navigation("About");

                    b.Navigation("Order");

                    b.Navigation("Regulations");
                });
#pragma warning restore 612, 618
        }
    }
}
