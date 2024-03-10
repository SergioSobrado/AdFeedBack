using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdFeedBack.dto.Models;
using Microsoft.EntityFrameworkCore;

namespace AdFeedBack.data
{
    public class MiDbContext : DbContext
    {
        public MiDbContext(DbContextOptions<MiDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //   {
        //     optionsBuilder.UseSqlServer("tu_cadena_de_conexion");
        //   }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Perfil) // Asume que 'User' tiene una propiedad de navegación 'Perfil'
                .WithOne(p => p.User)  // Asume que 'Perfil' tiene una propiedad de navegación 'User'
                .HasForeignKey<Perfil>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Configura la eliminación en cascada
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Configura la relación muchos a muchos entre User y Rol
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // Seed data para la entidad Role
            modelBuilder.Entity<Role>().HasData(
                                new Role { RoleId = 1, Name = "Admin", Description = "Administrador" },
                                new Role { RoleId = 2, Name = "User", Description = "Usuario" }
                                );
        }
    }
}
