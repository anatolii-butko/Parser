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
            public string Address { get; set; }
            public string NetWorth { get; set; }
        }
        static void Main(string[] args)
        {
            string checkname = Console.ReadLine();
            XmlDocument xDoc = new XmlDocument();
            const string Filename = @"C:\Users\anatolii.butko\source\repos\parsing\contacts.xml";
            xDoc.Load(Filename);
            List<Contact> contacts = new List<Contact>();
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null && xRoot.HasChildNodes)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    Contact contact = new Contact();
                    if (xnode.Name == "Name")
                    {
                        contact.Name = xnode.InnerText;
                    }

                    if (xnode.Name == "Phone Type")
                    {
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            XmlNode attr = childnode.Attributes.GetNamedItem("Phone Type");
                            contact.PhoneType = attr?.Value;
                            contacts.Add(contact);
                        }
                    }

                    if (xnode.Name == "Address")
                    {
                        contact.Address = xnode.InnerText;
                    }

                    if (xnode.Name == "NetWorth")
                    {
                        contact.NetWorth = xnode.InnerText;
                    }
                        
                    contacts.Add(contact);
                }

                foreach (Contact c in contacts)
                {
                    if (checkname == c.Name)
                    {
                        Console.WriteLine($"{c.Name} - {c.PhoneType} - {c.Address} - {c.NetWorth}");
                    }   
                }  
            }
        }
    }
}
