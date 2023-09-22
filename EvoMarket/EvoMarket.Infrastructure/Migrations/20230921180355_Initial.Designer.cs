﻿// <auto-generated />
using System;
using EvoMarket.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EvoMarket.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230921180355_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Auth.Device", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("DeviceName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("device_name");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ip");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_login_date");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("devices");
                });

            modelBuilder.Entity("Domain.Entities.Auth.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ClinetId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("expire_date");

                    b.Property<string>("Otp")
                        .HasColumnType("text")
                        .HasColumnName("otp");

                    b.Property<string>("PasswordHashString")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash_string");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Domain.Entities.Notification.ClientNotifications", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("MessageData")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("message_data");

                    b.Property<bool>("Received")
                        .HasColumnType("boolean")
                        .HasColumnName("received");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.HasKey("Id");

                    b.HasIndex("Received");

                    b.ToTable("client_notifications");
                });

            modelBuilder.Entity("Domain.Entities.Payment.ClientAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric")
                        .HasColumnName("balance");

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint")
                        .HasColumnName("client_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsFreeze")
                        .HasColumnType("boolean")
                        .HasColumnName("is_freeze");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("client_account", "payment");
                });

            modelBuilder.Entity("Domain.Entities.Payment.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint")
                        .HasColumnName("account_id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("Success")
                        .HasColumnType("boolean")
                        .HasColumnName("success");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("date_time");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("transactions", "payment");
                });

            modelBuilder.Entity("Domain.Entities.Shops.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint")
                        .HasColumnName("client_id");

                    b.Property<bool>("Closed")
                        .HasColumnType("boolean")
                        .HasColumnName("closed");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("TotalCount")
                        .HasColumnType("integer")
                        .HasColumnName("total_count");

                    b.Property<decimal>("TotalEmount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_emount");

                    b.Property<long>("TransactionId")
                        .HasColumnType("bigint")
                        .HasColumnName("transaction_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("carts", "shop");
                });

            modelBuilder.Entity("Domain.Entities.Shops.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("categories", "shop");
                });

            modelBuilder.Entity("Domain.Entities.Shops.CategoryFilter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    b.Property<long>("FilterParamId")
                        .HasColumnType("bigint");

                    b.Property<long>("FilterPramId")
                        .HasColumnType("bigint")
                        .HasColumnName("filter_param_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FilterParamId");

                    b.ToTable("category_filters", "shop");
                });

            modelBuilder.Entity("Domain.Entities.Shops.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Address");

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("text")
                        .HasColumnName("profile_image");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision")
                        .HasColumnName("rate");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("clients", "shop");
                });

            modelBuilder.Entity("Domain.Entities.Shops.FilterParam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CategoryFilterId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("CategoryFilterId");

                    b.HasIndex("CategoryId");

                    b.ToTable("filter_params", "shop");
                });

            modelBuilder.Entity("Domain.Entities.Shops.FilterParamValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("FilterParamId")
                        .HasColumnType("bigint")
                        .HasColumnName("filter_param_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("FilterParamId");

                    b.ToTable("filter_param_values", "shop");
                });

            modelBuilder.Entity("Domain.Entities.Shops.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<long?>("CategoryId1")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<decimal?>("DiscountPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("discount_price");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<int>("MinAge")
                        .HasColumnType("integer")
                        .HasColumnName("min_age");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<float>("Quantity")
                        .HasColumnType("real")
                        .HasColumnName("quantity");

                    b.Property<float>("Rate")
                        .HasColumnType("real")
                        .HasColumnName("rate");

                    b.Property<string>("ThumbImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("thumb_image_url");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId1");

                    b.ToTable("products", "shop");
                });

            modelBuilder.Entity("Domain.Entities.Payment.ClientAccount", b =>
                {
                    b.HasOne("Domain.Entities.Shops.Client", "Client")
                        .WithMany("ClientAccounts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Domain.Entities.Payment.Transaction", b =>
                {
                    b.HasOne("Domain.Entities.Payment.ClientAccount", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Entities.Shops.CategoryFilter", b =>
                {
                    b.HasOne("Domain.Entities.Shops.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Shops.FilterParam", "FilterParam")
                        .WithMany()
                        .HasForeignKey("FilterParamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("FilterParam");
                });

            modelBuilder.Entity("Domain.Entities.Shops.FilterParam", b =>
                {
                    b.HasOne("Domain.Entities.Shops.CategoryFilter", null)
                        .WithMany("FilterParams")
                        .HasForeignKey("CategoryFilterId");

                    b.HasOne("Domain.Entities.Shops.Category", null)
                        .WithMany("FilterParams")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Domain.Entities.Shops.FilterParamValue", b =>
                {
                    b.HasOne("Domain.Entities.Shops.FilterParam", "FilterParam")
                        .WithMany("FilterParamValues")
                        .HasForeignKey("FilterParamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilterParam");
                });

            modelBuilder.Entity("Domain.Entities.Shops.Product", b =>
                {
                    b.HasOne("Domain.Entities.Shops.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId1");
                });

            modelBuilder.Entity("Domain.Entities.Payment.ClientAccount", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Domain.Entities.Shops.Category", b =>
                {
                    b.Navigation("FilterParams");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Entities.Shops.CategoryFilter", b =>
                {
                    b.Navigation("FilterParams");
                });

            modelBuilder.Entity("Domain.Entities.Shops.Client", b =>
                {
                    b.Navigation("ClientAccounts");
                });

            modelBuilder.Entity("Domain.Entities.Shops.FilterParam", b =>
                {
                    b.Navigation("FilterParamValues");
                });
#pragma warning restore 612, 618
        }
    }
}