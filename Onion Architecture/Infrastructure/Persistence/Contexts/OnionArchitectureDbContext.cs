using System;
using System.Collections.Generic;
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public partial class OnionArchitectureDbContext : DbContext
{
    public OnionArchitectureDbContext()
    {
    }

    public OnionArchitectureDbContext(DbContextOptions<OnionArchitectureDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
           => optionsBuilder.UseNpgsql(Configuration.PostgreSQLConnectionString);

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var P = ChangeTracker.Entries<Product>();

        foreach (var entry in P)
        {
            if (entry.Entity is Product entity)
            {
                if (entry.State == EntityState.Added)
                {
                    entity.Id = Guid.NewGuid();
                    entity.Createdate = DateTime.UtcNow;
                }


                if (entry.State == EntityState.Modified)
                {
                    entry.State = EntityState.Modified;
                    entity.Updatedate = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Deleted;
                    entity.Deletedate = DateTime.UtcNow;
                }
            }
        }

        var C = ChangeTracker.Entries<Customer>();

        foreach (var entry in C)
        {
            if (entry.Entity is Customer entity)
            {
                if (entry.State == EntityState.Added)
                {
                    entity.Id = Guid.NewGuid();
                    entity.Createdate = DateTime.UtcNow;
                }


                if (entry.State == EntityState.Modified)
                {
                    entry.State = EntityState.Modified;
                    entity.Updatedate = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Deleted;
                    entity.Deletedate = DateTime.UtcNow;
                }
            }
        }

        var O = ChangeTracker.Entries<Order>();

        foreach (var entry in O)
        {
            if (entry.Entity is Order entity)
            {
                if (entry.State == EntityState.Added)
                {
                    entity.Id = Guid.NewGuid();
                    entity.Createdate = DateTime.UtcNow;
                }


                if (entry.State == EntityState.Modified)
                {
                    entry.State = EntityState.Modified;
                    entity.Updatedate = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Deleted;
                    entity.Deletedate = DateTime.UtcNow;
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Customer_pkey");

            entity.ToTable("Customer");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Createdate).HasColumnName("createdate");
            entity.Property(e => e.Deletedate).HasColumnName("deletedate");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Updatedate).HasColumnName("updatedate");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Order_pkey");

            entity.ToTable("Order");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Createdate).HasColumnName("createdate");
            entity.Property(e => e.CustomeridFororder).HasColumnName("customerid_fororder");
            entity.Property(e => e.Deletedate).HasColumnName("deletedate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ProductidFororder).HasColumnName("productid_fororder");
            entity.Property(e => e.Updatedate).HasColumnName("updatedate");

            entity.HasOne(d => d.CustomeridFororderNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomeridFororder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customerid_fororder");

            entity.HasOne(d => d.ProductidFororderNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductidFororder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_productid_fororder");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Product_pkey");

            entity.ToTable("Product");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Createdate).HasColumnName("createdate");
            entity.Property(e => e.Deletedate).HasColumnName("deletedate");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Updatedate).HasColumnName("updatedate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
