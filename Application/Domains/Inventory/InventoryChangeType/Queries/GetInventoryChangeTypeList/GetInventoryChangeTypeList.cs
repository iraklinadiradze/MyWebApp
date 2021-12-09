using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.Inventory;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Inventory.InventoryChangeType.Queries.GetInventoryChangeTypeList
{

    public class GetInventoryChangeTypeListQuery : IRequest<List<InventoryChangeTypeView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? Id {get;set;}
public String ChangeName {get;set;}
    }

    public class GetInventoryChangeTypeListQueryHandler : IRequestHandler<GetInventoryChangeTypeListQuery, List<InventoryChangeTypeView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetInventoryChangeTypeListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<InventoryChangeTypeView>> Handle(GetInventoryChangeTypeListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.InventoryChangeType
                        
                        select new InventoryChangeTypeView
                           {
                             Id= e.Id,
ChangeCode= e.ChangeCode,
ChangeName= e.ChangeName,
IsFinRelated= e.IsFinRelated,
IsQtyRelated= e.IsQtyRelated
                           };


                            if (request.Id!= null) 
 result = result.Where(r => r.Id== request.Id);

                if (request.ChangeName!= null) 
 result = result.Where(r => r.ChangeName.StartsWith(request.ChangeName));

            return (List<InventoryChangeTypeView>)await result.ToListAsync(cancellationToken);
        }

    }
}
