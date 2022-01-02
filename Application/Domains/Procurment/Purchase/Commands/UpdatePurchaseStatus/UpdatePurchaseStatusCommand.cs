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
using Application.Common.Exceptions;

namespace Application.Domains.Procurment.Purchase.Commands.UpdatePurchaseStatusCommand
{
    public class UpdatePurchaseStatusCommand : IRequest<Application.Model.Procurment.Purchase>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
        public long? PurchaseDetailId { get; set; }
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

            _logger.Information("Purchase Retrieved: {@Purchase}", purchase);

            // Validate Post Actions

            if (
                (request.PurchaseAction == PurchaseAction.paCostPost)
                ||
                (request.PurchaseAction == PurchaseAction.paFullPost)
               )
                if (!purchase.Allocated)
                    throw new InvalidActionException("Purchase Should Be Allocated", ModuleEnum.mdPurchase, purchase.Id);


            if (request.PurchaseAction == PurchaseAction.paFullPost)
            {
                if (purchase.Posted)
                    throw new InvalidActionException("Purchase Is Already Posted", ModuleEnum.mdPurchase, request.Id);
            }

            if (request.PurchaseAction == PurchaseAction.paQtyPost)
            {
                if (purchase.QtyPosted)
                    throw new InvalidActionException("Purchase Qty Is Already Posted", ModuleEnum.mdPurchase, request.Id);
            }

            if (request.PurchaseAction == PurchaseAction.paCostPost)
            {
                if (purchase.CostPosted)
                    throw new InvalidActionException("Purchase Cost Is Already Posted", ModuleEnum.mdPurchase, request.Id);

                if ((!purchase.QtyPosted) && (request.PurchaseDetailId == null))
                    throw new InvalidActionException("Purchase Qty Should Be Posted", ModuleEnum.mdPurchase, request.Id);
            }


            // Validate Unpost Actions

            if (request.PurchaseAction == PurchaseAction.paFullUnpost)
            {
                if (!purchase.Posted)
                    throw new InvalidActionException("Purchase Is Already Unposted", ModuleEnum.mdPurchase, request.Id);
            }

            if (request.PurchaseAction == PurchaseAction.paCostUnpost)
            {
                if (!purchase.CostPosted)
                    throw new InvalidActionException("Purchase Cost Is Already Unposted", ModuleEnum.mdPurchase, request.Id);
            }

