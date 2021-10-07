// <copyright file="IntervenantTest.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace TestCabinetMedical
{
    using System;
    using CabinetMedical.ClassesMetier;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// class IntervenantTest.
    /// </summary>
    [TestClass]
    public class IntervenantTest
    {
        /// <summary>
        /// TesteGetNbPrestationsI.
        /// </summary>
        [TestMethod]
        public void TesteGetNbPrestationsI()
        {
            Intervenant intervenant = new Intervenant("Dupont", "Pierre");
            intervenant.AjoutePrestation(new Prestation("Presta x", new DateTime(2019, 6, 12), intervenant));
            intervenant.AjoutePrestation(new Prestation("Presta y", new DateTime(2019, 6, 15), intervenant));
            Assert.AreEqual(2, intervenant.GetNbPrestations());
        }

        /// <summary>
        /// TesteGetNbPrestationIE.
        /// </summary>
        [TestMethod]
        public void TesteGetNbPrestationIE()
        {
            IntervenantExterne intervenant = new IntervenantExterne("Dupont", "Pierre", "spécialité", "adresse", "01 01 01 01 01");
            intervenant.AjoutePrestation(new Prestation("Presta x", new DateTime(2019, 6, 12), intervenant));
            intervenant.AjoutePrestation(new Prestation("Presta y", new DateTime(2019, 6, 15), intervenant));
            Assert.AreEqual(2, intervenant.GetNbPrestations());
        }
    }
}