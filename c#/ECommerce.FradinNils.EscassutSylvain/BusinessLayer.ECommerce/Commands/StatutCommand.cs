using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.ECommerce.Entites;
using Modele.ECommerce.Fluent;

namespace BusinessLayer.ECommerce.Commands
{
    public class StatutCommand
    {
        private readonly ContextFluent _contexte;

        public StatutCommand(ContextFluent contexte)
        {
            _contexte = contexte;
        }

        public Statut Add(Statut statut)
        {
            _contexte.Statuts.Add(statut);
            _contexte.SaveChanges();

            return statut;
        }

        public Statut Update(Statut statut)
        {
            Statut sDB = _contexte.Statuts.Where(s => s.Id == statut.Id).FirstOrDefault();
            if (sDB != null)
            {
                sDB.Id = statut.Id;
                sDB.Libelle = statut.Libelle;
                sDB.Commandes = statut.Commandes;
            }
            _contexte.SaveChanges();

            return sDB;
        }

        public Statut Delete(Statut statut)
        {
            _contexte.Statuts.Remove(statut);
            _contexte.SaveChanges();

            return statut;
        }
    }
}
