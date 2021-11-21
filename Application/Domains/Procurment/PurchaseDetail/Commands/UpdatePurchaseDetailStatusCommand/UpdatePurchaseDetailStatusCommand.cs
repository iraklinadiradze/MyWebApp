using System;
using System.Collections.Generic;
using System.Text;

using MediatR;
using DataAccessLayer.Model.Procurment;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;
using System.Threading.Tasks;
using System.Threading;

namespace Application.Domains.Procurment.PurchaseDetail.Commands.UpdatePurchaseDetailStatusCommand
{
    public class UpdatePurchaseDetailStatusCommand : IRequest<int>
    {
//        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Procurment.PurchaseDetail PurchaseDetail { get; set; }
        public bool QtyPost { get; set; }
        public bool FinPost { get; set; }
    }

    public class UpdatePurchaseStatusCommandHandler : IRequestHandler<UpdatePurchaseDetailStatusCommand, int>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseStatusCommandHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public Task<int> Handle(UpdatePurchaseDetailStatusCommand request, CancellationToken cancellationToken)
        {

            var InventoryId;

            _mediator.Send( new )

            return 0;
//            throw new NotImplementedException();
        }
    }

}
