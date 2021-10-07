// <copyright file="Intervenant.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System.Collections.Generic;

    /// <summary>
    /// Class Intervenant.
    /// </summary>
    public class Intervenant
    {
        private string nom;
        private string prenom;
        private List<Prestation> prestations = new List<Prestation>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Intervenant"/> class.
        /// </summary>
        /// <param name="nom">nom.</param>
        /// <param name="prenom">prenom.</param>
        public Intervenant(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
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
        /// obtien le nombre de presation par interveant.
        /// </summary>
        /// <returns>int.</returns>
        public int GetNbPrestations()
        {
            return this.prestations.Count;
        }

        /// <summary>
        /// ajout une presation dans une liste.
        /// </summary>
        /// <param name="prestation">prestation.</param>
        public void AjoutePrestation(Prestation prestation)
        {
            this.prestations.Add(prestation);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <returns>a.</returns>
        public int GetNbPrestationsE()
        {
            int nb = 0;

            for (int i = 0; i < this.prestations.Count; i++)
            {
                if (this.prestations[i].IntervenatExterne != null)
                {
                    nb++;
                }
            }

            return nb;
        }

        /// <summary>
        /// override.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return "Intervenant : " + this.nom + " - " + this.prenom;
        }
    }
}
