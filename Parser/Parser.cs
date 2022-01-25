namespace Parser
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.IO;    
    using System.Xml.Linq;
    using System.Xml.XPath;

    #endregion

    /// <summary>
    /// The class which contains parser.
    /// </summary>
    public class Parser
    {
        
        #region Public Methods
        
        /// <summary>
        /// A method that parses contacts.xml file.
        /// </summary>        
        public void MyParser()
        {
            Console.WriteLine("Enter file full path and name of file you want to parse: ");
            string path = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine("File dont exist or incorect path!");
                return;
            }
            Console.WriteLine("Enter the first name or last name of contact you want to know about: ");
            string check = Console.ReadLine();
            var xdoc = XDocument.Load(path);            
            List<string> temp = new List<string>();
            string output = "Incorrect data! Please check your input and try again.";
            foreach (XElement C in xdoc.Element("Contacts").Elements("Contact"))
            {
                if (C == null) return;
                string name = C.Element("Name").Value;                
                string firstname = name.Substring(0, name.IndexOf(' '));                
                string lastname = name.Substring(name.IndexOf(' ') + 1, name.Length - name.IndexOf(' ') - 1);                
                if (name == check || firstname == check || lastname == check)
                {
                    temp.Add("Name: " + name);
                    string temp1 = "";
                    temp1 += ", " + C.Element("Phone").Attribute("Type").Value + " " + C.Element("Phone").Value;
                    temp1 = temp1.TrimStart(',');
                    temp1 = temp1.TrimStart(' ');                    
                    temp.Add("Phones: " + temp1);
                    
                    foreach (XElement A in xdoc.Element("Contacts").Element("Contact").Elements("Address"))
                    {
                        string temp2 = "";                        
                        temp2 += ", " + A.Element("Street1").Value;
                        temp2 += ", " + A.Element("City").Value;
                        temp2 += ", " + A.Element("State").Value;
                        temp2 += ", " + A.Element("Postal").Value;
                        temp2 = temp2.TrimStart(',');
                        temp2 = temp2.TrimStart(' ');
                        Console.WriteLine(temp2);
                        temp.Add("Address: " + temp2);                        
                    }
                    if (C.Element("NetWorth").Value == "None")
                    {
                        temp.Add("NetWorth: There is no salary increase");
                        Console.WriteLine("NetWorth: There is no salary increase");
                    }
                    else
                    {
                        temp.Add("NetWorth: " + C.Element("NetWorth").Value);
                        Console.WriteLine("NetWorth: " + C.Element("NetWorth").Value);
                    }
                    output = "";
                    foreach (string t in temp) output += "\n" + t;
                    break;
                }
            }
            Console.WriteLine(output);
        }

        #endregion
        
    }
}