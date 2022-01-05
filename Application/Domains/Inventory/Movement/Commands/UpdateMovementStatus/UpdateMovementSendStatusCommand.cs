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

namespace Application.Domains.Procurment.movement.Commands.UpdateMovementSendStatusCommand
{
    public class UpdateMovementSendStatusCommand : IRequest<Application.Model.Inventory.Movement>
    {
        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public int Id { get; set; }
        public long? MovementDetailId { get; set; }
        public MovementAction MovementAction { get; set; }
    }

    public class UpdateMovementSendStatusCommandHandler : IRequestHandler<UpdateMovementSendStatusCommand, Application.Model.Inventory.Movement>
    {
        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;
        private readonly Serilog.ILogger _logger;

        public UpdateMovementSendStatusCommandHandler(IMediator mediator, ICoreDBContext context, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _context = context;
            _logger = logger;
        }

        public async Task<Application.Model.Inventory.Movement> Handle(UpdateMovementSendStatusCommand request, CancellationToken cancellationToken)
        {

            _logger.Information("Request UpdateMovementSendStatusCommandHandler: {@Request}", request);

            var movement = await _context.Movement.FindAsync(request.Id);

            _logger.Information("Movement Retrieved: {@Movement}", movement);

            // Validate Post Actions


            if (request.MovementAction == MovementAction.maFullPost)
            {
                if (movement.SendPosted)
                    throw new InvalidActionException("Movement Send Part Is Already Posted", ModuleEnum.mdMovement, request.Id);
            }

            if (request.MovementAction == MovementAction.maQtyPost)
            {
                if (movement.SendQtyPosted)
                    throw new InvalidActionException("Movement Send Qty Is Already Posted", ModuleEnum.mdMovement, request.Id);
            }

            if (request.MovementAction == MovementAction.maCostPost)
            {
                if (movement.SendCostPosted)
                    throw new InvalidActionException("Movement Cost Is Already Posted", ModuleEnum.mdMovement, request.Id);

                if ((!movement.SendQtyPosted) && (request.MovementDetailId == null))
                    throw new InvalidActionException("Movement Send Qty Should Be Posted", ModuleEnum.mdMovement, request.Id);
            }


            // Validate Unpost Actions

            if (request.MovementAction == MovementAction.maFullUnpost)
            {
                if (!movement.SendPosted)
                    throw new InvalidActionException("Movement Is Already Unposted", ModuleEnum.mdMovement, request.Id);
            }

            if (request.MovementAction == MovementAction.maCostUnpost)
            {
                if (!movement.SendCostPosted)
                    throw new InvalidActionException("movement Cost Is Already Unposted", ModuleEnum.mdMovement, request.Id);
            }

            if (request.MovementAction == MovementAction.maQtyUnpost)
            {
                if (!movement.SendQtyPosted)
                    throw new InvalidActionException("movement Qty Is Already Unposted", ModuleEnum.mdMovement, request.Id);

                if ((movement.SendCostPosted) && (request.MovementDetailId == null))
                    throw new InvalidActionException("movement Cost Should Be Unposted", ModuleEnum.mdMovement, request.Id);
            }

            /*
            if (request.MovementAction == MovementAction.maFullUnpostWithDetails)
            {

            }

            if (request.MovementAction == MovementAction.maQtyUnpostWithDetails)
            {

            }

            if (request.MovementAction == MovementAction.maFinUnpostWithDetails)
            {

            }
            */


            if (
            (new MovementAction[]{
                MovementAction.maFullUnpost,
                MovementAction.maQtyUnpost,
                MovementAction.maQtyUnpostWithDetails,
                MovementAction.maFullUnpostWithDetails
            }).Any(q => q == request.MovementAction)
            &&
            //                (request.MovementDetailId == null)
            //                &&
            (movement.SendQtyPosted)
            )
            {
                movement.SendQtyPosted = false;
                movement.SendPosted = false;
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
                (movement.SendCostPosted)
                )
            {
                movement.SendCostPosted = false;
                movement.SendPosted = false;
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
                        if (MovementDetail.SendPosted)
                            throw new InvalidActionException("movement Detail Is Already Posted", ModuleEnum.mdMovementDetail, MovementDetail.Id);
                    }

                    if (
                        (request.MovementAction == MovementAction.maQtyPost)
                        &&
                        (request.MovementDetailId != null)
                       )
                    {
                        if (MovementDetail.SendQtyPosted)
                            throw new InvalidActionException("movement Detail Qty Is Already Posted", ModuleEnum.mdMovementDetail, MovementDetail.Id);
                    }

                    if (request.MovementAction == MovementAction.maCostPost)
                    {
                        if ((MovementDetail.SendCostPosted) && (request.MovementDetailId != null))
                            throw new InvalidActionException("movement Detail Cost Is Already Posted", ModuleEnum.mdMovementDetail, MovementDetail.Id);

                        if (!MovementDetail.SendQtyPosted)
                            throw new InvalidActionException("movement Detail Qty Should Be Posted", ModuleEnum.mdMovementDetail, MovementDetail.Id);
                    }

                    if (
                        (request.MovementAction == MovementAction.maFullUnpost)
                        ||
                        (request.MovementAction == MovementAction.maFullUnpostWithDetails)
                       )
                    {
                        if ((!MovementDetail.SendPosted) && (request.MovementDetailId != null))
                            throw new InvalidActionException("movement Detail Is Already Unposted", ModuleEnum.mdMovementDetail, MovementDetail.Id);
                    }

                    if (
                        (request.MovementAction == MovementAction.maQtyUnpost)
                        ||
                        (request.MovementAction == MovementAction.maQtyUnpostWithDetails)
                       )
                    {
                        if ((!MovementDetail.SendQtyPosted) && (request.MovementDetailId != null))
                            throw new InvalidActionException("movement Detail Qty Is Already Unposted", ModuleEnum.mdMovementDetail, MovementDetail.Id);

                        if (!MovementDetail.SendCostPosted)
                            throw new InvalidActionException("movement Detail Cost Should Be Unposted", ModuleEnum.mdMovementDetail, MovementDetail.Id);
                    }

                    if (
                        (request.MovementAction == MovementAction.maCostUnpost)
                        ||
                        (request.MovementAction == MovementAction.maCostUnpostWithDetails)
                       )
                    {
                        if ((!MovementDetail.SendCostPosted) && (request.MovementDetailId != null))
                            throw new InvalidActionException("movement Detail Cost Is Already Unposted", ModuleEnum.mdMovementDetail, MovementDetail.Id);
                    }


                    bool detailQtyPostAction = false;
                    bool detailCostPostAction = false;

                    if (
                        (!MovementDetail.SendQtyPosted)
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
                        (MovementDetail.SendQtyPosted)
                        &&
                        (
                        (request.MovementAction == MovementAction.maFullUnpostWithDetails)
                        ||
                        (request.MovementAction == MovementAction.maQtyUnpostWithDetails)
                        )
                       )
                        detailQtyPostAction = false;

                    if (
                        (!MovementDetail.SendCostPosted)
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
                    (MovementDetail.SendCostPosted)
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
                        (MovementDetail.SendQtyPosted != detailQtyPostAction)
                        ||
                        (MovementDetail.SendCostPosted != detailCostPostAction)
                       )
                    {
                        var _result = await _mediator.Send(
                        new UpdateMovementDetailStatusCommand
                        {
                            MovementDetail = MovementDetail,
                            TransDate = movement.SendDate,
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
                                           SendCostPostStartedNew = (bool)(y.Sum(z => z.SendCostPosted ? 1 : 0) > 0) ? true : false,
                                           SendqtyPostStartedNew = (bool)(y.Sum(z => z.SendQtyPosted ? 1 : 0) > 0) ? true : false,
                                           SendCostPostedNew = (bool)(y.Min(z => z.SendCostPosted ? 1 : 0) == 0) ? true : false,
                                           SendqtyPostedNew = (bool)(y.Min(z => z.SendQtyPosted ? 1 : 0) == 0) ? true : false
                                       }).First();


            movement.SendCostPostStarted = finalmovementStatus.SendCostPostStartedNew;
            movement.SendQtyPostStarted = finalmovementStatus.SendqtyPostStartedNew;
            movement.SendCostPosted = finalmovementStatus.SendCostPostedNew;
            movement.SendQtyPosted = finalmovementStatus.SendqtyPostedNew;

            _logger.Information("movement Result Status: {@ResultStatus}", finalmovementStatus);

            _context.Movement.Update(movement);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.Information("Final movement Result: {@movement}", movement);

            return movement;
        }
    }

}
