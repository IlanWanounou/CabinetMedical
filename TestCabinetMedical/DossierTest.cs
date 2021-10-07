// <copyright file="DossierTest.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace TestCabinetMedical
{
    using System;
    using System.Collections.Generic;
    using CabinetMedical.ClassesMetier;
    using CabinetMedical.Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class DossierTest.
    /// </summary>
    [TestClass]
    public class DossierTest
    {
        /// <summary>
        /// TestGetNbPrestationI.
        /// </summary>
        [TestMethod]
        public void TestGetNbPrestationI()
        {
            Intervenant intervenant = new Intervenant("Dupont", "Pierre");
            intervenant.AjoutePrestation(new Prestation("Presta 10", new DateTime(2019, 6, 12), intervenant));
            intervenant.AjoutePrestation(new Prestation("Presta 11", new DateTime(2019, 6, 15), intervenant));
            Assert.AreEqual(2, intervenant.GetNbPrestations());
        }

        /// <summary>
        /// TestDateCreationDossierOK.
        /// </summary>
        [TestMethod]
        public void TestDateCreationDossierOK()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2019, 3, 31));
            Assert.IsInstanceOfType(dossier, typeof(Dossier));
        }

        /// <summary>
        /// Test  Exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]
        public void TestDateCreationDossierKO()
        {
            DateTime datecreation = DateTime.Now.AddDays(10);
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), datecreation);
        }

        /// <summary>
        /// Test si la date de presation est > à la date de création.
        /// </summary>
        [TestMethod]
        public void TesteDateTesteDatePresationSuperieureCreationOK()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2018, 3, 31));
            Prestation p = new Prestation("Test 1 ", new DateTime(2019, 1, 10));
        }

        /// <summary>
        /// Test si la date de presation est inferieur  à la date de création.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CabinetMedicalException))]

        public void TesteDateTesteDatePresationSuperieureCreationKO()
        {
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2018, 3, 31));
            dossier.AjoutePrestation("Test 1 ", new DateTime(2005, 1, 10));
        }

        /// <summary>
        /// TesteGetNbPrestationsE.
        /// </summary>
        [TestMethod]
        public void TesteGetNbPrestationsE()
        {
            IntervenantExterne intervenantE = new IntervenantExterne("Sainz", "Olivier", "Radiologue", "Toulon", "030303030");
            Prestation prestation = new Prestation("P1", Convert.ToDateTime("01/09/2015 12:00:00"), intervenantE);
            Prestation prestation3 = new Prestation("P5", Convert.ToDateTime("10/09/2015 06:00:00"), intervenantE);

            intervenantE.AjoutePrestation(prestation);
            intervenantE.AjoutePrestation(prestation3);
            Assert.AreEqual(2, intervenantE.GetNbPrestationsE());
        }

        /// <summary>
        ///  TestNbJoursSoins.
        /// </summary>
        [TestMethod]
        public void TestNbJoursSoins()
        {
            List<Prestation> p = new List<Prestation>();
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2018, 3, 31));
            IntervenantExterne intervenantE = new IntervenantExterne("Sainz", "Olivier", "Radiologue", "Toulon", "030303030");
            Prestation prestation = new Prestation("P1", Convert.ToDateTime("01/09/2015 12:00:00"), intervenantE);
            Prestation prestation2 = new Prestation("P5", Convert.ToDateTime("10/09/2015 06:00:00"), intervenantE);
            Prestation prestation3 = new Prestation("P6", Convert.ToDateTime("10/09/2015 06:00:00"), intervenantE);
            Prestation prestation4 = new Prestation("P6", Convert.ToDateTime("10/09/2016 06:00:00"), intervenantE);

            p.Add(prestation);
            p.Add(prestation2);
            p.Add(prestation3);
            p.Add(prestation4);
            dossier.AjoutePresationList(p);
            Assert.AreEqual(3, dossier.GetNbJourSoinsV1());
        }

        /// <summary>
        ///  TestNbJoursSoinsV2.
        /// </summary>
        [TestMethod]
        public void TestNbJoursSoinsV2()
        {
            List<Prestation> p = new List<Prestation>();
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2018, 3, 31));
            IntervenantExterne intervenantE = new IntervenantExterne("Sainz", "Olivier", "Radiologue", "Toulon", "030303030");
            Prestation prestation = new Prestation("P1", Convert.ToDateTime("01/09/2015 12:00:00"), intervenantE);
            Prestation prestation2 = new Prestation("P5", Convert.ToDateTime("10/09/2015 06:00:00"), intervenantE);
            Prestation prestation3 = new Prestation("P6", Convert.ToDateTime("10/09/2015 06:00:00"), intervenantE);
            Prestation prestation4 = new Prestation("P6", Convert.ToDateTime("10/09/2016 06:00:00"), intervenantE);

            p.Add(prestation);
            p.Add(prestation2);
            p.Add(prestation3);
            p.Add(prestation4);
            dossier.AjoutePresationList(p);
            Assert.AreEqual(3, dossier.GetNbJourSoinsV2());
        }

        /// <summary>
        ///  TestNbJoursSoinsV3.
        /// </summary>
        [TestMethod]
        public void TestNbJoursSoinsV3()
        {
            List<Prestation> p = new List<Prestation>();
            Dossier dossier = new Dossier("Dupont", "Jean", new DateTime(1990, 11, 12), new DateTime(2018, 3, 31));
            IntervenantExterne intervenantE = new IntervenantExterne("Sainz", "Olivier", "Radiologue", "Toulon", "030303030");
            Prestation prestation = new Prestation("P1", Convert.ToDateTime("01/09/2015 12:00:00"), intervenantE);
            Prestation prestation2 = new Prestation("P5", Convert.ToDateTime("10/09/2015 06:00:00"), intervenantE);
            Prestation prestation3 = new Prestation("P6", Convert.ToDateTime("10/09/2015 06:00:00"), intervenantE);
            Prestation prestation4 = new Prestation("P6", Convert.ToDateTime("10/09/2016 06:00:00"), intervenantE);

            p.Add(prestation);
            p.Add(prestation2);
            p.Add(prestation3);
            p.Add(prestation4);
            dossier.AjoutePresationList(p);
            Assert.AreEqual(3, dossier.GetNbJoursSoinsV3());
        }
    }
}
