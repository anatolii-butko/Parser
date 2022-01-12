using System;
using System.Collections.Generic;
using System.Xml;

namespace parsing
{
    class Program
    {
        class Contact
        {
            public string Name { get; set; }
            public string PhoneType { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string NetWorth { get; set; }
            public string Street1 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Postal { get; set; }
        }
        static void Main(string[] args)
        {
            string checkname = Console.ReadLine();
            XmlDocument xDoc = new XmlDocument();
            const string Filename = @"C:\contacts.xml";
            xDoc.Load(Filename);
            List<Contact> contacts = new List<Contact>();
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null && xRoot.HasChildNodes)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    Contact contact = new Contact();
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

                foreach (Contact c in contacts)
                {
                    if (checkname == c.Name)
                    {
                        Console.WriteLine($"Name: {c.Name}\nPhone: {c.PhoneType} {c.Phone}\nAddress: Street1 {c.Street1}, City {c.City}, State {c.State}, Postal {c.Postal}\nNetWorth: {c.NetWorth}");
                    }
                        

                      
                }  
            }
        }
    }
}
