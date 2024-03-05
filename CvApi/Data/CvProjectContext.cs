using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CvApi.Models;

namespace CvApi.Data;

public partial class CvProjectContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public CvProjectContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public virtual DbSet<Certification> Certifications { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Social> Socials { get; set; }

    public virtual DbSet<Strength> Strengths { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseNpgsql(Configuration.GetConnectionString("CVSource"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("certification_pkey");

            entity.ToTable("Certification");

            entity.Property(e => e.Id)
                .HasIdentityOptions(null, null, null, 99999L, null, null)
                .HasColumnName("id");
            entity.Property(e => e.CertificationName)
                .HasColumnType("character varying")
                .HasColumnName("certificationName");
            entity.Property(e => e.CredentialId)
                .HasColumnType("character varying")
                .HasColumnName("credentialId");
            entity.Property(e => e.CredentialLink)
                .HasColumnType("character varying")
                .HasColumnName("credentialLink");
            entity.Property(e => e.EarnedDate).HasColumnName("earnedDate");
            entity.Property(e => e.IssuedBy)
                .HasColumnType("character varying")
                .HasColumnName("issuedBy");
            entity.Property(e => e.ProfileId).HasColumnName("profileId");

            entity.HasOne(d => d.Profile).WithMany(p => p.Certifications)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("certification_profileId_fkey");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("education_pkey");

            entity.ToTable("Education");

            entity.Property(e => e.Id)
                .HasIdentityOptions(null, null, null, 99999L, null, null)
                .HasColumnName("id");
            entity.Property(e => e.Degree)
                .HasColumnType("character varying")
                .HasColumnName("degree");
            entity.Property(e => e.EndYear).HasColumnName("endYear");
            entity.Property(e => e.Institution)
                .HasColumnType("character varying")
                .HasColumnName("institution");
            entity.Property(e => e.ProfileId).HasColumnName("profileId");
            entity.Property(e => e.StartYear).HasColumnName("startYear");

            entity.HasOne(d => d.Profile).WithMany(p => p.Educations)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("education_profileId_fkey");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("experience_pkey");

            entity.ToTable("Experience");

            entity.Property(e => e.Id)
                .HasIdentityOptions(null, null, null, 99999L, null, null)
                .HasColumnName("id");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.ProfileId).HasColumnName("profileId");
            entity.Property(e => e.Role)
                .HasColumnType("character varying")
                .HasColumnName("role");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.Workplace)
                .HasColumnType("character varying")
                .HasColumnName("workplace");

            entity.HasOne(d => d.Profile).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("experience_profileId_fkey");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("profile_pkey");

            entity.ToTable("Profile");

            entity.Property(e => e.Id)
                .HasIdentityOptions(null, null, null, 99999L, null, null)
                .HasColumnName("id");
            entity.Property(e => e.Birth).HasColumnName("birth");
            entity.Property(e => e.Location)
                .HasColumnType("character varying")
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.ProfileText)
                .HasColumnType("character varying")
                .HasColumnName("profileText");
            entity.Property(e => e.Skills)
                .HasColumnType("character varying[]")
                .HasColumnName("skills");
        });

        modelBuilder.Entity<Social>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("social_pkey");

            entity.ToTable("Social");

            entity.Property(e => e.Id)
                .HasIdentityOptions(null, null, null, 99999L, null, null)
                .HasColumnName("id");
            entity.Property(e => e.Icon)
                .HasColumnType("character varying")
                .HasColumnName("icon");
            entity.Property(e => e.Link)
                .HasColumnType("character varying")
                .HasColumnName("link");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.ProfileId).HasColumnName("profileId");

            entity.HasOne(d => d.Profile).WithMany(p => p.Socials)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("social_profileId_fkey");
        });

        modelBuilder.Entity<Strength>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("strength_pkey");

            entity.ToTable("Strength");

            entity.Property(e => e.Id)
                .HasIdentityOptions(null, null, null, 99999L, null, null)
                .HasColumnName("id");
            entity.Property(e => e.Icon)
                .HasColumnType("character varying")
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.ProfileId).HasColumnName("profileId");

            entity.HasOne(d => d.Profile).WithMany(p => p.Strengths)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("strength_profileId_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
