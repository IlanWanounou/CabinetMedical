// <copyright file="Dossier.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CabinetMedical.Exceptions;

    /// <summary>
    /// Class Dossier.
    /// </summary>
    public class Dossier
    {
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private Prestation prestation;
        private List<Prestation> prestationList;
        private DateTime dateCreation;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">nom.</param>
        /// <param name="prenom">prenom.</param>
        /// <param name="dateNaissance">dateNaissance.</param>
        /// <param name="dateCreation">dateCreation.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, DateTime dateCreation)
        {
            if (dateCreation > DateTime.Now)
            {
                throw new CabinetMedicalException("<!>  Erreur la date de creation ne peut etre supérieure à la date du jour <!>");
            }

            if (dateNaissance > DateTime.Now)
            {
                throw new CabinetMedicalException("<!> Erreur la date de naissance est supérieure à la date du jour <!>");
            }

            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance.Date;
            this.dateCreation = dateCreation;
            this.prestationList = new List<Prestation>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">nom.</param>
        /// <param name="prenom">prenom.</param>
        /// <param name="dateNaissance">dateNaissance.</param>
        /// <param name="dateCreation">dateCreation.</param>
        /// <param name="prestation">prestation.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, DateTime dateCreation, Prestation prestation)
            : this(nom, prenom, dateNaissance, dateCreation)
        {
            if (prestation.DateHeuresoins < dateCreation)
            {
                throw new CabinetMedicalException("a");
            }
            else
            {
                this.prestation = prestation;
                this.prestationList.Add(this.prestation);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">nom.</param>
        /// <param name="prenom">prenom.</param>
        /// <param name="dateNaissance">dateNaissance.</param>
        /// <param name="dateCreation">dateCreation.</param>
        /// <param name="prestation">prestation.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, DateTime dateCreation, List<Prestation> prestation)
            : this(nom, prenom, dateNaissance, dateCreation)
        {
            for (int i = 0; i < prestation.Count; i++)
            {
                if (prestation[i].DateHeuresoins < this.dateCreation)
                {
                    throw new CabinetMedicalException("a");
                }
            }

            this.prestationList = prestation;
        }

        /// <summary>
        /// Gets.
        /// </summary>
        public string Nom { get => this.nom; }

        /// <summary>
        /// Gets.
        /// </summary>
        public string Prenom { get => this.prenom; }

        /// <summary>
        /// Gets.
        /// </summary>
        public DateTime DateNaissance { get => this.dateNaissance; }

        /// <summary>
        /// Gets.
        /// </summary>
        public List<Prestation> PrestationList { get => this.prestationList; }

        /// <summary>
        /// Gets.
        /// </summary>
        public DateTime DateCreation { get => this.dateCreation; }

        /// <summary>
        /// ajout à une liste une presatation.
        /// </summary>
        /// <param name="libelle">libelle.</param>
        /// <param name="date">date.</param>
        public void AjoutePrestation(string libelle, DateTime date)
        {
            if (date < this.dateCreation)
            {
                throw new CabinetMedicalException("a");
            }

            this.prestationList.Add(new Prestation(libelle, date));
        }

        /// <summary>
        /// ajout à une liste via liste de presation.
        /// </summary>
        /// <param name="prestation">List de prestation.</param>
        public void AjoutePresationList(List<Prestation> prestation)
        {
                    this.prestationList = prestation;
        }

        /// <summary>
        /// override.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            string contenu = string.Empty;
            foreach (Prestation prestation in this.prestationList)
            {
                contenu += prestation;
            }

            return "-------------Début dossier ------------ \n" + "Nom : " + this.nom + " Prenom : " + this.prenom + " Date de naissance : " + this.dateNaissance.ToShortDateString() + "\n\t" + contenu + "\n -------------Fin dossier --------------";
        }

        /*
             public int getNbSoinsExterne()
              {
                  int nb = 0;
                 foreach(Prestation uneprestation in prestationList)
                  {
                      if(uneprestation.IntervenatExterne != null)
                      {
                          nb++;
                      }
                  }
                  return nb;

              }

        */

        /// <summary>
        /// 1er version.
        /// </summary>
        /// <returns>int.</returns>
        public int GetNbJourSoinsV1()
        {
            int nb = this.prestationList.Count;
            for (int i = 0; i < this.prestationList.Count; i++)
            {
                for (int y = i + 1; y < this.prestationList.Count; y++)
                {
                    if (Prestation.CompareTo(this.prestationList[i], this.prestationList[y]) == 0)
                    {
                        nb--;
                    }
                }
            }

            return nb;
        }

        /// <summary>
        /// 2eme version.
        /// </summary>
        /// <returns>int.</returns>
        public int GetNbJourSoinsV2()
        {
            List<DateTime> date = new List<DateTime>();
            foreach (Prestation prestation in this.prestationList)
            {
                if (!date.Contains(prestation.DateHeuresoins.Date))
                {
                    date.Add(prestation.DateHeuresoins.Date);
                }
            }

            return date.Count;
        }

        /// <summary>
        /// 3eme version.
        /// </summary>
        /// <returns>int.</returns>
        public int GetNbJoursSoinsV3()
        {
            List<Prestation> dateTrie = this.prestationList.OrderBy(prest => prest.DateHeuresoins).ToList(); // ordre croissant

            // List<Prestation> dateTrie = prestations.OrderByDescending(prest => prest.DateHeureSoin).ToList(); //ordre décroissant
            DateTime baser = dateTrie[0].DateHeuresoins.Date;
            int cpt = 0;

            foreach (Prestation date in dateTrie)
            {
                if (!(date.DateHeuresoins.Date == baser))
                {
                    cpt++;
                    baser = date.DateHeuresoins.Date;
                }
            }

            return cpt + 1;
        }
    }
}
