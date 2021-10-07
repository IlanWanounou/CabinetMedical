// <copyright file="Prestation.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
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
        public Prestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant)
        {
            this.libelle = libelle;
            this.dateHeuresoins = dateHeureSoin;
            this.intervenant = intervenant;
        }

        /// <summary>
        /// Gets.
        /// </summary>
        public Intervenant UnIntervenant { get => this.intervenant; }

        /// <summary>
        /// Gets.
        /// </summary>
        public IntervenantExterne IntervenatExterne { get => this.intervenantE; }

        /// <summary>
        /// Gets.
        /// </summary>
        public DateTime DateHeuresoins { get => this.dateHeuresoins; }

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
        /// re écriture de ToString.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return "Libelle " + this.libelle + " - " + this.dateHeuresoins + " - " + this.intervenant + "\n\t";
        }
    }
}
