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
        #region Public Methods
        /// <summary>
        /// A method that performs the program.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Enter the first name or last name of contact you want to know about : : ");
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
                            contact.FirstName = contact.Name.Substring(0, contact.Name.IndexOf(' '));
                            contact.LastName = contact.Name.Substring(contact.Name.IndexOf(' ') + 1, contact.Name.Length - contact.Name.IndexOf(' ') - 1);
                        }

                        if (childnode.Name == "Phone")
                        {
                            XmlNode attr = childnode.Attributes.GetNamedItem("Type");
                            if (attr.Value == "home")
                            {                                
                                contact.PhoneHome = childnode.InnerText;
                                contact.Phone += ", " + attr?.Value + " " + contact.PhoneHome;                                
                            }
                            if (attr.Value == "work")
                            {
                                contact.PhoneWork = childnode.InnerText;
                                contact.Phone += ", " + attr?.Value + " " + contact.PhoneWork;                                
                            }
                            if (attr.Value == "mobile")
                            {
                                contact.PhoneMobile = childnode.InnerText;
                                contact.Phone += ", " + attr?.Value + " " + contact.PhoneMobile;                                
                            }
                            if (attr.Value == "private")
                            {
                                contact.PhonePrivate = childnode.InnerText;
                                contact.Phone += ", " + attr?.Value + " " + contact.PhonePrivate;                                
                            }
                            contact.Phone = contact.Phone.TrimStart(',');
                            contact.Phone = contact.Phone.TrimStart(' ');
                        }

                        // Iterate over all childnodes (childnodeNext) in the childnode element.
                        if (childnode.Name == "Address" && childnode.HasChildNodes)
                        {
                            foreach (XmlNode childnodeNext in childnode.ChildNodes)
                            {
                                if (childnodeNext.Name == "Street1")
                                {
                                    contact.Street1 = childnodeNext.InnerText;                                    
                                    contact.Address += ", " + childnodeNext.Name + " " + contact.Street1;                                        
                                    
                                }
                                if (childnodeNext.Name == "City")
                                {
                                    contact.City = childnodeNext.InnerText;                                    
                                    contact.Address += ", " + childnodeNext.Name + " " + contact.City;                                        
                                    
                                }
                                if (childnodeNext.Name == "State")
                                {
                                    contact.State = childnodeNext.InnerText;                                    
                                    contact.Address += ", " + childnodeNext.Name + " " + contact.State;                                        
                                    
                                }
                                if (childnodeNext.Name == "Postal")
                                {
                                    contact.Postal = childnodeNext.InnerText;                                    
                                    contact.Address += ", " + childnodeNext.Name + " " + contact.Postal;                                        
                                    
                                }
                                contact.Address = contact.Address.TrimStart(',');
                                contact.Address = contact.Address.TrimStart(' ');
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
                    if (check == c.FirstName || check == c.LastName || check == c.Name)
                    {
                        if (c.NetWorth == "None")
                        {
                            message = "Name: " + c.Name + "\nPhone: " + c.Phone + "\nAddress: " + c.Address + "\nNetWorth: " + "There is no salary increase";
                        }
                        else
                        {
                            message = "Name: " + c.Name + "\nPhone: " + c.Phone + "\nAddress: " + c.Address + "\nNetWorth: " + c.NetWorth;
                        }
                    }
                }
                Console.WriteLine(message);
            }
        }
        #endregion        
    }
}
