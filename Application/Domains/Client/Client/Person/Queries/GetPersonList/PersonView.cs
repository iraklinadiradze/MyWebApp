using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Client;


namespace Application.Domains.Client.Person.Queries.GetPersonList
{
    public class PersonView: DataAccessLayer.Model.Client.Person
    {

          Int32 Id {get; set;} 
String Address {get; set;} 
DateTime? BirthDate {get; set;} 
Int32 CitizenShipId {get; set;} 
String Email {get; set;} 
String FirstName {get; set;} 
String LastName {get; set;} 
String Mobile {get; set;} 
String PersonalId {get; set;} 
Int32 Version {get; set;} 

          private class Client
{
Int32 Id {get; set;} 
String Name {get; set;} 
}

private class Country
{
Int32 Id {get; set;} 
String Code {get; set;} 
String Name {get; set;} 
}

          Client client {get; set;} 

Country country {get; set;} 

    }
}
