namespace ParserJson
{

    #region Using

    using System;    
    using System.IO;
    using Newtonsoft.Json;
    using System.Linq;

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
            do
            {
                DataJson data = JsonConvert.DeserializeObject<DataJson>(json);
                // Create an array of arrays to store the data of the .json file.
                string[][] Elements = new string[7][];
                // Create an array of root elements.
                Elements[0] = new string[] 
                { "Interface Settings", "Media Interface Settings", "Port Settings",
                    "Unique ID", "MAC Address", "Component Interconnect ID" };
                // Splitting the dictionary of the root element InterfaceSettings into arrays of keys and values and their subsequent concatenation and writing to the array.
                Elements[1] = new string[data.InterfaceSettings.Count];
                for (int i = 0; i < data.InterfaceSettings.Count; i++) Elements[1][i] = data.InterfaceSettings.Keys.ToArray()[i] + " : " + data.InterfaceSettings.Values.ToArray()[i];
                // Splitting the dictionary of the root element MediaInterfaceSetting into arrays
                // of keys and values and their subsequent concatenation and writing to the array.
                Elements[2] = new string[data.MediaInterfaceSettings.Count];
                for (int b = 0; b < data.MediaInterfaceSettings.Count; b++)
                {
                    string temp = "";
                    foreach (var nodeitem in data.MediaInterfaceSettings.Values.ToArray()[b])
                    {
                        temp += "\n\t\t " + nodeitem.Key + " : " + nodeitem.Value;
                    }
                    Elements[2][b] = data.MediaInterfaceSettings.Keys.ToArray()[b] + " : " + temp;
                }
                // Splitting the dictionary of the root element PortSettings into arrays of keys and values and their subsequent concatenation and writing to the array.
                Elements[3] = new string[data.PortSettings.Count];
                for (int j = 0; j < data.PortSettings.Count; j++) Elements[3][j] = data.PortSettings.Keys.ToArray()[j] + " : " + data.PortSettings.Values.ToArray()[j];
                // Splitting the dictionary of the root element UniqueId into arrays of keys and values and their subsequent concatenation and writing to the array.
                Elements[4] = new string[data.UniqueId.Count];
                for (int k = 0; k < data.UniqueId.Count; k++) Elements[4][k] = data.UniqueId.Keys.ToArray()[k] + " : " + data.UniqueId.Values.ToArray()[k];
                // Splitting the dictionary of the root element MacAddress into arrays of keys and values and their subsequent concatenation and writing to the array.
                Elements[5] = new string[data.MacAddress.Count];
                for (int l = 0; l < data.MacAddress.Count; l++) Elements[5][l] = data.MacAddress.Keys.ToArray()[l] + " : " + data.MacAddress.Values.ToArray()[l];
                // Splitting the dictionary of the root element ComponentInterconnectId into arrays of keys and values and their subsequent concatenation and writing to the array.
                Elements[6] = new string[data.ComponentInterconnectId.Count];
                for (int m = 0; m < data.ComponentInterconnectId.Count; m++) Elements[6][m] = data.ComponentInterconnectId.Keys.ToArray()[m] + " : " + data.ComponentInterconnectId.Values.ToArray()[m];
                // Search in the array of entered data.
                for (int q = 0; q < Elements[0].Length; q++)
                {
                    if (Elements[0][q] == check)
                    {
                        output = Elements[0][q] + " : ";
                        foreach (string elem in Elements[q + 1]) output += "\n\t" + elem;
                        break;
                    }                    
                }
                Console.WriteLine("\n" + output);

                Console.WriteLine("Enter a new TIMEOUT value. If you do not want to change, enter 20480.");
                string newTimeout = Console.ReadLine();
                if (data.MediaInterfaceSettings["Hardware Timeout"]["TIMEOUT"] != newTimeout) data.MediaInterfaceSettings["Hardware Timeout"]["TIMEOUT"] = newTimeout;
                string newjson = JsonConvert.SerializeObject(data, Formatting.Indented);
                Console.WriteLine("New json file after serialization: ");
                Console.WriteLine(newjson);
                Console.WriteLine("Enter the name of the new file and the full path to it where you want to save it (new .json file).\nIf the file does not exist, it will be created. If it exists, it will be overwritten.\nIf you do not enter anything, the file is saved in the root folder C: newjson.json by default.");
                string newPathForNewJson = Console.ReadLine();
                if (newPathForNewJson == null || newPathForNewJson == "") newPathForNewJson = @"C:\newjson.json"; // Path and name by default.                
                
                File.WriteAllText(newPathForNewJson, newjson); // Create a file to write to.
                Console.WriteLine($"New .json file created and saved by path: {newPathForNewJson}");
                Console.WriteLine("Enter the data you want to find in the file: ");
                check = Console.ReadLine();
            } while (output != null);
        }

        #endregion

    }
}