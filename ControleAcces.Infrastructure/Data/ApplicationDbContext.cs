using ControleAcces.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;


namespace ControleAcces.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<HoraireExamen> HoraireExamens { get; set; }
        public DbSet<AccesExamen> AccesExamens { get; set; }
        public DbSet<Identifiant> Identifiants { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<JournalPresence> JournalPresences { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Identifiant>().HasIndex(i => i.CarteRFID).IsUnique(false);
            modelBuilder.Entity<Identifiant>().HasIndex(i => i.EmpreinteDigitale).IsUnique(false);

            // Etudiant - Identifiant (1-1)
            modelBuilder.Entity<Etudiant>()
                .HasOne(e => e.Identifiant)
                .WithOne(i => i.Etudiant)
                .HasForeignKey<Identifiant>(i => i.EtudiantId);

            // Etudiant - Paiement (1-many)
            modelBuilder.Entity<Etudiant>()
                .HasMany(e => e.Paiements)
                .WithOne(p => p.Etudiant)
                .HasForeignKey(p => p.EtudiantId);

            // Etudiant - Promotion (many-1)
            modelBuilder.Entity<Etudiant>()
                .HasOne(e => e.Promotion)
                .WithMany(p => p.Etudiants)
                .HasForeignKey(e => e.IdPromotion);

            // Etudiant - AccesExamen (1-many)
            modelBuilder.Entity<Etudiant>()
                .HasMany(e => e.AccesExamens)
                .WithOne(a => a.Etudiant)
                .HasForeignKey(a => a.EtudiantId);

            // Etudiant - JournalPresence (1-many)
            modelBuilder.Entity<Etudiant>()
                .HasMany(e => e.JournalPresences)
                .WithOne(j => j.Etudiant)
                .HasForeignKey(j => j.EtudiantId);

            // Promotion - HoraireExamen (1-many)
            modelBuilder.Entity<Promotion>()
                .HasMany(p => p.HoraireExamens)
                .WithOne(h => h.Promotion)
                .HasForeignKey(h => h.IdPromotion);

            // Module - HoraireExamen (1-many)
            modelBuilder.Entity<Module>()
                .HasMany(m => m.HoraireExamens)
                .WithOne(h => h.Module)
                .HasForeignKey(h => h.ModuleId);

            // Salle - HoraireExamen (1-many)
            modelBuilder.Entity<Salle>()
                .HasMany(s => s.HoraireExamens)
                .WithOne(h => h.Salle)
                .HasForeignKey(h => h.SalleId);

            // Session - HoraireExamen (1-many)
            modelBuilder.Entity<Session>()
                .HasMany(s => s.HoraireExamens)
                .WithOne(h => h.Session)
                .HasForeignKey(h => h.SessionId);

            // HoraireExamen - AccesExamen (1-many)
            modelBuilder.Entity<HoraireExamen>()
                .HasMany(h => h.AccesExamens)
                .WithOne(a => a.HoraireExamen)
                .HasForeignKey(a => a.HoraireExamenId);

            // HoraireExamen - JournalPresence (1-many)
            modelBuilder.Entity<HoraireExamen>()
                .HasMany(h => h.JournalPresences)
                .WithOne(j => j.HoraireExamen)
                .HasForeignKey(j => j.HoraireExamenId);

            // Salle - AccesExamen (1-many)
            modelBuilder.Entity<Salle>()
                .HasMany(s => s.AccesExamens)
                .WithOne(a => a.Salle)
                .HasForeignKey(a => a.SalleId);

            // Module - AccesExamen (1-many)
            modelBuilder.Entity<Module>()
                .HasMany(m => m.AccesExamens)
                .WithOne(a => a.Module)
                .HasForeignKey(a => a.ModuleId);

            // JournalPresence - Salle (many-1)
            modelBuilder.Entity<JournalPresence>()
                .HasOne(j => j.Salle)
                .WithMany()
                .HasForeignKey(j => j.SalleId);

            // JournalPresence - Session (many-1)
            modelBuilder.Entity<JournalPresence>()
                .HasOne<Session>()
                .WithMany()
                .HasForeignKey(j => j.SessionId);

            // JournalPresence - AccesExamen (many-1)
            modelBuilder.Entity<JournalPresence>()
                .HasOne(j => j.AccesExamen)
                .WithMany()
                .HasForeignKey(j => j.AccesExamenId);

            // Seed utilisateurs avec int Id
            modelBuilder.Entity<Utilisateur>().HasData(
                new Utilisateur { Id = 1, Nom = "Admin", Email = "admin@gloire.com", MotDePasse = "123499", Role = "Admin" },
                new Utilisateur { Id = 2, Nom = "Surveillant", Email = "surveillant@fatu.com", MotDePasse = "567899", Role = "Surveillant" }
            );

            // Comportement de suppression
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            base.OnModelCreating(modelBuilder);
        }
            // Relations FluentAPI si besoin (OneToMany, etc.)
        }

    }

    // Add-Migration NomDeLaMigration

