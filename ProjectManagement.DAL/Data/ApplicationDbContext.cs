using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.DAL.Models;

namespace ProjectManagement.DAL.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectEmployee> ProjectEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasOne(d => d.Project).WithMany(p => p.Documents)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(e => e.EndDate).HasColumnType("DATE");
            entity.Property(e => e.StartDate).HasColumnType("DATE");

            entity.HasOne(d => d.ClientCompany).WithMany(p => p.ProjectClientCompanies).HasForeignKey(d => d.ClientCompanyId);

            entity.HasOne(d => d.ContractorCompany).WithMany(p => p.ProjectContractorCompanies).HasForeignKey(d => d.ContractorCompanyId);

            entity.HasOne(d => d.ProjectLeader).WithMany(p => p.Projects).HasForeignKey(d => d.ProjectLeaderId);
        });

        modelBuilder.Entity<ProjectEmployee>(entity =>
        {
            entity.HasOne(d => d.Employee).WithMany(p => p.ProjectEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectEmployees)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
