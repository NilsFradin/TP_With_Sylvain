﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Entity;
using Modele.ECommerce.Entites;

namespace Modele.ECommerce.Fluent
{
    public class ContextFluent : DbContext
    { 
        public ContextFluent() : base("name=TP1ConnexionString")
        {
            //Database.SetInitializer<ContextFluent>(new DropCreateDatabaseIfModelChanges<ContextFluent>());
            Database.SetInitializer<ContextFluent>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<CommandeProduit> CommandesProduits { get; set; }
        public DbSet<LogProduit> LogsProduits { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Statut> Statuts { get; set; }

    }
}
