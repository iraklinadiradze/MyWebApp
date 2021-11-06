using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Core;
using DataAccessLayer;
using Application.Common.Interfaces;

namespace Application.Domains.Core.Currency.Commands.CreateCurrency
{
    public class CreateCurrencyCommand : IRequest<DataAccessLayer.Model.Core.Currency>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Core.Currency currency { get; set; }
    }

    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, DataAccessLayer.Model.Core.Currency>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateCurrencyCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Core.Currency> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = request.currency;

            _context.Currency.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
