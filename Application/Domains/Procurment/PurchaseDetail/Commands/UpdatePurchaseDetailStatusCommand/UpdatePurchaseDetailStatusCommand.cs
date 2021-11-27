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
using System.Linq;

using Application.Domains.Inventory.Inventory.Commands.ProductToInventory;


namespace Application.Domains.Procurment.PurchaseDetail.Commands.UpdatePurchaseDetailStatusCommand
{
    public class UpdatePurchaseDetailStatusCommand : IRequest<int>
    {
//        public ModuleEnum SenderId { get; set; } = ModuleEnum.mdUndefined;
        public DataAccessLayer.Model.Procurment.PurchaseDetail PurchaseDetail { get; set; }
        public bool QtyPost { get; set; }
        public bool FinPost { get; set; }
        public string InventoryCode { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class UpdatePurchaseDetailStatusCommandHandler : IRequestHandler<UpdatePurchaseDetailStatusCommand, int>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        public UpdatePurchaseDetailStatusCommandHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<int> Handle(UpdatePurchaseDetailStatusCommand request, CancellationToken cancellationToken)
        {

             DataAccessLayer.Model.Inventory.Inventory inventory;

            inventory = await _mediator.Send(
                            new ProductToInventoryCommand {
                                SenderId = ModuleEnum.mdPurchaseDetail,
                                SenderReferenceId = request.PurchaseDetail.Id,
                                InventoryCode = request.InventoryCode,
                                StartDate =  request.StartDate,
                                Product = request.PurchaseDetail.Product,
                                StockProductPerProcess = request.PurchaseDetail.StockProductPerProcess
                            }
                            );

            if (request.QtyPost)
            {
                /*
		          exec inv.check_inventory_constraints
		          @inventory_id = @inventory_id ,
		          @change_qty = @final_qty 

                exec[acc].[transaction_add_by_dim]
                    @transaction_id = @qty_transaction_id output,
			        @balance = @qty_transaction_balance output,
			        @trans_date = @trans_date ,
                    --@note = N'PURCHASE QTY POST',
                    --@detail_note = N'INCREASE STOCK QTY FOR PRODUCT',
			        @reference_entity_id = @purchase_details_table_id ,
			        @reference_id = @purchase_detail_id,
			        @post_time = @post_time ,
			        @account_dimension = 'INV_LOC_QTY' ,
			        @entity_foreign_id1 = @inventory_id ,
			        @entity_foreign_id2 = @location_id ,
			        @increase = @final_qty ,
			        @decrease = 0


                    update prc.purchase_details
                    set

                        qty_posted = 1,
				        inventory_id = @inventory_id

                    where
                        purchase_detail_id = @purchase_detail_id
                */

                return await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                /*
                exec acc.transaction_delete_by_dim
                     @reference_entity_id = @purchase_details_table_id,
                     @reference_id = @purchase_detail_id,
                     @account_dimension = 'INV_LOC_QTY'

                    update prc.purchase_details
                    set

                        qty_posted = 0

                    where
                        purchase_detail_id = @purchase_detail_id
                */

                return await _context.SaveChangesAsync(cancellationToken);
            }


            if (request.FinPost)
            {

            /*
                declare @fin_transaction_id bigint , @fin_transaction_balance decimal(18, 8)

                begin tran

                exec[acc].[transaction_add_by_dim]
                    @transaction_id = @fin_transaction_id output,
			        @balance = @fin_transaction_balance output,
			        @trans_date = @trans_date ,
                    --@note = N'PURCHASE FIN POST',
                    --@detail_note = N'INCREASE STOCK FIN FOR PRODUCT',
			        @reference_entity_id = @purchase_details_table_id ,
			        @reference_id = @purchase_detail_id,
			        @post_time = @post_time ,
			        @account_dimension = 'INV_LOC_AMT' ,
			        @entity_foreign_id1 = @inventory_id ,
			        @entity_foreign_id2 = @location_id ,
			        @increase = @final_cost ,
			        @decrease = 0

                    update prc.purchase_details
                    set
                        fin_posted = 1
                    where
                        purchase_detail_id = @purchase_detail_id
            */

                return await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                /*
                    exec acc.transaction_delete_by_dim
                         @reference_entity_id = @purchase_details_table_id,
                         @reference_id = @purchase_detail_id,
                         @account_dimension = 'INV_LOC_AMT'


                    update prc.purchase_details
                    set
                        fin_posted = 0
                    where
                        purchase_detail_id = @purchase_detail_id
                */
                return await _context.SaveChangesAsync(cancellationToken);

            }

            return 0;
        }
    }

}
