// <copyright file="TempException.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace CabinetMedical.Exceptions
{
    using System;

    /// <summary>
    /// Class TempException.
    /// </summary>
    internal class TempException
    {
        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public string ClasseException { get; set; }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public DateTime DateException { get; set; }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public string MessageException { get; set; }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public string UserExpcetion { get; set; }

        /// <summary>
        /// Gets or Sets.
        /// </summary>
        public string UserMachine { get; set; }
    }
}
