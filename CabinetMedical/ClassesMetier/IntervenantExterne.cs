// <copyright file="IntervenantExterne.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    /// <summary>
    /// Class IntervenantExterne qui hérite de Intervenant.
    /// </summary>
    public class IntervenantExterne : Intervenant
    {
        private string specialite;
        private string adresse;
        private string tel;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervenantExterne"/> class.
        /// </summary>
        /// <param name="nom">nom.</param>
        /// <param name="prenom">prenom.</param>
        /// <param name="specialite">specialite.</param>
        /// <param name="adresse">adresse.</param>
        /// <param name="tel">tel.</param>
        public IntervenantExterne(string nom, string prenom, string specialite, string adresse, string tel)
            : base(nom, prenom)
        {
            this.specialite = specialite;
            this.adresse = adresse;
            this.tel = tel;
        }

        /// <summary>
        /// Gets.
        /// </summary>
        public string Specialite { get => this.specialite; }

        /// <summary>
        /// Gets.
        /// </summary>
        public string Adresse { get => this.adresse; }

        /// <summary>
        /// Gets.
        /// </summary>
        public string Tel { get => this.tel; }

        /// <summary>
        ///  override.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return base.ToString() + " Spécialité : " + this.specialite + " - " + this.adresse + " - " + this.tel;
        }
    }
}
