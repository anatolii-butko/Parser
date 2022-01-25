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
            if (input == "Decoder" || input == "D" || input == "d")
            {
                var obj = new Decoder();
                obj.MyDecoder();
            }
            else
            {
                if (input == "Parser" || input == "P" || input == "p")
                {
                    var obj = new Parser.Parser();
                    obj.MyParser();
                }
                else Console.WriteLine("Incorrect input, select from the suggested ones. Try again.");
            }            
        }
    }
}
