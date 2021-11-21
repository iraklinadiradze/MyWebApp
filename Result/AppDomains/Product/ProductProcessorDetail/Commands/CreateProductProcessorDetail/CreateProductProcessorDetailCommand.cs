using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Model.Product;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;

namespace Application.Domains.Product.ProductProcessorDetail.Commands.CreateProductProcessorDetail
{
    public class CreateProductProcessorDetailCommand : IRequest<DataAccessLayer.Model.Product.ProductProcessorDetail>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.ProductProcessorDetail ProductProcessorDetail { get; set; }
    }

    public class CreateProductProcessorDetailCommandHandler : IRequestHandler<CreateProductProcessorDetailCommand, DataAccessLayer.Model.Product.ProductProcessorDetail>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductProcessorDetailCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductProcessorDetail> Handle(CreateProductProcessorDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ProductProcessorDetail;

            _context.ProductProcessorDetail.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
