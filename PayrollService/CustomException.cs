using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollService
{
    class CustomException : Exception 
    {
        public enum ExceptionName
        {
            No_Record_Found,
            Connection_Failed
        }

        ExceptionName exceptionType;
        /// <summary>
        /// Constructor to set enum variable type
        /// </summary>
        /// <param name="exName"></param>
        /// <param name="msg"></param>
        public CustomException(ExceptionName exName, string msg) : base(msg)
        {
            this.exceptionType = exName;
        }
    }
}
