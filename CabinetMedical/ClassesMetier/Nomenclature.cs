// <copyright file="Nomenclature.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using CabinetMedical.Exceptions;

    /// <summary>
    /// Class Nomenclature.
    /// </summary>
    public class Nomenclature
    {
        private int id;
        private string libelle;
        private int indice;

        /// <summary>
        /// Initializes a new instance of the <see cref="Nomenclature"/> class.
        /// </summary>
        /// <param name="id">id de la Nomenclature. </param>
        /// <param name="libelle">libelle.</param>
        /// <param name="indice">l'indice doit être  ≥ à 1 et ≤ à 100.</param>
        public Nomenclature(int id, string libelle, int indice)
        {
            if (indice < 1 || indice > 100)
            {
                throw new CabinetMedicalException("Erreur l'indice doit être  ≥ à 1 et ≤ à 100.");
            }

            this.id = id;
            this.libelle = libelle;
            this.indice = indice;
        }

        /// <summary>
        /// Gets.
        /// </summary>
        public int Id { get => this.id; }

        /// <summary>
        /// Gets.
        /// </summary>
        public string Libelle { get => this.libelle; }

        /// <summary>
        /// Gets.
        /// </summary>
        public int Indice { get => this.indice; }
    }
}
