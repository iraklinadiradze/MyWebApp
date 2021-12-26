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

            _logger.Information("Purchase Retrieved: {@Purchase}", purchase);


            // Validate Post Actions

            if (request.PurchaseAction == PurchaseAction.paFullPost)
            {
                if (purchase.Posted)
                    throw new InvalidOperationException("PurchaseIsAlreadyPosted");
            }

            if (request.PurchaseAction == PurchaseAction.paQtyPost)
            {
                if (purchase.QtyPosted)
                    throw new InvalidOperationException("PurchaseIsAlreadyQtyPosted");
            }

            if (request.PurchaseAction == PurchaseAction.paFinPost)
            {
                if (purchase.FinPosted)
                    throw new InvalidOperationException("PurchaseIsAlreadyFinPosted");

                if ((!purchase.QtyPosted) && (request.PurchaseDetailId == null))
                    throw new InvalidOperationException("PurchaseQtyShouldBePosted");
            }


            // Validate Unpost Actions

            if (request.PurchaseAction == PurchaseAction.paFullUnpost)
            {
                if (!purchase.Posted)
                    throw new InvalidOperationException("PurchaseIsAlreadyUnposted");
            }

            if (request.PurchaseAction == PurchaseAction.paFinUnpost)
            {
                if (!purchase.FinPosted)
                    throw new InvalidOperationException("PurchaseIsAlreadyFinUnposted");
            }

            if (request.PurchaseAction == PurchaseAction.paQtyUnpost)
            {
                if (!purchase.QtyPosted)
                    throw new InvalidOperationException("PurchaseIsAlreadyQtyUnposted");

                if ((purchase.FinPosted) && (request.PurchaseDetailId == null))
                    throw new InvalidOperationException("PurchaseFinShouldBeUnposted");
            }

            /*
            if (request.PurchaseAction == PurchaseAction.paFullUnpostWithDetails)
            {

            }

            if (request.PurchaseAction == PurchaseAction.paQtyUnpostWithDetails)
            {

            }

            if (request.PurchaseAction == PurchaseAction.paFinUnpostWithDetails)
            {

            }
            */


            if (
                (new PurchaseAction[]{
                PurchaseAction.paFullUnpost,
                PurchaseAction.paQtyUnpost,
                PurchaseAction.paQtyUnpostWithDetails,
                PurchaseAction.paFullUnpostWithDetails
                }).Any(q => q == request.PurchaseAction)
                &&
                //                (request.PurchaseDetailId == null)
                //                &&
                (purchase.QtyPosted)
                )
            {
                purchase.QtyPosted = false;
                purchase.Posted = false;
                _context.Purchase.Update(purchase);
            }

            if (
                (new PurchaseAction[]{
                PurchaseAction.paFullUnpost,
                PurchaseAction.paFinUnpost,
                PurchaseAction.paFullUnpostWithDetails,
                PurchaseAction.paFinUnpostWithDetails
                }).Any(q => q == request.PurchaseAction)
                &&
                //                (request.PurchaseDetailId == null)
                //                &&
                (purchase.FinPosted)
                )
            {
                purchase.FinPosted = false;
                purchase.Posted = false;
                _context.Purchase.Update(purchase);
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

                    if (
                        (request.PurchaseAction == PurchaseAction.paFullPost)
                        &&
                        (request.PurchaseDetailId != null)
                       )
                    {
                        if (purchaseDetail.Posted)
                            throw new InvalidOperationException("PurchaseDetailIsAlreadyPosted");
                    }

                    if (
                        (request.PurchaseAction == PurchaseAction.paQtyPost)
                        &&
                        (request.PurchaseDetailId != null)
                       )
                    {
                        if (purchaseDetail.QtyPosted)
                            throw new InvalidOperationException("PurchaseDetailQtyIsAlreadyPosted");
                    }

                    if (request.PurchaseAction == PurchaseAction.paFinPost)
                    {
                        if ((purchaseDetail.FinPosted) && (request.PurchaseDetailId != null))
                            throw new InvalidOperationException("PurchaseDetailFinIsAlreadyPosted");

                        if (!purchaseDetail.QtyPosted)
                            throw new InvalidOperationException("PurchaseDetailQtyShouldBePosted");
                    }

                    if (
                        (request.PurchaseAction == PurchaseAction.paFullUnpost)
                        ||
                        (request.PurchaseAction == PurchaseAction.paFullUnpostWithDetails)
                       )
                    {
                        if ((!purchaseDetail.Posted) && (request.PurchaseDetailId != null))
                            throw new InvalidOperationException("PurchaseDetailIsAlreadyUnposted");
                    }

                    if (
                        (request.PurchaseAction == PurchaseAction.paQtyUnpost)
                        ||
                        (request.PurchaseAction == PurchaseAction.paQtyUnpostWithDetails)
                       )
                    {
                        if ((!purchaseDetail.QtyPosted) && (request.PurchaseDetailId != null))
                            throw new InvalidOperationException("PurchaseDetailQtyIsAlreadyUnposted");

                        if (!purchaseDetail.FinPosted)
                            throw new InvalidOperationException("PurchaseDetailFinShouldBeUnposted");
                    }

                    if (
                        (request.PurchaseAction == PurchaseAction.paFinUnpost)
                        ||
                        (request.PurchaseAction == PurchaseAction.paFinUnpostWithDetails)
                       )
                    {
                        if ((!purchaseDetail.FinPosted) && (request.PurchaseDetailId != null))
                            throw new InvalidOperationException("PurchaseDetailFinIsAlreadyUnposted");
                    }


                    bool detailQtyPostAction = false;
                    bool detailFinPostAction = false;

                    if (
                        (!purchaseDetail.QtyPosted)
                        &&
                        (
                        (request.PurchaseAction == PurchaseAction.paFullPost)
                        ||
                        (request.PurchaseAction == PurchaseAction.paQtyPost)
                        )
                       )
                    {
                        detailQtyPostAction = true;
                    }

                    if (
                        (purchaseDetail.QtyPosted)
                        &&
                        (
                        (request.PurchaseAction == PurchaseAction.paFullUnpostWithDetails)
                        ||
                        (request.PurchaseAction == PurchaseAction.paQtyUnpostWithDetails)
                        )
                       )
                        detailQtyPostAction = false;

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
                        detailFinPostAction = true;
                    }

                    if (
                    (purchaseDetail.FinPosted)
                    &&
                    (
                    (request.PurchaseAction == PurchaseAction.paFinUnpostWithDetails)
                    ||
                    (request.PurchaseAction == PurchaseAction.paFullUnpostWithDetails)
                    //                    ||
                    //                    (request.PurchaseAction == PurchaseAction.paQtyUnpostWithDetails)
                    )
                   )
                        detailFinPostAction = false;

                    if (
                        (purchaseDetail.QtyPosted != detailQtyPostAction)
                        ||
                        (purchaseDetail.FinPosted != detailFinPostAction)
                        )
                    {
                        var _result = await _mediator.Send(
                        new UpdatePurchaseDetailStatusCommand
                        {
                            PurchaseDetail = purchaseDetail,
                            TransDate = purchase.TransDate,
                            doQtyPost = detailQtyPostAction,
                            doCostPost = detailFinPostAction
                        }
                        );
                    }

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
