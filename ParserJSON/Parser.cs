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
        /// A method that parses JSON.json file.
        /// </summary>
        public void MyParserJson()
        {
            Console.WriteLine("Enter full path and name of .json file you want to parse: ");
            string path = Console.ReadLine();
            while (!File.Exists(path))
            {
                Console.WriteLine($"File dont exist or incorect path! Please try again.\nEnter full path and name of .json file you want to parse: ");
                path = Console.ReadLine();
            }
            string json = File.ReadAllText(path);
            while (json != null)
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
                Console.WriteLine("Enter the data you want to find in the .json file: ");
                string check = Console.ReadLine();
                while (!Elements[0].Contains(check))
                {
                    Console.WriteLine("Data dont found or incorect! Please try again.");
                    Console.WriteLine("Enter the data you want to find in the .json file: ");
                    check = Console.ReadLine();
                }
                // Search in the array of entered data.
                string output = Elements[0][Array.IndexOf(Elements[0], check)] + " : ";
                foreach (string elem in Elements[Array.IndexOf(Elements[0], check) + 1]) output += "\n\t" + elem;
                Console.WriteLine("\n" + output);
                Console.WriteLine("You can change TIMEOUT typing a new value. If you do not want change it, press Enter. Value by default 20480.");
                string newTimeout = Console.ReadLine();
                if (newTimeout != null && newTimeout != "") data.MediaInterfaceSettings["Hardware Timeout"]["TIMEOUT"] = newTimeout;
                string newjson = JsonConvert.SerializeObject(data, Formatting.Indented);
                Console.WriteLine("New json file after serialization: ");
                Console.WriteLine(newjson);
                Console.WriteLine("Enter the the full path to the new .json file where you want to save it.\nIf file exist it will be override. If there are no folders in this path, they will be created.\nIf you do not enter anything, the file is saved in the root folder C:\\ by default as newjson.json.");
                string pathForNewJson = Console.ReadLine();
                if (pathForNewJson == null || pathForNewJson == "") pathForNewJson = @"C:\\newjson.json"; // Path by default.
                string msg;
                if (!File.Exists(pathForNewJson))
                {
                    string directory = Path.GetDirectoryName(pathForNewJson);
                    if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
                    File.Create(pathForNewJson).Close();
                    msg = "New .json file created";
                }
                else msg = "Existed .json file overrided";
                File.WriteAllText(pathForNewJson, newjson);
                Console.WriteLine($"{msg} by path: {pathForNewJson} \nThe next step is to search for the data in the origin .json file again, and then generate the new .json file." +
                    $"\nTo exit, type exit in the console. Any other input will be accepted for the agreement to continue.");
                string responce = Console.ReadLine();
                if (responce == "exit" || responce == "Exit") break;
            }
        }

        #endregion

    }
}