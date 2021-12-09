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

namespace Application.Domains.Client.LegalEntity.Queries.GetLegalEntityList
{

    public class GetLegalEntityListQuery : IRequest<List<LegalEntityView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
public String LegalEntityName {get;set;}
public Int32? RegistrationCountryID {get;set;}
public String TaxCode {get;set;}
    }

    public class GetLegalEntityListQueryHandler : IRequestHandler<GetLegalEntityListQuery, List<LegalEntityView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetLegalEntityListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<LegalEntityView>> Handle(GetLegalEntityListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.LegalEntity
                         join _client in _context.Client on e.Id equals _client.Id into __client
 from _client in __client.DefaultIfEmpty()
 join _country in _context.Country on e.RegistrationCountryID equals _country.Id into __country
 from _country in __country.DefaultIfEmpty()
                        select new LegalEntityView
                           {
                             Id= e.Id,
Email= e.Email,
LegalAddress= e.LegalAddress,
LegalEntityName= e.LegalEntityName,
Mobile= e.Mobile,
OfficeAddress= e.OfficeAddress,
RegistrationCountryID= e.RegistrationCountryID,
TaxCode= e.TaxCode,
TaxRegDate= e.TaxRegDate,
client = new LegalEntityView._Client{
Id= _client.Id,
Name= _client.Name
},
country = new LegalEntityView._Country{
Id= _country.Id,
Code= _country.Code,
Name= _country.Name
}
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

                if (request.LegalEntityName!= null) 
 result = result.Where(r => r.LegalEntityName.StartsWith(request.LegalEntityName));

                if (request.RegistrationCountryID!= null) 
 result = result.Where(r => r.RegistrationCountryID== request.RegistrationCountryID);

                if (request.TaxCode!= null) 
 result = result.Where(r => r.TaxCode== request.TaxCode);

            return (List<LegalEntityView>)await result.ToListAsync(cancellationToken);
        }

    }
}
