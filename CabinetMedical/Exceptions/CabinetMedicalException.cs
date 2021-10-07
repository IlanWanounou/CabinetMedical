// <copyright file="CabinetMedicalException.cs" company="Ilan">
// Copyright (c) Ilan. All rights reserved.
// </copyright>

namespace CabinetMedical.Exceptions
{
    using System;
    using System.Reflection;

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
            TempException tempException = new TempException();

            var methodInfo = MethodBase.GetCurrentMethod();
            var fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name;
            tempException.Application = Assembly.GetExecutingAssembly().GetName().Name;
            tempException.ClasseException = fullName;
            tempException.DateException = DateTime.Now;
            tempException.MessageException = exception;
            tempException.UserExpcetion = Environment.UserName;
            tempException.UserMachine = Environment.MachineName;

            // Json j = new Json(tempException.Application, tempException.ClasseException, tempException.DateException, tempException.MessageException, tempException.UserMachine, tempException.UserMachine);
            // j.addError();
        }
    }
}
