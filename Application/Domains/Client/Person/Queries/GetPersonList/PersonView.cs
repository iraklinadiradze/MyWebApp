using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLayer.Model.Client;


namespace Application.Domains.Client.Person.Queries.GetPersonList
{
    public class PersonView: DataAccessLayer.Model.Client.Person
    {

          public class _Client
{
 public Int32 Id {get; set;} 
 public String Name {get; set;} 
}

public class _Country
{
 public Int32 Id {get; set;} 
 public String Code {get; set;} 
 public String Name {get; set;} 
}

           public _Client client {get; set;} 

 public _Country country {get; set;} 

    }
}
