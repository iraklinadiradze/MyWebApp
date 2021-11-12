using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Client;
using DataAccessLayer;

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

          public Int32? id {get;set;}
public DateTime? birthDate {get;set;}
public DateTime? birthDate {get;set;}
public Int32? citizenShipId {get;set;}
public String firstName {get;set;}
public String lastName {get;set;}
public String personalId {get;set;}
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


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

                if (request.birthDate_from!= null) 
 result = result.Where(r => r.BirthDate>= request.birthDate_from);

                if (request.birthDate_to!= null) 
 result = result.Where(r => r.BirthDate<= request.birthDate_to);

                if (request.citizenShipId!= null) 
 result = result.Where(r => r.CitizenShipId== request.citizenShipId);

                if (request.firstName!= null) 
 result = result.Where(r => r.FirstName.StartsWith(request.firstName));

                if (request.lastName!= null) 
 result = result.Where(r => r.LastName.StartsWith(request.lastName));

                if (request.personalId!= null) 
 result = result.Where(r => r.PersonalId== request.personalId);

            return (List<PersonView>)await result.ToListAsync(cancellationToken);
        }

    }
}
