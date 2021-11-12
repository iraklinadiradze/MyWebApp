using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Inventory;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Inventory.Movement.Queries.GetMovementList
{

    public class GetMovementListQuery : IRequest<List<MovementView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          public Int32? id {get;set;}
    }

    public class GetMovementListQueryHandler : IRequestHandler<GetMovementListQuery, List<MovementView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetMovementListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<MovementView>> Handle(GetMovementListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.Movement
                        
                        select new MovementView
                           {
                             Id= e.Id,
ReceiveDate= e.ReceiveDate,
ReceiveFinPostStarted= e.ReceiveFinPostStarted,
ReceiveFinPosted= e.ReceiveFinPosted,
ReceiveLocationId= e.ReceiveLocationId,
ReceivePosted= e.ReceivePosted,
ReceiveQtyPostStarted= e.ReceiveQtyPostStarted,
ReceiveQtyPosted= e.ReceiveQtyPosted,
SendDate= e.SendDate,
SendFinPostStarted= e.SendFinPostStarted,
SendFinPosted= e.SendFinPosted,
SendLocationId= e.SendLocationId,
SendPosted= e.SendPosted,
SendQtyPostStarted= e.SendQtyPostStarted,
SendQtyPosted= e.SendQtyPosted
                           };


                            if (request.id!= null) 
 result = result.Where(r => r.Id== request.id);

            return (List<MovementView>)await result.ToListAsync(cancellationToken);
        }

    }
}
