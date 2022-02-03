#region Usings

using System;
using ParserDecoder;

#endregion

namespace RunProgram
{
    /// <summary>
    /// The class which contains program chooser and runer.    
    /// </summary>
    public class Program
    {
        /// <summary>>
        /// Void Main.
        /// </summary> 
        protected static void Main()
        {
            Console.WriteLine("List of programs:\nParserXml\nParserDecoder\nParserJson\n\nEnter the name of the program you want to run.");
            string input = Console.ReadLine();
            while (input != "ParserDecoder" && input != "ParserXml" && input != "ParserJson")
            {
                Console.WriteLine("Incorrect input, select from the suggested ones. Try again.");
                Console.WriteLine("List of programs:\nParserXml\nParserDecoder\nParserJson\n\nEnter the name of the program you want to run.");
                input = Console.ReadLine();
            }
            if (input == "ParserDecoder")
            {
                Decoder obj = new Decoder();
                obj.MyDecoder();
            }
            else
            {
                if (input == "ParserXml")
                {
                    ParserXml.Parser obj = new ParserXml.Parser();
                    obj.MyParserXml();
                }
                else
                {
                    ParserJson.Parser obj = new ParserJson.Parser();
                    obj.MyParserJson();
                }              
            }               
        }
    }
}