﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportIS.DAL;

#nullable disable

namespace TransportIS.DAL.Migrations
{
    [DbContext(typeof(TransportISDbContext))]
    [Migration("20211126120926_UserRoleTablAdded")]
    partial class UserRoleTablAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConnectionEntityStopEntity", b =>
                {
                    b.Property<Guid>("ConnectionsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StopsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ConnectionsId", "StopsId");

                    b.HasIndex("StopsId");

                    b.ToTable("ConnectionEntityStopEntity");
                });

            modelBuilder.Entity("TransportIS.DAL.CarrierEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarrierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicRelationsContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carriers");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.ConnectionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarrierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReservedSeats")
                        .HasColumnType("int");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.EmploeeConnectionAssigment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConnectionEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConnectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmploeeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ConnectionEntityId");

                    b.HasIndex("ConnectionId");

                    b.HasIndex("EmploeeId");

                    b.ToTable("EmploeeConnectionAssigment");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.EmploeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarrierEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarrierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConnectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrierEntityId");

                    b.HasIndex("CarrierId");

                    b.HasIndex("ConnectionId");

                    b.ToTable("Emploees");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.PassengerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.SeatEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<Guid?>("TicketEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TicketEntityId");

                    b.ToTable("SeatEntity");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.StopEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResponsibleEmploeeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibleEmploeeId");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.TicketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BoardingStopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConfirmingEmploeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConnectionEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DestinationStopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PassangerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TravelClass")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardingStopId");

                    b.HasIndex("ConfirmingEmploeeId");

                    b.HasIndex("ConnectionEntityId");

                    b.HasIndex("DestinationStopId");

                    b.HasIndex("PassangerId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.TimeTableEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConnectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeOfDeparture")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConnectionId");

                    b.HasIndex("StopId");

                    b.ToTable("TimeTables");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.UserRoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("TransportIS.DAL.VehicleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CarrierEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarrierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("VehicleRegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarrierEntityId");

                    b.ToTable("VehicleEntity");
                });

            modelBuilder.Entity("ConnectionEntityStopEntity", b =>
                {
                    b.HasOne("TransportIS.DAL.Entities.ConnectionEntity", null)
                        .WithMany()
                        .HasForeignKey("ConnectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportIS.DAL.Entities.StopEntity", null)
                        .WithMany()
                        .HasForeignKey("StopsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TransportIS.DAL.CarrierEntity", b =>
                {
                    b.OwnsOne("TransportIS.DAL.Entities.AddressEntity", "Address", b1 =>
                        {
                            b1.Property<Guid>("CarrierEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Surname")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CarrierEntityId");

                            b1.ToTable("Carriers");

                            b1.WithOwner()
                                .HasForeignKey("CarrierEntityId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.ConnectionEntity", b =>
                {
                    b.HasOne("TransportIS.DAL.CarrierEntity", "Carrier")
                        .WithMany("Connections")
                        .HasForeignKey("CarrierId");

                    b.HasOne("TransportIS.DAL.VehicleEntity", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("Carrier");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.EmploeeConnectionAssigment", b =>
                {
                    b.HasOne("TransportIS.DAL.Entities.ConnectionEntity", null)
                        .WithMany("Emploees")
                        .HasForeignKey("ConnectionEntityId");

                    b.HasOne("TransportIS.DAL.CarrierEntity", "Connection")
                        .WithMany()
                        .HasForeignKey("ConnectionId");

                    b.HasOne("TransportIS.DAL.Entities.EmploeeEntity", "Emploee")
                        .WithMany("Connections")
                        .HasForeignKey("EmploeeId");

                    b.Navigation("Connection");

                    b.Navigation("Emploee");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.EmploeeEntity", b =>
                {
                    b.HasOne("TransportIS.DAL.CarrierEntity", null)
                        .WithMany("Emploees")
                        .HasForeignKey("CarrierEntityId");

                    b.HasOne("TransportIS.DAL.Entities.ConnectionEntity", "Carried")
                        .WithMany()
                        .HasForeignKey("CarrierId");

                    b.HasOne("TransportIS.DAL.Entities.ConnectionEntity", "Connection")
                        .WithMany()
                        .HasForeignKey("ConnectionId");

                    b.OwnsOne("TransportIS.DAL.Entities.AddressEntity", "Address", b1 =>
                        {
                            b1.Property<Guid>("EmploeeEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Surname")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("EmploeeEntityId");

                            b1.ToTable("Emploees");

                            b1.WithOwner()
                                .HasForeignKey("EmploeeEntityId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Carried");

                    b.Navigation("Connection");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.PassengerEntity", b =>
                {
                    b.OwnsOne("TransportIS.DAL.Entities.AddressEntity", "Address", b1 =>
                        {
                            b1.Property<Guid>("PassengerEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Surname")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PassengerEntityId");

                            b1.ToTable("Passengers");

                            b1.WithOwner()
                                .HasForeignKey("PassengerEntityId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.SeatEntity", b =>
                {
                    b.HasOne("TransportIS.DAL.Entities.TicketEntity", null)
                        .WithMany("SeatNumbers")
                        .HasForeignKey("TicketEntityId");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.StopEntity", b =>
                {
                    b.HasOne("TransportIS.DAL.Entities.EmploeeEntity", "ResponsibleEmploee")
                        .WithMany()
                        .HasForeignKey("ResponsibleEmploeeId");

                    b.Navigation("ResponsibleEmploee");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.TicketEntity", b =>
                {
                    b.HasOne("TransportIS.DAL.Entities.StopEntity", "BoardingStop")
                        .WithMany()
                        .HasForeignKey("BoardingStopId");

                    b.HasOne("TransportIS.DAL.Entities.EmploeeEntity", "ConfirmingEmploee")
                        .WithMany()
                        .HasForeignKey("ConfirmingEmploeeId");

                    b.HasOne("TransportIS.DAL.Entities.ConnectionEntity", null)
                        .WithMany("Tickets")
                        .HasForeignKey("ConnectionEntityId");

                    b.HasOne("TransportIS.DAL.Entities.StopEntity", "DestinationStop")
                        .WithMany()
                        .HasForeignKey("DestinationStopId");

                    b.HasOne("TransportIS.DAL.Entities.PassengerEntity", "Passanger")
                        .WithMany()
                        .HasForeignKey("PassangerId");

                    b.Navigation("BoardingStop");

                    b.Navigation("ConfirmingEmploee");

                    b.Navigation("DestinationStop");

                    b.Navigation("Passanger");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.TimeTableEntity", b =>
                {
                    b.HasOne("TransportIS.DAL.Entities.ConnectionEntity", "Connection")
                        .WithMany()
                        .HasForeignKey("ConnectionId");

                    b.HasOne("TransportIS.DAL.Entities.StopEntity", "Stop")
                        .WithMany()
                        .HasForeignKey("StopId");

                    b.Navigation("Connection");

                    b.Navigation("Stop");
                });

            modelBuilder.Entity("TransportIS.DAL.VehicleEntity", b =>
                {
                    b.HasOne("TransportIS.DAL.CarrierEntity", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("CarrierEntityId");
                });

            modelBuilder.Entity("TransportIS.DAL.CarrierEntity", b =>
                {
                    b.Navigation("Connections");

                    b.Navigation("Emploees");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.ConnectionEntity", b =>
                {
                    b.Navigation("Emploees");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.EmploeeEntity", b =>
                {
                    b.Navigation("Connections");
                });

            modelBuilder.Entity("TransportIS.DAL.Entities.TicketEntity", b =>
                {
                    b.Navigation("SeatNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
