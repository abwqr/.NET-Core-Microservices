using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tutoroo.Models;

public partial class HmsContext : DbContext
{
    public HmsContext()
    {
    }

    public HmsContext(DbContextOptions<HmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Bed> Beds { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employeerecord> Employeerecords { get; set; }

    public virtual DbSet<Empschedule> Empschedules { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=abdullah;database=hms", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PRIMARY");

            entity.ToTable("appointment");

            entity.HasIndex(e => e.DoctorId, "fk_3");

            entity.HasIndex(e => e.PatientCnic, "fk_4");

            entity.Property(e => e.AppointmentId)
                .ValueGeneratedNever()
                .HasColumnName("appointmentID");
            entity.Property(e => e.AppointmentDate).HasColumnName("appointmentDate");
            entity.Property(e => e.AppointmentTime)
                .HasColumnType("time")
                .HasColumnName("appointmentTime");
            entity.Property(e => e.DoctorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("doctorID");
            entity.Property(e => e.FeeAmount).HasColumnName("feeAmount");
            entity.Property(e => e.PatientCnic).HasColumnName("patientCNIC");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasColumnName("status");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_3");

            entity.HasOne(d => d.PatientCnicNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientCnic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_4");
        });

        modelBuilder.Entity<Bed>(entity =>
        {
            entity.HasKey(e => e.BedId).HasName("PRIMARY");

            entity.ToTable("bed");

            entity.HasIndex(e => e.PatientCnic, "fk_5");

            entity.Property(e => e.BedId).HasColumnName("bedId");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.FeeAmount).HasColumnName("feeAmount");
            entity.Property(e => e.PatientCnic).HasColumnName("patientCNIC");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasColumnName("status");

            entity.HasOne(d => d.PatientCnicNavigation).WithMany(p => p.Beds)
                .HasForeignKey(d => d.PatientCnic)
                .HasConstraintName("fk_5");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.Property(e => e.EmpId).HasColumnName("empID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Employeerecord>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PRIMARY");

            entity.ToTable("employeerecord");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("empID");
            entity.Property(e => e.HireDate).HasColumnName("hireDate");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Salary).HasColumnName("salary");

            entity.HasOne(d => d.Emp).WithOne(p => p.Employeerecord)
                .HasForeignKey<Employeerecord>(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_6");
        });

        modelBuilder.Entity<Empschedule>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PRIMARY");

            entity.ToTable("empschedule");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("empID");
            entity.Property(e => e.EndTime)
                .HasColumnType("time")
                .HasColumnName("endTime");
            entity.Property(e => e.Room)
                .HasMaxLength(5)
                .HasColumnName("room");
            entity.Property(e => e.ShiftDate).HasColumnName("shiftDate");
            entity.Property(e => e.StartTime)
                .HasColumnType("time")
                .HasColumnName("startTime");

            entity.HasOne(d => d.Emp).WithOne(p => p.Empschedule)
                .HasForeignKey<Empschedule>(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_7");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientCnic).HasName("PRIMARY");

            entity.ToTable("patient");

            entity.Property(e => e.PatientCnic)
                .ValueGeneratedNever()
                .HasColumnName("patientCNIC");
            entity.Property(e => e.PatientFirstName)
                .HasMaxLength(20)
                .HasColumnName("patientFirstName");
            entity.Property(e => e.PatientLastName)
                .HasMaxLength(20)
                .HasColumnName("patientLastName");
            entity.Property(e => e.PatientPhoneNumber)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("patientPhoneNumber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
