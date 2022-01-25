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
            while (!File.Exists(path))
            {
                Console.WriteLine("File dont exist or incorect path! Please try again.");
                Console.WriteLine("Enter file full path and name of file you want to parse: ");
                path = Console.ReadLine(); 
            }
            Console.WriteLine("Enter the first name or last name of contact you want to know about: ");
            string check = Console.ReadLine();
            var xdoc = XDocument.Load(path);
            List<string> temp = new List<string>();
            string output = "Incorrect data! Please check your input and try again.";
            foreach (var childElem in xdoc.XPathSelectElements("//Contact"))
            {
                string name = childElem.Element("Name").Value;
                string firstname = name.Substring(0, name.IndexOf(' '));
                string lastname = name.Substring(name.IndexOf(' ') + 1, name.Length - name.IndexOf(' ') - 1);
                if (name == check || firstname == check || lastname == check)
                {
                    temp.Add("Name: " + name);
                    string temp1 = "";
                    foreach (var phoneElem in childElem.Elements("Phone"))
                    {
                        temp1 += ", " + phoneElem.Attribute("Type").Value + " " + phoneElem.Value;                        
                    }
                    temp1 = temp1.TrimStart(',');
                    temp1 = temp1.TrimStart(' ');
                    temp.Add("Phones: " + temp1);
                    string temp2 = "";
                    foreach (var childElem2 in childElem.Element("Address").Elements())
                    {
                        temp2 += ", " + childElem2.Name + " " + childElem2.Value;                        
                    }
                    temp2 = temp2.TrimStart(',');
                    temp2 = temp2.TrimStart(' ');
                    temp.Add("Address: " + temp2);
                    if (childElem.Element("NetWorth").Value == "None")
                    {
                        temp.Add("NetWorth: There is no salary increase");
                    }
                    else
                    {
                        temp.Add("NetWorth: " + childElem.Element("NetWorth").Value);
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