            if (request.PurchaseAction == PurchaseAction.paQtyUnpost)
            {
                if (!purchase.QtyPosted)
                    throw new InvalidActionException("Purchase Qty Is Already Unposted", ModuleEnum.mdPurchase, request.Id);

                if ((purchase.CostPosted) && (request.PurchaseDetailId == null))
                    throw new InvalidActionException("Purchase Cost Should Be Unposted", ModuleEnum.mdPurchase, request.Id);
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
                PurchaseAction.paCostUnpost,
                PurchaseAction.paFullUnpostWithDetails,
                PurchaseAction.paCostUnpostWithDetails
                }).Any(q => q == request.PurchaseAction)
                &&
                //                (request.PurchaseDetailId == null)
                //                &&
                (purchase.CostPosted)
                )
            {
                purchase.CostPosted = false;
                purchase.Posted = false;
                _context.Purchase.Update(purchase);
            }

            // if action requires iteration through details
            if (
                (new PurchaseAction[]{
                PurchaseAction.paFullPost,
                PurchaseAction.paQtyPost,
                PurchaseAction.paCostPost,
                PurchaseAction.paFullUnpostWithDetails,
                PurchaseAction.paCostUnpostWithDetails,
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
                            throw new InvalidActionException("Purchase Detail Is Already Posted", ModuleEnum.mdPurchaseDetail, purchaseDetail.Id);
                    }

                    if (
                        (request.PurchaseAction == PurchaseAction.paQtyPost)
                        &&
                        (request.PurchaseDetailId != null)
                       )
                    {
                        if (purchaseDetail.QtyPosted)
                            throw new InvalidActionException("Purchase Detail Qty Is Already Posted", ModuleEnum.mdPurchaseDetail, purchaseDetail.Id);
                    }

                    if (request.PurchaseAction == PurchaseAction.paCostPost)
                    {
                        if ((purchaseDetail.CostPosted) && (request.PurchaseDetailId != null))
                            throw new InvalidActionException("Purchase Detail Cost Is Already Posted", ModuleEnum.mdPurchaseDetail, purchaseDetail.Id);

                        if (!purchaseDetail.QtyPosted)
                            throw new InvalidActionException("Purchase Detail Qty Should Be Posted", ModuleEnum.mdPurchaseDetail, purchaseDetail.Id);
                    }

                    if (
                        (request.PurchaseAction == PurchaseAction.paFullUnpost)
                        ||
                        (request.PurchaseAction == PurchaseAction.paFullUnpostWithDetails)
                       )
                    {
                        if ((!purchaseDetail.Posted) && (request.PurchaseDetailId != null))
                            throw new InvalidActionException("Purchase Detail Is Already Unposted", ModuleEnum.mdPurchaseDetail, purchaseDetail.Id);
                    }

                    if (
                        (request.PurchaseAction == PurchaseAction.paQtyUnpost)
                        ||
                        (request.PurchaseAction == PurchaseAction.paQtyUnpostWithDetails)
                       )
                    {
                        if ((!purchaseDetail.QtyPosted) && (request.PurchaseDetailId != null))
                            throw new InvalidActionException("Purchase Detail Qty Is Already Unposted", ModuleEnum.mdPurchaseDetail, purchaseDetail.Id);

                        if (!purchaseDetail.CostPosted)
                            throw new InvalidActionException("Purchase Detail Cost Should Be Unposted", ModuleEnum.mdPurchaseDetail, purchaseDetail.Id);
                    }

                    if (
                        (request.PurchaseAction == PurchaseAction.paCostUnpost)
                        ||
                        (request.PurchaseAction == PurchaseAction.paCostUnpostWithDetails)
                       )
                    {
                        if ((!purchaseDetail.CostPosted) && (request.PurchaseDetailId != null))
                            throw new InvalidActionException("Purchase Detail Cost Is Already Unposted", ModuleEnum.mdPurchaseDetail, purchaseDetail.Id);
                    }


                    bool detailQtyPostAction = false;
                    bool detailCostPostAction = false;

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
                        (!purchaseDetail.CostPosted)
                        &&
                        (
                        (request.PurchaseAction == PurchaseAction.paFullPost)
                        ||
                        (request.PurchaseAction == PurchaseAction.paCostPost)
                        )
                       )
                    {
                        detailCostPostAction = true;
                    }

                    if (
                    (purchaseDetail.CostPosted)
                    &&
                    (
                    (request.PurchaseAction == PurchaseAction.paCostUnpostWithDetails)
                    ||
                    (request.PurchaseAction == PurchaseAction.paFullUnpostWithDetails)
                    //                    ||
                    //                    (request.PurchaseAction == PurchaseAction.paQtyUnpostWithDetails)
                    )
                   )
                        detailCostPostAction = false;


                    if (
                        (purchaseDetail.QtyPosted != detailQtyPostAction)
                        ||
                        (purchaseDetail.CostPosted != detailCostPostAction)
                       )
                    {
                        var _result = await _mediator.Send(
                        new UpdatePurchaseDetailStatusCommand
                        {
                            PurchaseDetail = purchaseDetail,
                            TransDate = purchase.TransDate,
                            doQtyPost = detailQtyPostAction,
                            doCostPost = detailCostPostAction
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
                                           CostPostStartedNew = (bool)(y.Sum(z => z.CostPosted ? 1 : 0) > 0) ? true : false,
                                           qtyPostStartedNew = (bool)(y.Sum(z => z.QtyPosted ? 1 : 0) > 0) ? true : false,
                                           CostPostedNew = (bool)(y.Min(z => z.CostPosted ? 1 : 0) == 0) ? true : false,
                                           qtyPostedNew = (bool)(y.Min(z => z.QtyPosted ? 1 : 0) == 0) ? true : false
                                       }).First();


            purchase.CostPostStarted = finalPurchaseStatus.CostPostStartedNew;
            purchase.QtyPostStarted = finalPurchaseStatus.qtyPostStartedNew;
            purchase.CostPosted = finalPurchaseStatus.CostPostedNew;
            purchase.QtyPosted = finalPurchaseStatus.qtyPostedNew;

            _logger.Information("Purchase Result Status: {@ResultStatus}", finalPurchaseStatus);

            _context.Purchase.Update(purchase);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.Information("Final Purchase Result: {@Purchase}", purchase);

            return purchase;
        }
    }

}
