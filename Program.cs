using System;

namespace Parser
{
    /// <summary>
    /// Program driver.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Void Main.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Enter the first name or last name of contact you want to know about: ");
            string checkName = Console.ReadLine();
            Parser test = new Parser();
            test.MyParser(checkName);
        }
    }
}
