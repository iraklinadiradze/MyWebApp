using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using Application.Model.GeneralLedger;
using Application;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.GeneralLedger.GlTransactionDetail.Queries.GetGlTransactionDetail
{

    public class GetGlTransactionDetailQuery : IRequest<Application.Model.GeneralLedger.GlTransactionDetail>
    {
        public int? Id { get; set; }
    }

    public class GetGlTransactionDetailQueryHandler : IRequestHandler<GetGlTransactionDetailQuery, Application.Model.GeneralLedger.GlTransactionDetail>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetGlTransactionDetailQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<Application.Model.GeneralLedger.GlTransactionDetail> Handle(GetGlTransactionDetailQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.GlTransactionDetail
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(GlTransactionDetail), request.Id);
            }

            return entity;

        }

    }
}
