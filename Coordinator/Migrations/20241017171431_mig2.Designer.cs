﻿// <auto-generated />
using System;
using Coordinator.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Coordinator.Migrations
{
    [DbContext(typeof(TwoPhaseCommitContext))]
    [Migration("20241017171431_mig2")]
    partial class mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Coordinator.Models.Node", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nodes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1bae95e2-ee98-47bf-bd02-74c5c3edeee6"),
                            Name = "Order.API"
                        },
                        new
                        {
                            Id = new Guid("604d36ae-05ba-48ab-b844-ce90cb10f71a"),
                            Name = "Stock.API"
                        },
                        new
                        {
                            Id = new Guid("f057a96f-969d-4f23-a2e7-4e6dffca0202"),
                            Name = "Payment.API"
                        });
                });

            modelBuilder.Entity("Coordinator.Models.NodeState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsReady")
                        .HasColumnType("int");

                    b.Property<Guid>("NodeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TransactionState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.ToTable("NodeStates");
                });

            modelBuilder.Entity("Coordinator.Models.NodeState", b =>
                {
                    b.HasOne("Coordinator.Models.Node", "Node")
                        .WithMany("NodeStates")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Node");
                });

            modelBuilder.Entity("Coordinator.Models.Node", b =>
                {
                    b.Navigation("NodeStates");
                });
#pragma warning restore 612, 618
        }
    }
}
