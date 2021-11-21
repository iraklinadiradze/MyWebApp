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

namespace Application.Domains.Product.ProductGroupTemplate.Commands.CreateProductGroupTemplate
{
    public class CreateProductGroupTemplateCommand : IRequest<DataAccessLayer.Model.Product.ProductGroupTemplate>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Product.ProductGroupTemplate ProductGroupTemplate { get; set; }
    }

    public class CreateProductGroupTemplateCommandHandler : IRequestHandler<CreateProductGroupTemplateCommand, DataAccessLayer.Model.Product.ProductGroupTemplate>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public CreateProductGroupTemplateCommandHandler(IMediator mediator, ICoreDBContext context)
        {
           _mediator = mediator;
           _context = context;
        }

        public async Task<DataAccessLayer.Model.Product.ProductGroupTemplate> Handle(CreateProductGroupTemplateCommand request, CancellationToken cancellationToken)
        {
            var entity = request.ProductGroupTemplate;

            _context.ProductGroupTemplate.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

            return entity;
         }

    }

}
