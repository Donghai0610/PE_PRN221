using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Q2.Models
{
	public partial class PE_PRN221_Fall23B5Context : DbContext
	{
		public PE_PRN221_Fall23B5Context()
		{
		}

		public PE_PRN221_Fall23B5Context(DbContextOptions<PE_PRN221_Fall23B5Context> options)
			: base(options)
		{
		}

		public virtual DbSet<Department> Departments { get; set; } = null!;
		public virtual DbSet<Instructor> Instructors { get; set; } = null!;
		public virtual DbSet<Major> Majors { get; set; } = null!;
		public virtual DbSet<Student> Students { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder()
							   .SetBasePath(Directory.GetCurrentDirectory())
							   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			IConfigurationRoot configuration = builder.Build();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Department>(entity =>
			{
				entity.HasNoKey();

				entity.ToTable("Department");

				entity.Property(e => e.DepartmentId).ValueGeneratedOnAdd();

				entity.Property(e => e.DepartmentName).HasMaxLength(100);
			});

			modelBuilder.Entity<Instructor>(entity =>
			{
				entity.HasNoKey();

				entity.ToTable("Instructor");

				entity.Property(e => e.ContractDate).HasColumnType("date");

				entity.Property(e => e.Fullname).HasMaxLength(200);

				entity.Property(e => e.InstructorId).ValueGeneratedOnAdd();
			});

			modelBuilder.Entity<Major>(entity =>
			{
				entity.HasNoKey();

				entity.ToTable("Major");

				entity.Property(e => e.MajorCode)
					.HasMaxLength(2)
					.IsUnicode(false);

				entity.Property(e => e.MajorName)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Student>(entity =>
			{
				entity.HasNoKey();

				entity.ToTable("Student");

				entity.Property(e => e.Dob).HasColumnType("date");

				entity.Property(e => e.FullName).HasMaxLength(200);

				entity.Property(e => e.Major)
					.HasMaxLength(2)
					.IsUnicode(false);

				entity.Property(e => e.StudentId).ValueGeneratedOnAdd();
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
