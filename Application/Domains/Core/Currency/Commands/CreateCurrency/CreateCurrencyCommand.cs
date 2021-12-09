using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Model.Core;
using Application;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Core.Currency.Commands.CreateCurrency
{
    public class CreateCurrencyCommand : IRequest<Application.Model.Core.Currency>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public Application.Model.Core.Currency Currency { get; set; }
    }

    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, Application.Model.Core.Currency>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateCurrencyCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<Application.Model.Core.Currency> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Currency;

            _context.Currency.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
