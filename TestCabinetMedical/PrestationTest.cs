// <copyright file="PrestationTest.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace TestCabinetMedical
{
    using System;
    using CabinetMedical.ClassesMetier;
    using CabinetMedical.Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class PrestationTest.
    /// </summary>
    [TestClass]
    public class PrestationTest
    {
        /// <summary>
        /// TesteDatePrestationSuperieurOK.
        /// </summary>
        [TestMethod]
        public void TesteDatePrestationSuperieurOK()
        {
            Intervenant intervenant = new Intervenant("Dupont", "Jean");
            Prestation prestation = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant);
            Dossier dossier = new Dossier("Robert", "Jean", new DateTime(1989, 12, 3), new DateTime(2013, 09, 15), prestation);
            Assert.IsInstanceOfType(dossier, typeof(Dossier));
        }

        /// <summary>
        /// TesteDatePrestationKO.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]
        public void TesteDatePrestationKO()
        {
            DateTime CreationDossier = DateTime.Now.AddDays(10);
            Intervenant intervenant = new Intervenant("Dupont", "Jean");
            Prestation prestation = new Prestation("P3", Convert.ToDateTime("10/09/2015 12:00:00"), intervenant);
            Dossier dossier = new Dossier("Robert", "Jean", new DateTime(1989, 12, 3), CreationDossier, prestation);
        }
    }
}