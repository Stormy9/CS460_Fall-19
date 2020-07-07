using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS460_Hwk03
{
    /// <summary>
    ///     this is a FIFO Queue interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    ///----------------------------------------------------------------    
    public interface IQueueInterface<T>
    {
        /// <summary>
        ///     adds an element to the end of the Queue
        /// </summary>
        /// <param name="element"></param>
        /// <returns>
        ///     the element that was just en-Queue'd
        /// </returns>
        ///------------------------------------------------------------
        T Push(T element);

        //===============================================================================
        /// <summary>
        ///     remove & return the front element -- 1st in line
        /// </summary>
        /// <returns>
        ///     the element that was just de-Queue'd
        ///         the front/first-in-line element
        /// </returns>
        /// <throws> 
        ///     QueueUnderflowException --> if the Queue is empty 
        /// </throws>
        ///------------------------------------------------------------
        T Pop();

        //===============================================================================
        /// <summary>
        ///     return -- but do not remove -- the front element
        /// </summary>
        /// <returns> 
        ///     the element first-in-line 
        /// </returns>
        /// <throws> 
        ///     QueueUnderflowException --> if the Queue is empty 
        /// </throws>
        ///------------------------------------------------------------
        T Peek();

        //===============================================================================
        /// <summary>
        ///     check to see if the Queue is empty
        /// </summary>
        /// <returns>
        ///     true if the Queue is empty --- otherwise false
        /// </returns>
        ///------------------------------------------------------------
        Boolean IsEmpty();

        //===============================================================================
    }
}
