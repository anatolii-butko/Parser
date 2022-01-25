#region Usings

using System;
using Parser;
using ParserDecoder;

#endregion

namespace RunProgram
{
    /// <summary>
    /// The class which contains program chooser and runer.    
    /// </summary>
    class Program
    {

        /// <summary>>
        /// Void Main.
        /// </summary> 
        static void Main()
        {
            Console.WriteLine("Parser\nDecoder\n\nEnter the name of the program you want to run: Parser or Decoder?");
            string input = Console.ReadLine();
            while (input != "Decoder" && input != "Parser")
            {
                Console.WriteLine("Incorrect input, select from the suggested ones. Try again.");
                Console.WriteLine("Parser\nDecoder\n\nEnter the name of the program you want to run: Parser or Decoder?");
                input = Console.ReadLine();
            }
            if (input == "Decoder")
            {
                var obj = new Decoder();
                obj.MyDecoder();
            }
            else
            {
                var obj = new Parser.Parser();
                obj.MyParser();
            }               
        }
    }
}