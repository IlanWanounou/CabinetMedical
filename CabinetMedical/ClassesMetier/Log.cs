// <copyright file="Log.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;

    /// <summary>
    /// Class Log.
    /// </summary>
    public class Log
    {
        private string application;
        private string className;
        private DateTime date;
        private string message;
        private string user;
        private string machine;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> class.
        /// </summary>
        /// <param name="message">Message de l'erreur.</param>
        public Log(string message)
        {
            this.application = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString();
            this.className = this.GetType().Name.ToString();
            this.date = DateTime.Now;
            this.message = message;
            this.user = Environment.UserName;
            this.machine = Environment.MachineName;
        }
    }
}
