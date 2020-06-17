using System;
using System.Collections.Generic;
using System.Text;

namespace CabInVoice
{
    public class CabInvoiceAnalyserException : Exception
    {
        //Declare Global Variable
        public string message;

        /// <summary>
        /// Enum is Used to define Enumerated Data types
        /// </summary>
        public enum ExceptionType
        {
            NULL_REFERENCE_EXCEPTION,
            INVALID_ARGUMENT_EXCEPTION
        }
        public ExceptionType type;

        /// <summary>
        /// This Method is Used to Load message And Exception Type
        /// </summary>
        /// <param name="path">path parameter contains the String And ExceptionType</param>
        /// <returns>It Not returns Anything</returns>
        public CabInvoiceAnalyserException(string message, ExceptionType type) 
        {
            this.type = type;
            this.message = message;
        }
    }
}
