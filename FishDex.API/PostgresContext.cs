using Microsoft.EntityFrameworkCore;

namespace FishDex.API;

public partial class PostgresContext(DbContextOptions<PostgresContext> options) : DbContext(options)
{
    public virtual DbSet<FishDTO> Fish { get; set; }

    public virtual DbSet<LocationDTO> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_catalog", "azure")
            .HasPostgresExtension("pg_catalog", "pgaadauth");

        modelBuilder.Entity<FishDTO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fish_pkey");

            entity.ToTable("fish");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Caught)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("caught");
            entity.Property(e => e.Length)
                .HasPrecision(10, 2)
                .HasColumnName("length");
            entity.Property(e => e.Lid).HasColumnName("lid");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasMaxLength(200)
                .HasColumnName("notes");
            entity.Property(e => e.Weight)
                .HasPrecision(10, 2)
                .HasColumnName("weight");

            entity.HasOne(d => d.LidNavigation).WithMany(p => p.Fish)
                .HasForeignKey(d => d.Lid)
                .HasConstraintName("fish_lid_fkey");
        });

        modelBuilder.Entity<LocationDTO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("location_pkey");

            entity.ToTable("location");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.County)
                .HasMaxLength(50)
                .HasColumnName("county");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
