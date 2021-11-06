using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataAccessLayer.Model.Product;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;

namespace Application.Domains.Product.ProductGroupTemplate.Commands.UpdateProductGroupTemplate
{
    public class UpdateProductGroupTemplateCommand : IRequest<DataAccessLayer.Model.Product.ProductGroupTemplate>
    {
        public int senderId { get; set; }  = 0;
        public DataAccessLayer.Model.Product.ProductGroupTemplate productGroupTemplate { get; set; }
    }

    public class UpdateProductGroupTemplateCommandHandler : IRequestHandler<UpdateProductGroupTemplateCommand, DataAccessLayer.Model.Product.ProductGroupTemplate>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdateProductGroupTemplateCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductGroupTemplate> Handle(UpdateProductGroupTemplateCommand request, CancellationToken cancellationToken)
        {

            var entity = request.productGroupTemplate;

            var _entity = await _context.ProductGroupTemplate.FindAsync(request.productGroupTemplate.Id);

            if (_entity == null)
            {
                throw new NotFoundException(nameof(ProductGroupTemplate), entity.Id);
            }

            _context.ProductGroupTemplate.Update(entity); // Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
