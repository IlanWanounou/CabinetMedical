// <copyright file="Prestation.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using CabinetMedical.Exceptions;

    /// <summary>
    /// Class Prestation.
    /// </summary>
    public class Prestation
    {
        private string libelle;
        private DateTime dateHeuresoins;
        private Intervenant intervenant;
        private IntervenantExterne intervenantE;
        private Nomenclature nomenclature;
        private Dictionary<int, Nomenclature> nomenclatures;
        private int prix;

        /// <summary>
        /// Initializes a new instance of the <see cref="Prestation"/> class.
        /// </summary>
        /// <param name="libelle">libelle de la presation.</param>
        /// <param name="dateHeuresoins">date et heure de la presation.</param>
        public Prestation(string libelle, DateTime dateHeuresoins)
        {
            if (dateHeuresoins > DateTime.Now)
            {
                throw new CabinetMedicalException("Erreur la date d'une presation ne peut etre supprieur à la date du jour.");
            }

            this.libelle = libelle;
            this.dateHeuresoins = dateHeuresoins;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Prestation"/> class.
        /// </summary>
        /// <param name="libelle">libelle.</param>
        /// <param name="dateHeureSoin">dateHeureSoin.</param>
        /// <param name="intervenant">intervenant.</param>
        /// <param name="nomenclature">nomenclature.</param>
        public Prestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant, Nomenclature nomenclature)
        {
            this.libelle = libelle;
            this.dateHeuresoins = dateHeureSoin;
            this.intervenant = intervenant;
            this.nomenclature = nomenclature;
            this.nomenclatures = new Dictionary<int, Nomenclature>();
            this.nomenclatures.Add(nomenclature.Id, nomenclature);
            this.prix = nomenclature.Indice;
        }

        /// <summary>
        /// Gets.
        /// </summary>
        public Intervenant Intervenant { get => this.intervenant; }

        /// <summary>
        /// Gets.
        /// </summary>
        public IntervenantExterne IntervenatExterne { get => this.intervenantE; }

        /// <summary>
        /// Gets.
        /// </summary>
        public DateTime DateHeuresoins { get => this.dateHeuresoins; }

        /// <summary>
        /// Gets.
        /// </summary>
        public int Prix { get => this.prix; }

        /// <summary>
        /// Gets.
        /// </summary>
        public Nomenclature Nomenclature { get => this.nomenclature; }

        /// <summary>
        /// Gets.
        /// </summary>
        public Dictionary<int, Nomenclature> Nomenclatures { get => this.nomenclatures;  }

        /// <summary>
        /// compare deux date de prestation.
        /// </summary>
        /// <param name="prestation1">prestation1.</param>
        /// <param name="prestation2">prestation2.</param>
        /// <returns>date.</returns>
        public static int CompareTo(Prestation prestation1, Prestation prestation2)
        {
            return DateTime.Compare(prestation1.dateHeuresoins.Date, prestation2.dateHeuresoins.Date);
        }

        /// <summary>
        /// Ajout d'une Nomenclature à une liste de Nomenclature.
        /// </summary>Nomenclature
        /// <param name="nomenclature">Objet de la class.</param>
        public void AddNomenclature(Nomenclature nomenclature)
        {
            this.nomenclatures.Add(nomenclature.Id, nomenclature);
            int lastindex = this.nomenclatures.Count;
            this.prix += lastindex * nomenclature.Indice;
        }

        /// <summary>
        /// Ajout d'une Nomenclature à une liste de Nomenclature.
        /// </summary>Nomenclature
        /// <param name="nomenclature">Objet de la class.</param>
        public void AddNomenclature(List<Nomenclature> nomenclature)
        {
            foreach (Nomenclature nomenclature1 in nomenclature)
            {
                this.nomenclatures.Add(nomenclature1.Id, nomenclature1);
                int lastindex = this.nomenclatures.Count;
                this.prix += lastindex * nomenclature1.Indice;

            }
        }

        /// <summary>
        /// re écriture de ToString.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return "Libelle " + this.libelle + " - " + this.dateHeuresoins + " - " + this.intervenant + "\n\t";
        }
    }
}
