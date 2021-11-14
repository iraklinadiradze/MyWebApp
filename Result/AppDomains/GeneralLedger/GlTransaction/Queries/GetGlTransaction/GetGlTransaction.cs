using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.GeneralLedger;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.GeneralLedger.GlTransaction.Queries.GetGlTransaction
{

    public class GetGlTransactionQuery : IRequest<DataAccessLayer.Model.GeneralLedger.GlTransaction>
    {
        public int? Id { get; set; }
    }

    public class GetGlTransactionQueryHandler : IRequestHandler<GetGlTransactionQuery, DataAccessLayer.Model.GeneralLedger.GlTransaction>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetGlTransactionQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.GeneralLedger.GlTransaction> Handle(GetGlTransactionQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.GlTransaction
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(GlTransaction), request.Id);
            }

            return entity;

        }

    }
}
