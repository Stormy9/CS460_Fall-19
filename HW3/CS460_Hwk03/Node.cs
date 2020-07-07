using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS460_Hwk03
{
    /// <summary>
    /// / singly-linked node class
    /// </summary>
    ///----------------------------------------------------------------
    public class Node<T>
    {
        public T data;
        public Node<T> next;

        /// <summary>
        /// Node constructor
        /// </summary>
        /// <param name="data"></param>
        /// <param name="next"></param>
        ///------------------------------------------------------------
        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }
    //===================================================================================
}
