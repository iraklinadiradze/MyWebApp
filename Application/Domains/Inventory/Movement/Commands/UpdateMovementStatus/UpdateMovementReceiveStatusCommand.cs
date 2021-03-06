
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

using Application;
using Application.Common.Interfaces;
using Application.Common;
using Microsoft.Extensions.Logging;
using Serilog;
using Application.Common.Exceptions;
using Application.Domains.Inventory.Movement;
using Application.Domains.Inventory.MovementDetail.Commands.UpdateMovementDetailStatusCommand;

namespace Application.Domains.Procurment.movement.Commands.UpdateMovementReceiveStatusCommand
{
    public class UpdateMovementReceiveStatusCommand : IRequest<Application.Model.Inventory.Movement>
    {
        public ModuleEnum ReceiveerId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
        public long? MovementDetailId { get; set; }
        public MovementAction MovementAction { get; set; }
    }

    public class UpdateMovementReceiveStatusCommandHandler : IRequestHandler<UpdateMovementReceiveStatusCommand, Application.Model.Inventory.Movement>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;
        private readonly Serilog.ILogger _logger;

        public UpdateMovementReceiveStatusCommandHandler(IMediator mediator, ICoreDBContext context, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _context = context;
            _logger = logger;
        }

        public async Task<Application.Model.Inventory.Movement> Handle(UpdateMovementReceiveStatusCommand request, CancellationToken cancellationToken)
        {

            _logger.Information("Request UpdateMovementReceiveStatusCommandHandler: {@Request}", request);

            var movement = await _context.Movement.FindAsync(request.Id);

            _logger.Information("Movement Retrieved: {@Movement}", movement);

            // Validate Post Actions


            if (request.MovementAction == MovementAction.maFullPost)
            {
                if (movement.ReceivePosted)
                    throw new InvalidActionException("Movement Receive Part Is Already Posted", ModuleEnum.mdMovement, request.Id);
            }

            if (request.MovementAction == MovementAction.maQtyPost)
            {
                if (movement.ReceiveQtyPosted)
                    throw new InvalidActionException("Movement Receive Qty Is Already Posted", ModuleEnum.mdMovement, request.Id);
            }

            if (request.MovementAction == MovementAction.maCostPost)
            {
                if (movement.ReceiveCostPosted)
                    throw new InvalidActionException("Movement Cost Is Already Posted", ModuleEnum.mdMovement, request.Id);

                if ((!movement.ReceiveQtyPosted) && (request.MovementDetailId == null))
                    throw new InvalidActionException("Movement Receive Qty Should Be Posted", ModuleEnum.mdMovement, request.Id);
            }


            // Validate Unpost Actions

            if (request.MovementAction == MovementAction.maFullUnpost)
            {
                if (!movement.ReceivePosted)
                    throw new InvalidActionException("Movement Is Already Unposted", ModuleEnum.mdMovement, request.Id);
            }

            if (request.MovementAction == MovementAction.maCostUnpost)
            {
                if (!movement.ReceiveCostPosted)
                    throw new InvalidActionException("movement Cost Is Already Unposted", ModuleEnum.mdMovement, request.Id);
            }

            if (request.MovementAction == MovementAction.maQtyUnpost)
            {
                if (!movement.ReceiveQtyPosted)
                    throw new InvalidActionException("movement Qty Is Already Unposted", ModuleEnum.mdMovement, request.Id);

                if ((movement.ReceiveCostPosted) && (request.MovementDetailId == null))
                    throw new InvalidActionException("movement Cost Should Be Unposted", ModuleEnum.mdMovement, request.Id);
            }


            if (
            (new MovementAction[]{
                MovementAction.maFullUnpost,
                MovementAction.maQtyUnpost,
                MovementAction.maQtyUnpostWithDetails,
                MovementAction.maFullUnpostWithDetails
            }).Any(q => q == request.MovementAction)
            &&
            (movement.ReceiveQtyPosted)
            )
            {
                movement.ReceiveQtyPosted = false;
                movement.ReceivePosted = false;
                _context.Movement.Update(movement);
            }

            if (
                (new MovementAction[]{
                MovementAction.maFullUnpost,
                MovementAction.maCostUnpost,
                MovementAction.maFullUnpostWithDetails,
                MovementAction.maCostUnpostWithDetails
                }).Any(q => q == request.MovementAction)
                &&
                //                (request.MovementDetailId == null)
                //                &&
                (movement.ReceiveCostPosted)
                )
            {
                movement.ReceiveCostPosted = false;
                movement.ReceivePosted = false;
                _context.Movement.Update(movement);
            }

            // if action requires iteration through details
            if (
                (new MovementAction[]{
                MovementAction.maFullPost,
                MovementAction.maQtyPost,
                MovementAction.maCostPost,
                MovementAction.maFullUnpostWithDetails,
                MovementAction.maCostUnpostWithDetails,
                MovementAction.maQtyUnpostWithDetails
                }).Any(q => q == request.MovementAction)
                &&
                (request.MovementDetailId == null)
                )
            {

                _logger.Information("Start movement Detail Post/Unpost");

                foreach (
                    var MovementDetail in _context.MovementDetail.Where(q =>
                    (q.MovementId == movement.Id)
                    &&
                    ((request.MovementDetailId == null) || (q.Id == request.MovementDetailId))
                    )
                )
                {
                    if (
                        (request.MovementAction == MovementAction.maFullPost)
                        &&
                        (request.MovementDetailId != null)
                       )
                    {
                        if (MovementDetail.ReceivePosted)
                            throw new InvalidActionException("movement Detail Is Already Posted", ModuleEnum.mdMovementDetail, MovementDetail.Id);
                    }

                    if (
                        (request.MovementAction == MovementAction.maQtyPost)
                        &&
                        (request.MovementDetailId != null)
                       )
                    {
                        if (MovementDetail.ReceiveQtyPosted)
                            throw new InvalidActionException("movement Detail Qty Is Already Posted", ModuleEnum.mdMovementDetail, MovementDetail.Id);
                    }

                    if (request.MovementAction == MovementAction.maCostPost)
                    {
                        if ((MovementDetail.ReceiveCostPosted) && (request.MovementDetailId != null))
                            throw new InvalidActionException("movement Detail Cost Is Already Posted", ModuleEnum.mdMovementDetail, MovementDetail.Id);

                        if (!MovementDetail.ReceiveQtyPosted)
                            throw new InvalidActionException("movement Detail Qty Should Be Posted", ModuleEnum.mdMovementDetail, MovementDetail.Id);
                    }

                    if (
                        (request.MovementAction == MovementAction.maFullUnpost)
                        ||
                        (request.MovementAction == MovementAction.maFullUnpostWithDetails)
                       )
                    {
                        if ((!MovementDetail.ReceivePosted) && (request.MovementDetailId != null))
                            throw new InvalidActionException("movement Detail Is Already Unposted", ModuleEnum.mdMovementDetail, MovementDetail.Id);
                    }

                    if (
                        (request.MovementAction == MovementAction.maQtyUnpost)
                        ||
                        (request.MovementAction == MovementAction.maQtyUnpostWithDetails)
                       )
                    {
                        if ((!MovementDetail.ReceiveQtyPosted) && (request.MovementDetailId != null))
                            throw new InvalidActionException("movement Detail Qty Is Already Unposted", ModuleEnum.mdMovementDetail, MovementDetail.Id);

                        if (!MovementDetail.ReceiveCostPosted)
                            throw new InvalidActionException("movement Detail Cost Should Be Unposted", ModuleEnum.mdMovementDetail, MovementDetail.Id);
                    }

                    if (
                        (request.MovementAction == MovementAction.maCostUnpost)
                        ||
                        (request.MovementAction == MovementAction.maCostUnpostWithDetails)
                       )
                    {
                        if ((!MovementDetail.ReceiveCostPosted) && (request.MovementDetailId != null))
                            throw new InvalidActionException("movement Detail Cost Is Already Unposted", ModuleEnum.mdMovementDetail, MovementDetail.Id);
                    }


                    bool detailQtyPostAction = false;
                    bool detailCostPostAction = false;

                    if (
                        (!MovementDetail.ReceiveQtyPosted)
                        &&
                        (
                        (request.MovementAction == MovementAction.maFullPost)
                        ||
                        (request.MovementAction == MovementAction.maQtyPost)
                        )
                       )
                    {
                        detailQtyPostAction = true;
                    }

                    if (
                        (MovementDetail.ReceiveQtyPosted)
                        &&
                        (
                        (request.MovementAction == MovementAction.maFullUnpostWithDetails)
                        ||
                        (request.MovementAction == MovementAction.maQtyUnpostWithDetails)
                        )
                       )
                        detailQtyPostAction = false;

                    if (
                        (!MovementDetail.ReceiveCostPosted)
                        &&
                        (
                        (request.MovementAction == MovementAction.maFullPost)
                        ||
                        (request.MovementAction == MovementAction.maCostPost)
                        )
                       )
                    {
                        detailCostPostAction = true;
                    }

                    if (
                    (MovementDetail.ReceiveCostPosted)
                    &&
                    (
                    (request.MovementAction == MovementAction.maCostUnpostWithDetails)
                    ||
                    (request.MovementAction == MovementAction.maFullUnpostWithDetails)
                    //                    ||
                    //                    (request.MovementAction == MovementAction.maQtyUnpostWithDetails)
                    )
                   )
                        detailCostPostAction = false;


                    if (
                        (MovementDetail.ReceiveQtyPosted != detailQtyPostAction)
                        ||
                        (MovementDetail.ReceiveCostPosted != detailCostPostAction)
                       )
                    {
                        var _result = await _mediator.Receive(
                        new UpdateMovementDetailReceiveStatusCommand
                        {
                            MovementDetail = MovementDetail,
                            Movement = movement,
                            doQtyPost = detailQtyPostAction,
                            doCostPost = detailCostPostAction
                        }
                        );
                    }

                }

                _logger.Information("End movement Detail Post/Unpost");

            }

            var finalmovementStatus = (from x in _context.MovementDetail
                                       where x.MovementId == movement.Id
                                       group x by 0 into y
                                       select new
                                       {
                                           ReceiveCostPostStartedNew = (bool)(y.Sum(z => z.ReceiveCostPosted ? 1 : 0) > 0) ? true : false,
                                           ReceiveqtyPostStartedNew = (bool)(y.Sum(z => z.ReceiveQtyPosted ? 1 : 0) > 0) ? true : false,
                                           ReceiveCostPostedNew = (bool)(y.Min(z => z.ReceiveCostPosted ? 1 : 0) == 0) ? true : false,
                                           ReceiveqtyPostedNew = (bool)(y.Min(z => z.ReceiveQtyPosted ? 1 : 0) == 0) ? true : false
                                       }).First();


            movement.ReceiveCostPostStarted = finalmovementStatus.ReceiveCostPostStartedNew;
            movement.ReceiveQtyPostStarted = finalmovementStatus.ReceiveqtyPostStartedNew;
            movement.ReceiveCostPosted = finalmovementStatus.ReceiveCostPostedNew;
            movement.ReceiveQtyPosted = finalmovementStatus.ReceiveqtyPostedNew;

            _logger.Information("movement Result Status: {@ResultStatus}", finalmovementStatus);

            _context.Movement.Update(movement);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.Information("Final movement Result: {@movement}", movement);

            return movement;
        }
    }

}
