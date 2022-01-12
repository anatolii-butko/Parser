using System.Xml.Serialization;

public class Contacts 
{   
    public Contact[] Items { get; set; }
}

public class Contact 
{
    private Phone[] phoneField;
    
    private Address[] addressField;
    
    public string Name { get; set; }
       
    public string NetWorth { get; set; }
      
    public Phone[] Phone { get; set; }
        
    public class Address[] Address { get; set; }
}

public class Phone 
{
    public string Type { get; set; }
    
    public string Value { get; set; }
}

public class CAddress 
{
    public string Street1 { get; set; }
     
    public string City { get; set; }
    
    public string State { get; set; }
    
    public string Postal { get; set; }
}
