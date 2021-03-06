﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200419230218_AddCandiesToDB")]
    partial class AddCandiesToDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Entities.Client", b =>
                {
                    b.Property<int>("idClient")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasMaxLength(200);

                    b.Property<string>("coordinate")
                        .HasMaxLength(200);

                    b.Property<string>("email")
                        .HasMaxLength(100);

                    b.Property<int>("idPerson");

                    b.Property<string>("name")
                        .HasMaxLength(50);

                    b.Property<string>("nit")
                        .HasMaxLength(10);

                    b.Property<bool>("state");

                    b.Property<string>("urlPage")
                        .HasMaxLength(500);

                    b.Property<bool>("wholesaler");

                    b.HasKey("idClient");

                    b.HasIndex("idPerson");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("WebApi.Entities.ClientMachine", b =>
                {
                    b.Property<int>("idClientMachine")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateAssignment");

                    b.Property<int>("idClient");

                    b.Property<int>("idMachine");

                    b.Property<bool>("state");

                    b.HasKey("idClientMachine");

                    b.HasIndex("idClient");

                    b.HasIndex("idMachine");

                    b.ToTable("ClientMachine");
                });

            modelBuilder.Entity("WebApi.Entities.Machine", b =>
                {
                    b.Property<int>("idMachine")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("capacity");

                    b.Property<int>("idStatusMachine");

                    b.HasKey("idMachine");

                    b.HasIndex("idStatusMachine");

                    b.ToTable("Machine");
                });

            modelBuilder.Entity("WebApi.Entities.Notification", b =>
                {
                    b.Property<int>("idNotification")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date");

                    b.Property<int>("idClient");

                    b.Property<int>("idStatusMachine");

                    b.Property<int>("idUser");

                    b.Property<float>("totalSales");

                    b.HasKey("idNotification");

                    b.HasIndex("idClient");

                    b.HasIndex("idStatusMachine");

                    b.HasIndex("idUser");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("WebApi.Entities.OperationProductEntry", b =>
                {
                    b.Property<int>("idOperationEntry")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateOperation");

                    b.Property<DateTime>("dateOperationEntry");

                    b.Property<int>("idProduct");

                    b.Property<int?>("idProvider");

                    b.Property<int>("quantity");

                    b.Property<float>("unitValue");

                    b.HasKey("idOperationEntry");

                    b.HasIndex("idProduct");

                    b.HasIndex("idProvider");

                    b.ToTable("OperationProductEntry");
                });

            modelBuilder.Entity("WebApi.Entities.OperationProductOutput", b =>
                {
                    b.Property<int>("idOperationOutput")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateOperation");

                    b.Property<int>("idClient");

                    b.Property<int?>("idNotification");

                    b.Property<int>("idProducto");

                    b.Property<int>("quantity");

                    b.Property<float>("unitValue");

                    b.HasKey("idOperationOutput");

                    b.HasIndex("idClient");

                    b.HasIndex("idNotification");

                    b.HasIndex("idProducto");

                    b.ToTable("OperationProductOutput");
                });

            modelBuilder.Entity("WebApi.Entities.Page", b =>
                {
                    b.Property<int>("idPage")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasMaxLength(50);

                    b.Property<bool>("state");

                    b.HasKey("idPage");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("WebApi.Entities.Person", b =>
                {
                    b.Property<int>("idPerson")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasMaxLength(200);

                    b.Property<string>("email")
                        .HasMaxLength(100);

                    b.Property<string>("name")
                        .HasMaxLength(100);

                    b.Property<bool>("state");

                    b.Property<string>("telephone")
                        .HasMaxLength(10);

                    b.HasKey("idPerson");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("WebApi.Entities.Product", b =>
                {
                    b.Property<int>("idProduct")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("cost");

                    b.Property<int>("existence");

                    b.Property<int>("idProductType");

                    b.Property<int>("idProvider");

                    b.Property<string>("name")
                        .HasMaxLength(50);

                    b.Property<float>("price");

                    b.Property<bool>("state");

                    b.HasKey("idProduct");

                    b.HasIndex("idProductType");

                    b.HasIndex("idProvider");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("WebApi.Entities.ProductType", b =>
                {
                    b.Property<int>("idProductType")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasMaxLength(50);

                    b.HasKey("idProductType");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("WebApi.Entities.Provider", b =>
                {
                    b.Property<int>("idProvider")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasMaxLength(200);

                    b.Property<string>("email")
                        .HasMaxLength(100);

                    b.Property<string>("nameProvider")
                        .HasMaxLength(100);

                    b.Property<string>("nit")
                        .HasMaxLength(10);

                    b.Property<string>("reason")
                        .HasMaxLength(200);

                    b.Property<bool>("state");

                    b.Property<int>("typeProvider");

                    b.HasKey("idProvider");

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("WebApi.Entities.PurchaseDetail", b =>
                {
                    b.Property<int>("idPurchaseDetail")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idProduct");

                    b.Property<int?>("idPurchaseOrder");

                    b.HasKey("idPurchaseDetail");

                    b.HasIndex("idProduct");

                    b.HasIndex("idPurchaseOrder");

                    b.ToTable("PurchaseDetail");
                });

            modelBuilder.Entity("WebApi.Entities.PurchaseOrder", b =>
                {
                    b.Property<int>("idPurchaseOrder")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("datePurchaseOrder");

                    b.Property<int>("idProvider");

                    b.Property<string>("orderTitle")
                        .HasMaxLength(50);

                    b.Property<float>("purchaseOrderAmount");

                    b.Property<bool>("statusOrder");

                    b.HasKey("idPurchaseOrder");

                    b.HasIndex("idProvider");

                    b.ToTable("PurchaseOrder");
                });

            modelBuilder.Entity("WebApi.Entities.Role", b =>
                {
                    b.Property<int>("idRole")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasMaxLength(50);

                    b.Property<bool>("state");

                    b.HasKey("idRole");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("WebApi.Entities.RolePage", b =>
                {
                    b.Property<int>("idRolePage")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idPage");

                    b.Property<int>("idRole");

                    b.Property<bool>("state");

                    b.HasKey("idRolePage");

                    b.HasIndex("idPage");

                    b.HasIndex("idRole");

                    b.ToTable("RolePage");
                });

            modelBuilder.Entity("WebApi.Entities.StatusMachine", b =>
                {
                    b.Property<int>("idStatusMachine")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasMaxLength(50);

                    b.HasKey("idStatusMachine");

                    b.ToTable("StatusMachine");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("lastName")
                        .HasMaxLength(50);

                    b.Property<string>("name")
                        .HasMaxLength(50);

                    b.Property<byte[]>("passwordHash");

                    b.Property<byte[]>("passwordSalt");

                    b.Property<bool>("state");

                    b.Property<string>("userName")
                        .HasMaxLength(15);

                    b.HasKey("idUser");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApi.Entities.UserRole", b =>
                {
                    b.Property<int>("idUserRole")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idRole");

                    b.Property<int>("idUser");

                    b.Property<bool>("state");

                    b.HasKey("idUserRole");

                    b.HasIndex("idRole");

                    b.HasIndex("idUser");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("WebApi.Entities.Client", b =>
                {
                    b.HasOne("WebApi.Entities.Person", "person")
                        .WithMany()
                        .HasForeignKey("idPerson")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.ClientMachine", b =>
                {
                    b.HasOne("WebApi.Entities.Client", "client")
                        .WithMany()
                        .HasForeignKey("idClient")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.Machine", "machine")
                        .WithMany()
                        .HasForeignKey("idMachine")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.Machine", b =>
                {
                    b.HasOne("WebApi.Entities.StatusMachine", "statusMachine")
                        .WithMany()
                        .HasForeignKey("idStatusMachine")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.Notification", b =>
                {
                    b.HasOne("WebApi.Entities.Client", "client")
                        .WithMany()
                        .HasForeignKey("idClient")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.StatusMachine", "statusMachine")
                        .WithMany()
                        .HasForeignKey("idStatusMachine")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.OperationProductEntry", b =>
                {
                    b.HasOne("WebApi.Entities.Product", "product")
                        .WithMany()
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.Provider", "provider")
                        .WithMany()
                        .HasForeignKey("idProvider");
                });

            modelBuilder.Entity("WebApi.Entities.OperationProductOutput", b =>
                {
                    b.HasOne("WebApi.Entities.Client", "client")
                        .WithMany()
                        .HasForeignKey("idClient")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.Notification", "notification")
                        .WithMany()
                        .HasForeignKey("idNotification");

                    b.HasOne("WebApi.Entities.Product", "product")
                        .WithMany()
                        .HasForeignKey("idProducto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.Product", b =>
                {
                    b.HasOne("WebApi.Entities.ProductType", "productType")
                        .WithMany()
                        .HasForeignKey("idProductType")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.Provider", "provider")
                        .WithMany()
                        .HasForeignKey("idProvider")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.PurchaseDetail", b =>
                {
                    b.HasOne("WebApi.Entities.Product", "product")
                        .WithMany()
                        .HasForeignKey("idProduct")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.PurchaseOrder", "purchaseOrderFK")
                        .WithMany()
                        .HasForeignKey("idPurchaseOrder");
                });

            modelBuilder.Entity("WebApi.Entities.PurchaseOrder", b =>
                {
                    b.HasOne("WebApi.Entities.Provider", "provider")
                        .WithMany()
                        .HasForeignKey("idProvider")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.RolePage", b =>
                {
                    b.HasOne("WebApi.Entities.Page", "page")
                        .WithMany()
                        .HasForeignKey("idPage")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.Role", "role")
                        .WithMany()
                        .HasForeignKey("idRole")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.UserRole", b =>
                {
                    b.HasOne("WebApi.Entities.Role", "role")
                        .WithMany()
                        .HasForeignKey("idRole")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
