using System;
using System.Collections.Generic;
using System.Xml;

namespace Parser
{
    /// <summary>
	/// The class which contains test steps.
	/// </summary>
    class Parser
    {
        /// <summary>
        /// A method that performs the program.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Enter the name you want to know about : ");
            string checkname = Console.ReadLine();
            this.MyParser(checkname);
            
        }

        /// <summary>
        /// A method that parses contacts.xml file.
        /// </summary>
        /// <param name="check">
        /// The person name you want to check.
        /// </param>
        public void MyParser(string check)
        {
            string path = @"C:\contacts.xml";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            List<Contact> contacts = new List<Contact>();
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null && xRoot.HasChildNodes)
            {
                // Iterate over all nodes in the root element.
                foreach (XmlElement xnode in xRoot)
                {
                    Contact contact = new Contact();

                    // Iterate over all childnodes in the node element.
                    foreach (XmlElement childnode in xnode)
                    {
                        if (childnode.Name == "Name")
                        {
                            contact.Name = childnode.InnerText;
                        }
                        var phones = new CList<string>();
                        string phone;
                        if (childnode.Name == "Phone")
                        {
                            XmlNode attr = childnode.Attributes.GetNamedItem("Type");
                            contact.PhoneType = attr?.Value;
                            contact.PhoneValue = childnode.InnerText;
                            phone = (contact.PhoneType + " " + contact.PhoneValue);
                            phones.Add(phone);
                            contact.Phone = phones.ToString();
                            Console.WriteLine(phone);
                            
                            phones.Clear();
                        }
                        
                        // Iterate over all childnodes (childnodeNext) in the childnode element.
                        if (childnode.Name == "Address" && childnode.HasChildNodes)
                        {
                            foreach (XmlNode childnodeNext in childnode.ChildNodes)
                            {
                                if (childnodeNext.Name == "Street1")
                                {
                                    contact.Street1 = childnodeNext.InnerText;
                                }
                                if (childnodeNext.Name == "City")
                                {
                                    contact.City = childnodeNext.InnerText;
                                }
                                if (childnodeNext.Name == "State")
                                {
                                    contact.State = childnodeNext.InnerText;
                                }
                                if (childnodeNext.Name == "Postal")
                                {
                                    contact.Postal = childnodeNext.InnerText;
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
                // Assigned to the variable initial value in case the search found nothing.
                string message = "Incorrect data! Please check your input and try again.";
                foreach (Contact c in contacts)
                {
                    if (check == c.Name)
                    {
                        if (c.NetWorth == "None")
                        {
                            c.NetWorth = "There is no salary increase.";
                        }
                        message = "Name: " + c.Name + "\nPhone: " + c.PhoneType + " " + c.PhoneValue + " " + c.Phone + "\nAddress: Street1 " + c.Street1 + ", " + "City " + c.City + ", " + "State " + c.State + ", " + "Postal " + c.Postal + "\nNetWorth: " + c.NetWorth;
                    }
                }
                Console.WriteLine(message);
            }
        }
    }
}
