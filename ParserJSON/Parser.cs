namespace ParserJson
{

    #region Using

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    using System.Runtime.Serialization.Json;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Schema;

    #endregion

    /// <summary>
    /// Class which need for deserialization
    /// </summary>
    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Interface Settings")]
        public string InterfaceSettings { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Media Interface Settings")]
        public string MediaInterfaceSettings { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Port Settings")]
        public string PortSettings { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Unique ID")]
        public string UniqueId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("MAC Address")]
        public string MacAddress { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Component Interconnect ID")]
        public string ComponentInterconnectId { get; set; }
    }

    /// <summary>
    /// The class which contains json parser.
    /// </summary>
    public class Parser
    {

        #region Public Methods

        /// <summary>
        /// A method that parses contacts.json file.
        /// </summary>
        public void MyParserJson()
        {
            Console.WriteLine("Enter full path and name of json file you want to parse: ");
            string path = Console.ReadLine();
            while (!File.Exists(path))
            {
                Console.WriteLine("File dont exist or incorect path! Please try again.");
                Console.WriteLine("Enter full path and name of json file you want to parse: ");
                path = Console.ReadLine();
            }
            string output = "Incorrect data! Please check your input and try again.";
            Console.WriteLine("Enter the data you want to find in the file: ");
            string check = Console.ReadLine();
            string json = File.ReadAllText(path);            
            JObject jobject = JObject.Parse(json);
            var data = JsonConvert.DeserializeObject<Data>(json);
            Console.WriteLine(data.UniqueId);
            do
            {
                if (jobject.ContainsKey(check))
                {
                    output = jobject[check].ToString();
                }
                Console.WriteLine(output);
                Console.WriteLine("Enter the data you want to find in the file: ");
                check = Console.ReadLine();
            } while (output != null);
        }       

        #endregion

    }
    

}