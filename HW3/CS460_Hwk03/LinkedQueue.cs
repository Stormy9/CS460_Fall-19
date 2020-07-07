using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS460_Hwk03
{
    /// <summary>
    ///     the LinkedQueue we'll read our text input file into,
    ///     tokenizing by whitespace into separate words
    ///     implementing our IQueueInterface
    /// </summary>
    /// <typeparam name="T">
    ///     generic type for our LinkedQueue
    /// </typeparam>
    ///----------------------------------------------------------------
    public class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;

        //-------------------------------------------------------------
        /// <summary>
        ///     constructor for a LinkedQueue
        /// </summary>
        ///------------------------------------------------------------
        public LinkedQueue()
        {
            front = null;
            rear = null;
        }
        //===============================================================================
        /// <summary>
        ///     push an element onto LinkedQueue -- goes to end of line
        /// </summary>
        /// <param name="element">
        ///     the thing we're pushing onto the LinkedQueue
        /// </param>
        /// <returns>
        ///     whatever we pushed onto our LinkedQueue
        /// </returns>
        ///------------------------------------------------------------
        public T Push(T element)
        {
            if (element == null)
            {
                throw new NullReferenceException();
            }
            //---------------------------------------------------------
            if (IsEmpty())
            {
                Node<T> tmp = new Node<T>(element, null);
                rear = front = tmp;
            }
            else
            {
                // this is the general case
                Node<T> tmp = new Node<T>(element, null);
                rear.next = tmp;
                rear = tmp;
            }
            //---------------------------------------------------------
            return element;
        }
        //===============================================================================
        /// <summary>
        ///     pop something off LinkedQueue -- the first one in line
        /// </summary>
        /// <returns>
        ///     the thing we popped off the LinkedQueue
        /// </returns>
        ///------------------------------------------------------------
        public T Pop()
        {
            T tmp = default(T);
            //---------------------------------------------------------
            if (IsEmpty())
            {
                throw new QueueUnderflowException("Queue was empty when we popped!");
            }
            else if (front == rear)
            {
                // aka there's only one item in the LinkedQueue
                tmp = front.data;
                front = null;
                rear = null;
            }
            else
            {
                // the general/usual case
                tmp = front.data;
                front = front.next;
            }
            //---------------------------------------------------------
            return tmp;
        }
        //===============================================================================
        /// <summary>
        ///     lets us see the first element in line, in LinkedQueue,
        ///     without actually removing it from the LinkedQueue
        /// </summary>
        /// <returns>
        ///     a peek at the first thing in line, in the LinkedQueue
        /// </returns>
        ///------------------------------------------------------------
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("Queue was empty when we peeked!");
            }
            return front.data;
        }
        //===============================================================================
        /// <summary>
        ///     checks to see if LinkedQueue is empty, or not
        /// </summary>
        /// <returns>
        ///     true if LinkedQueue is empty -- otherwise false
        /// </returns>
        ///------------------------------------------------------------
        public Boolean IsEmpty()
        {
            if (front == null && rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //===============================================================================
    }
}
