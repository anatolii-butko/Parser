using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace parsing
{
    /// <summary>
	/// The class which contains test steps .
	/// </summary>
    class Test
    {
        /// <summary>
        /// A method that performs the test case.
        /// </summary>
        /// <param>
        /// Method without parametrs. Accepts console input.
        /// </param>
        /// <returns>
        /// Returns(void) 
        public void Run()
        {
            Console.WriteLine("Enter the name you want to know about : ");
            string checkname = Console.ReadLine();
            this.MyParser(checkname);
            
        }
        /// <summary>
        /// A method that parses the specified file by creating contact class objects with properties similar to the tags in the file.
        /// </summary>
        /// <param>
        /// paramname: string check, the name you want to check.
        /// </param>
        /// <returns>
        /// Returns(void) Displays input-related data to the console if it is present in the file.
        /// </returns>
        public void MyParser(string check)
        {
            string path = @"C:\contacts.xml";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            List<Contact> contacts = new List<Contact>();
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null && xRoot.HasChildNodes)
            {
                //iterate over all nodes in the root element
                foreach (XmlElement xnode in xRoot)
                {
                    Contact contact = new Contact();
                    //iterate over all childnodes in the node element
                    foreach (XmlElement childnode in xnode)
                    {
                        if (childnode.Name == "Name")
                        {
                            contact.Name = childnode.InnerText;
                        }
                        if (childnode.Name == "Phone")
                        {
                            XmlNode attr = childnode.Attributes.GetNamedItem("Type");
                            contact.PhoneType = attr?.Value;
                            contact.Phone = childnode.InnerText;
                        }
                        //iterate over all childnodes(childnode1) in the childnode element
                        if (childnode.Name == "Address" && childnode.HasChildNodes)
                        {
                            foreach (XmlNode childnode1 in childnode.ChildNodes)
                            {
                                if (childnode1.Name == "Street1")
                                {
                                    contact.Street1 = childnode1.InnerText;
                                }
                                if (childnode1.Name == "City")
                                {
                                    contact.City = childnode1.InnerText;
                                }
                                if (childnode1.Name == "State")
                                {
                                    contact.State = childnode1.InnerText;
                                }
                                if (childnode1.Name == "Postal")
                                {
                                    contact.Postal = childnode1.InnerText;
                                }
                            }
                        }
                        if (childnode.Name == "NetWorth")
                        {
                            contact.NetWorth = childnode.InnerText;
                        }
                    }
                    contacts.Add(contact);
                }
                //assigned to the variable initial value in case the search found nothing
                string message = "Incorrect data! Please check your input and try again.";
                foreach (Contact c in contacts)
                {
                    if (check == c.Name)
                    {
                        message = "Name: " + c.Name + "\nPhone: " + c.PhoneType + c.Phone + "\nAddress: Street1 " + c.Street1 + ", " + "City " + c.City + ", " + "State " + c.State + ", " + "Postal " + c.Postal + "\nNetWorth: " + c.NetWorth;
                    }
                }
                Console.WriteLine(message);
            }
        }
    }
}
