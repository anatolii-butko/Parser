using System;
using System.Collections.Generic;
using System.Text;

namespace Parser
{
    /// <summary>
    /// A wrapper class is defined for the List <T> class whose Object.ToString method you want to customize.
    /// It replaces the Object.ToString method to display the value of each collection method, not the full type name.
    /// </summary>
    /// <typeparam name="T">
    /// Universal type T for the list.
    /// </typeparam>
    public class CList<T> : List<T>
    {
        /// <summary>
        /// An interface inherited from the base class
        /// </summary>
        /// <param name="collection">
        /// Arrays and collection classes
        /// </param>
        public CList(IEnumerable<T> collection) : base(collection)
        { }

        /// <summary>
        /// Implement the required constructor.
        /// </summary>
        public CList() : base()
        { }

        /// <summary>
        /// Method that overrides the Object.ToString method to display the value 
        /// of each method of the collection rather than the fully qualified type name.
        /// </summary>
        /// <returns>
        /// Values of its members in the form of a result string.
        /// </returns>
        public override string ToString()
        {
            string retVal = string.Empty;
            foreach (T item in this)
            {
                if (string.IsNullOrEmpty(retVal))
                    retVal += item.ToString();
                else
                    retVal += string.Format(", {0}", item);
            }
            return retVal;
        }
    }
}
