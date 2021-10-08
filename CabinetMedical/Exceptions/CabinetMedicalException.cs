// <copyright file="CabinetMedicalException.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace CabinetMedical.Exceptions
{
    using System;
    using System.Text.Json;
    using CabinetMedical.ClassesMetier;

    /// <summary>
    /// Class CabinetMedicalException qui hérite de Exception.
    /// </summary>
    public class CabinetMedicalException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CabinetMedicalException"/> class.
        /// </summary>
        /// <param name="exception">Message.</param>
        public CabinetMedicalException(string exception)
            : base(exception)
        {
        }

        /// <summary>
        /// Formate sous forme de JSON.
        /// </summary>
        /// <param name="log">Objet log.</param>
        /// <returns>Format JSON.</returns>
        public string GetExceptionJson(Log log)
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(log, options);
            return jsonString;
        }
    }
}
