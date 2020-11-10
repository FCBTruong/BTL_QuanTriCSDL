using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BTL_QTCSDL_Backend_Mysql.Models.DBModels
{
    public partial class btl_quantricsdlContext : DbContext
    {
        public btl_quantricsdlContext()
        {
        }

        public btl_quantricsdlContext(DbContextOptions<btl_quantricsdlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Weapons> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3307;user=root;password=huytruong9112k;database=btl_quantricsdl", x => x.ServerVersion("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weapons>(entity =>
            {
                entity.HasKey(e => e.WeaponId)
                    .HasName("PRIMARY");

                entity.ToTable("weapons");

                entity.Property(e => e.WeaponId)
                    .HasColumnName("weapon_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.WeaponName)
                    .HasColumnName("weapon_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
