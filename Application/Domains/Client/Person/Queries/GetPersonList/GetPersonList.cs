using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Client;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Client.Person.Queries.GetPersonList
{

    public class GetPersonListQuery : IRequest<List<PersonView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
public DateTime? BirthDate_from {get;set;}
public DateTime? BirthDate_to {get;set;}
public Int32? CitizenShipId {get;set;}
public String FirstName {get;set;}
public String LastName {get;set;}
public String PersonalId {get;set;}
    }

    public class GetPersonListQueryHandler : IRequestHandler<GetPersonListQuery, List<PersonView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetPersonListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<PersonView>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Person
                         join _client in _context.Client on e.Id equals _client.Id into __client
 from _client in __client.DefaultIfEmpty()
 join _country in _context.Country on e.CitizenShipId equals _country.Id into __country
 from _country in __country.DefaultIfEmpty()
                        select new PersonView
                           {
                             Id= e.Id,
Address= e.Address,
BirthDate= e.BirthDate,
CitizenShipId= e.CitizenShipId,
Email= e.Email,
FirstName= e.FirstName,
LastName= e.LastName,
Mobile= e.Mobile,
PersonalId= e.PersonalId,
client = new PersonView._Client{
Id= _client.Id,
Name= _client.Name
},
country = new PersonView._Country{
Id= _country.Id,
Code= _country.Code,
Name= _country.Name
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

                if (request.BirthDate_from!= null) 
 result = result.Where(r => r.BirthDate>= request.BirthDate_from);

                if (request.BirthDate_to!= null) 
 result = result.Where(r => r.BirthDate<= request.BirthDate_to);

                if (request.CitizenShipId!= null) 
 result = result.Where(r => r.CitizenShipId== request.CitizenShipId);

                if (request.FirstName!= null) 
 result = result.Where(r => r.FirstName.StartsWith(request.FirstName));

                if (request.LastName!= null) 
 result = result.Where(r => r.LastName.StartsWith(request.LastName));

                if (request.PersonalId!= null) 
 result = result.Where(r => r.PersonalId== request.PersonalId);

            return (List<PersonView>)await result.ToListAsync(cancellationToken);
        }

    }
}
