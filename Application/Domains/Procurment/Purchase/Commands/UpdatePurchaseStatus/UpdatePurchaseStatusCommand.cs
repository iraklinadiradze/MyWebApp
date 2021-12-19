using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

using Application.Model.Procurment;
using Application;
using Application.Common.Interfaces;
using Application.Common;
using Application.Domains.Procurment.PurchaseDetail.Commands.UpdatePurchaseDetailStatusCommand;
using Microsoft.Extensions.Logging;
using Serilog;


namespace Application.Domains.Procurment.Purchase.Commands.UpdatePurchaseStatusCommand
{
    public class UpdatePurchaseStatusCommand : IRequest<Application.Model.Procurment.Purchase>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
        public int? PurchaseDetailId { get; set; }
        public PurchaseAction PurchaseAction { get; set; }
    }

    public class UpdatePurchaseStatusCommandHandler : IRequestHandler<UpdatePurchaseStatusCommand, Application.Model.Procurment.Purchase>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;
        private readonly Serilog.ILogger _logger;

        public UpdatePurchaseStatusCommandHandler(IMediator mediator, ICoreDBContext context, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _context = context;
            _logger = logger;
        }

        public async Task<Application.Model.Procurment.Purchase> Handle(UpdatePurchaseStatusCommand request, CancellationToken cancellationToken)
        {

            _logger.Information("Request UpdatePurchaseStatusCommandHandler: {@Request}", request);

            var purchase = await _context.Purchase.FindAsync(request.Id);

            //            _logger.Information("Purchase: Id = {Id}; TransDate = {TransDate}; "
            //                , purchase.Id, purchase.TransDate, purchase.QtyPosted, purchase.FinPosted,
            //                purchase.Posted
            //             );

            _logger.Information("Purchase: {@Purchase}", purchase);

            if (
                (new PurchaseAction[]{
                PurchaseAction.paFullUnpost,
                PurchaseAction.paQtyUnpost,
                PurchaseAction.paQtyUnpostWithDetails
                }).Any(q => q == request.PurchaseAction)
                &&
                (request.PurchaseDetailId == null)
                &&
                (purchase.QtyPosted)
                )
            {
                purchase.QtyPosted = false;
            }
            else
            {
//                throw new Exception("Purchase #{purchase.id} is already Unposted");
            }

            if (
                (new PurchaseAction[]{
                PurchaseAction.paFullUnpost,
                PurchaseAction.paFinUnpost,
                PurchaseAction.paFullUnpostWithDetails,
                }).Any(q => q == request.PurchaseAction)
                &&
                (request.PurchaseDetailId == null)
                &&
                (purchase.FinPosted)
                )
            {
                purchase.FinPosted = false;
            }

            // if action requires iteration through details
            if (
                (new PurchaseAction[]{
                PurchaseAction.paFullPost,
                PurchaseAction.paQtyPost,
                PurchaseAction.paFinPost,
                PurchaseAction.paFullUnpostWithDetails,
                PurchaseAction.paFinUnpostWithDetails,
                PurchaseAction.paQtyUnpostWithDetails
                }).Any(q => q == request.PurchaseAction)
                &&
                (request.PurchaseDetailId == null)
                )
            {

                _logger.Information("Start Purchase Detail Post/Unpost");

                foreach (
                    var purchaseDetail in _context.PurchaseDetail.Where(q =>
                    (q.PurchaseId == purchase.Id)
                    &&
                    ((request.PurchaseDetailId == null) || (q.Id == request.PurchaseDetailId))
                    )
                )
                {
                    bool detailQtyPost = false;
                    bool detailFinPost = false;

                    if (
                        (!purchaseDetail.QtyPosted)
                        &&
                        (
                        (request.PurchaseAction == PurchaseAction.paFullPost)
                        ||
                        (request.PurchaseAction == PurchaseAction.paQtyPost)
                        )
                       )
                        detailQtyPost = true;

                    if (
                        (purchaseDetail.QtyPosted)
                        &&
                        (
                        (request.PurchaseAction == PurchaseAction.paFullUnpostWithDetails)
                        ||
                        (request.PurchaseAction == PurchaseAction.paQtyUnpostWithDetails)
                        )
                       )
                        detailQtyPost = false;

                    if (
                        (!purchaseDetail.FinPosted)
                        &&
                        (
                        (request.PurchaseAction == PurchaseAction.paFullPost)
                        ||
                        (request.PurchaseAction == PurchaseAction.paFinPost)
                        )
                       )
                    {
                        detailFinPost = true;
                        detailQtyPost = true;
                    }

                        if (
                        (purchaseDetail.FinPosted)
                        &&
                        (
                        (request.PurchaseAction == PurchaseAction.paFinUnpostWithDetails)
                        ||
                        (request.PurchaseAction == PurchaseAction.paFullUnpostWithDetails)
                        ||
                        (request.PurchaseAction == PurchaseAction.paQtyUnpostWithDetails)
                        )
                       )
                        detailFinPost = false;

                    _logger.Information("Request: {@Request}", request);

                    var _result = await _mediator.Send(
                        new UpdatePurchaseDetailStatusCommand
                        {
                            PurchaseDetail = purchaseDetail,
                            TransDate = purchase.TransDate,
                            doQtyPost = detailQtyPost,
                            doCostPost = detailFinPost
                        }
                        );
                }

                _logger.Information("End Purchase Detail Post/Unpost");

            }

            var finalPurchaseStatus = (from x in _context.PurchaseDetail
                     where x.PurchaseId == purchase.Id
                     group x by 0 into y
                     select new
                     {
                         finPostStartedNew = (bool)(y.Sum(z => z.FinPosted ? 1 : 0) > 0) ? true : false,
                         qtyPostStartedNew = (bool)(y.Sum(z => z.QtyPosted ? 1 : 0) > 0) ? true : false,
                         finPostedNew = (bool)(y.Min(z => z.FinPosted ? 1 : 0) == 0) ? true : false,
                         qtyPostedNew = (bool)(y.Min(z => z.QtyPosted ? 1 : 0) == 0) ? true : false
                     }).First();


            purchase.FinPostStarted = finalPurchaseStatus.finPostStartedNew;
            purchase.QtyPostStarted = finalPurchaseStatus.qtyPostStartedNew;
            purchase.FinPosted = finalPurchaseStatus.finPostedNew;
            purchase.QtyPosted = finalPurchaseStatus.qtyPostedNew;

            _logger.Information("Purchase Result Status: {@ResultStatus}", finalPurchaseStatus);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.Information("Final Purchase Result: {@Purchase}", purchase);

            return purchase;
        }
    }

}
