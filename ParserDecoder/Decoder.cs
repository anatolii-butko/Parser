namespace ParserDecoder
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;
    using System.Xml.XPath;

    #endregion

    /// <summary>
    /// The class which contains decoder.
    /// </summary>
    public class Decoder
    {

        #region Public Methods

        /// <summary>
        /// A method that parse and decodes Decoder.xml file.
        /// </summary>        
        public void MyDecoder()
        {
            Console.WriteLine("Enter file full path and name of file you want to decode: ");
            string path = Console.ReadLine();
            while (!File.Exists(path))
            {
                Console.WriteLine("File dont exist or incorect path! Please try again.");
                Console.WriteLine("Enter file full path and name of file you want to decode: ");
                path = Console.ReadLine();
            }
            Console.WriteLine("Enter the ID of message you want to decode: ");
            string checkId = Console.ReadLine();
            var xdoc = XDocument.Load(path);
            List<string> temp = new List<string>();
            string output = "Incorrect data! Please check your input and try again.";
            do
            {
                foreach (var childElem2 in xdoc.XPathSelectElements("//Message"))
                {
                    if (childElem2.Attribute("ID").Value == checkId)
                    {
                        temp.Add(childElem2.Attribute("ID").Value);
                        temp.Add(childElem2.Attribute("File").Value);
                        temp.Add(childElem2.Attribute("Line").Value);
                        temp.Add(childElem2.Value);
                        foreach (var childElem in xdoc.XPathSelectElements("//File"))
                        {
                            if (childElem2.Attribute("File").Value == childElem.Attribute("ID").Value)
                            {
                                temp.Add(childElem.Value);
                                output = $"ID {temp[0]}\nFile {temp[1]}\nLine {temp[2]}\nText {temp[3]}\nPath {temp[4] }\n";
                                break;
                            }
                        }
                        break;
                    }
                }
                Console.WriteLine(output);
                Console.WriteLine("Enter the ID of message you want to decode: ");
                checkId = Console.ReadLine();
            } while (output != null);

        }

        #endregion

    }
}
