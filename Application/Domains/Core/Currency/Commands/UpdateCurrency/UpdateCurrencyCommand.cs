using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Core;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Application.Common;

namespace Application.Domains.Core.Currency.Commands.UpdateCurrency
{
    public class UpdateCurrencyCommand : IRequest<DataAccessLayer.Model.Core.Currency>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Core.Currency Currency { get; set; }
    }

    public class UpdateCurrencyCommandHandler : IRequestHandler<UpdateCurrencyCommand, DataAccessLayer.Model.Core.Currency>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateCurrencyCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Core.Currency> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {

            var entity = request.Currency;

            var _entity = await _context.Currency.FindAsync(request.Currency.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(Currency), entity.Id);
            }

            _context.Currency.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
