using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS460_Hwk03
{
    public class QueueUnderflowException : Exception
    {
        /// <summary>
        ///     the default constructor -- set up like MSC# docs
        /// </summary>
        ///------------------------------------------------------------
        public QueueUnderflowException()
        {
        }
        //===============================================================================
        /// <summary>
        ///     the same thing but with our custom message to the user
        /// </summary>
        /// <param name="message">
        ///     the message passed in from the other class(es)
        /// </param>
        ///------------------------------------------------------------
        public QueueUnderflowException(string message)
            : base(message)
        {
        }
        //===============================================================================
    }
}
