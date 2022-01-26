#region Usings

using System;
using Parser;
using Decoder;
using ParserJSON;

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
            Console.WriteLine("List of programs:\nParser\nDecoder\nParserJSON\n\nEnter the name of the program you want to run.");
            string input = Console.ReadLine();
            while (input != "Decoder" && input != "Parser" && input != "ParserJSON")
            {
                Console.WriteLine("Incorrect input, select from the suggested ones. Try again.");
                Console.WriteLine("List of programs:\nParser\nDecoder\nParserJSON\n\nEnter the name of the program you want to run.");
                input = Console.ReadLine();
            }
            if (input == "Decoder")
            {
                var obj = new Decoder.Decoder();
                obj.MyDecoder();
            }
            else
            {
                if (input == "Parser")
                {
                    var obj = new Parser.Parser();
                    obj.MyParser();
                }
                else
                {
                    var obj = new ParserJSON.Parser();
                    obj.MyParserJSON();
                }              
            }               
        }
    }
}