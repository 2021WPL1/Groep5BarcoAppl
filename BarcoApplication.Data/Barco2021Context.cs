﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualBasic;

namespace BarcoApplicatie.BibModels
{
    public partial class Barco2021Context : DbContext
    {
        public Barco2021Context()
        {
        }

        public Barco2021Context(DbContextOptions<Barco2021Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Eut> Eut { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<RqBarcoDivision> RqBarcoDivision { get; set; }
        public virtual DbSet<RqBarcoDivisionPerson> RqBarcoDivisionPerson { get; set; }
        public virtual DbSet<RqJobNature> RqJobNature { get; set; }
        public virtual DbSet<RqOptionel> RqOptionel { get; set; }
        public virtual DbSet<RqRequest> RqRequest { get; set; }
        public virtual DbSet<RqRequestDetail> RqRequestDetail { get; set; }
        public virtual DbSet<RqTestDevision> RqTestDevision { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                object p = optionsBuilder.UseSqlServer(Constants.CONNECTION_STRING);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eut>(entity =>
            {
                entity.ToTable("EUT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvailableDate)
                    .HasColumnName("available_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdRqDetail).HasColumnName("id_rq_detail");

                entity.Property(e => e.OmschrijvingEut)
                    .HasColumnName("omschrijvingEUT")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdRqDetailNavigation)
                    .WithMany(p => p.Eut)
                    .HasForeignKey(d => d.IdRqDetail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EUT_Rq_RequestDetail_FK");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Afkorting)
                    .HasName("PersonTbl_PK");

                entity.Property(e => e.Afkorting).HasMaxLength(10);

                entity.Property(e => e.Familienaam).HasMaxLength(50);

                entity.Property(e => e.Voornaam).HasMaxLength(50);
            });

            modelBuilder.Entity<RqBarcoDivision>(entity =>
            {
                entity.HasKey(e => e.Afkorting)
                    .HasName("BarcoDivision");

                entity.ToTable("Rq_BarcoDivision");

                entity.Property(e => e.Afkorting)
                    .HasColumnName("afkorting")
                    .HasMaxLength(50);

                entity.Property(e => e.Actief).HasColumnName("actief");

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RqBarcoDivisionPerson>(entity =>
            {
                entity.ToTable("Rq_BarcoDivisionPerson");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AfkDevision)
                    .IsRequired()
                    .HasColumnName("afkDevision")
                    .HasMaxLength(50);

                entity.Property(e => e.AfkPerson)
                    .IsRequired()
                    .HasColumnName("afkPerson")
                    .HasMaxLength(10);

                entity.Property(e => e.Pvggroup)
                    .IsRequired()
                    .HasColumnName("PVGGroup")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<RqJobNature>(entity =>
            {
                entity.HasKey(e => e.Nature)
                    .HasName("JobNature_PK");

                entity.ToTable("Rq_JobNature");

                entity.Property(e => e.Nature)
                    .HasColumnName("nature")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<RqOptionel>(entity =>
            {
                entity.ToTable("Rq_Optionel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdRequest).HasColumnName("id_request");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(500);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IdRequestNavigation)
                    .WithMany(p => p.RqOptionel)
                    .HasForeignKey(d => d.IdRequest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rq_Optionel_Rq_Request_FK");
            });

            modelBuilder.Entity<RqRequest>(entity =>
            {
                entity.HasKey(e => e.IdRequest)
                    .HasName("RequestTbl_PK");

                entity.ToTable("Rq_Request");

                entity.Property(e => e.IdRequest).HasColumnName("id_request");

                entity.Property(e => e.BarcoDivision)
                    .IsRequired()
                    .HasColumnName("barcoDivision")
                    .HasMaxLength(25)
                    .HasComment("uit keuzelijst");

                entity.Property(e => e.Battery).HasColumnName("battery");

                entity.Property(e => e.EutPartnumbers)
                    .IsRequired()
                    .HasColumnName("EUT_Partnumbers")
                    .HasMaxLength(500);

                entity.Property(e => e.EutProjectname)
                    .IsRequired()
                    .HasColumnName("EUT_Projectname")
                    .HasMaxLength(100);

                entity.Property(e => e.ExpectedEnddate)
                    .HasColumnName("expectedEnddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GrossWeight)
                    .IsRequired()
                    .HasColumnName("grossWeight")
                    .HasMaxLength(200);

                entity.Property(e => e.HydraProjectNr)
                    .IsRequired()
                    .HasColumnName("hydraProjectNr")
                    .HasMaxLength(15);

                entity.Property(e => e.JobNature)
                    .IsRequired()
                    .HasColumnName("jobNature")
                    .HasMaxLength(30);

                entity.Property(e => e.JrNumber)
                    .HasColumnName("JR_Number")
                    .HasMaxLength(10);

                entity.Property(e => e.JrStatus)
                    .HasColumnName("JR_Status")
                    .HasMaxLength(30);

                entity.Property(e => e.NetWeight)
                    .IsRequired()
                    .HasColumnName("netWeight")
                    .HasMaxLength(200);

                entity.Property(e => e.RequestDate)
                    .HasColumnName("request_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Requester)
                    .IsRequired()
                    .HasColumnName("requester")
                    .HasMaxLength(10)
                    .HasComment("initialen");
            });

            modelBuilder.Entity<RqRequestDetail>(entity =>
            {
                entity.HasKey(e => e.IdRqDetail)
                    .HasName("NatureOfTest_PK");

                entity.ToTable("Rq_RequestDetail");

                entity.Property(e => e.IdRqDetail).HasColumnName("id_rq_detail");

                entity.Property(e => e.IdRequest).HasColumnName("id_request");

                entity.Property(e => e.Pvgresp)
                    .HasColumnName("PVGresp")
                    .HasMaxLength(30);

                entity.Property(e => e.Testdivisie)
                    .IsRequired()
                    .HasColumnName("testdivisie")
                    .HasMaxLength(4);

                entity.HasOne(d => d.IdRequestNavigation)
                    .WithMany(p => p.RqRequestDetail)
                    .HasForeignKey(d => d.IdRequest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rq_RequestDetail_Rq_Request_FK");

                entity.HasOne(d => d.TestdivisieNavigation)
                    .WithMany(p => p.RqRequestDetail)
                    .HasForeignKey(d => d.Testdivisie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rq_RequestDetail_Rq_TestDevision_FK");
            });

            modelBuilder.Entity<RqTestDevision>(entity =>
            {
                entity.HasKey(e => e.Afkorting)
                    .HasName("Test_Devisionv1_PK");

                entity.ToTable("Rq_TestDevision");

                entity.Property(e => e.Afkorting)
                    .HasColumnName("afkorting")
                    .HasMaxLength(4);

                entity.Property(e => e.Naam)
                    .HasColumnName("naam")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
