namespace ParserJSON
{

    #region Using

    using System;  
    using System.IO;  
    using Newtonsoft.Json.Linq;


    #endregion

    /// <summary>
    /// The class which contains json parser.
    /// </summary>
    public class Parser
    {

        #region Public Methods

        /// <summary>
        /// A method that parses contacts.json file.
        /// </summary>
        public void MyParserJSON()
        {
            Console.WriteLine("Enter full path and name of file you want to parse: ");
            string path = Console.ReadLine();
            while (!File.Exists(path))
            {
                Console.WriteLine("File dont exist or incorect path! Please try again.");
                Console.WriteLine("Enter full path and name of file you want to parse: ");
                path = Console.ReadLine();
            }
            Console.WriteLine("Enter the data you want to find in the file: ");
            string check = Console.ReadLine();
            string json = File.ReadAllText(path);
            JObject o = JObject.Parse(json);
            string output = "Incorrect data! Please check your input and try again.";
            Console.WriteLine(o[check]);
                        
        } 

        #endregion

    }
}
