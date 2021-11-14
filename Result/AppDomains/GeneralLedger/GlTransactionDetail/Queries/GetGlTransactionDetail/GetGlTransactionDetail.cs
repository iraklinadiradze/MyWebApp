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

namespace Application.Domains.GeneralLedger.GlTransactionDetail.Queries.GetGlTransactionDetail
{

    public class GetGlTransactionDetailQuery : IRequest<DataAccessLayer.Model.GeneralLedger.GlTransactionDetail>
    {
        public int? Id { get; set; }
    }

    public class GetGlTransactionDetailQueryHandler : IRequestHandler<GetGlTransactionDetailQuery, DataAccessLayer.Model.GeneralLedger.GlTransactionDetail>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetGlTransactionDetailQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<DataAccessLayer.Model.GeneralLedger.GlTransactionDetail> Handle(GetGlTransactionDetailQuery request, CancellationToken cancellationToken)
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
