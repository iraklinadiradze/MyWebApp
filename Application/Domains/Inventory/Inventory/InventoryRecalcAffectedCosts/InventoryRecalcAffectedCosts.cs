using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using System.Runtime;

using MediatR;
using DataAccessLayer.Model.Procurment;
using DataAccessLayer;
using Application.Common.Interfaces;
using Application.Common;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;


namespace Application.Domains.Inventory.Inventory.InventoryRecalcAffectedCosts
{

    public class InventoryRecalcAffectedCostsCommand : IRequest<int>
    {
    }


    public class InventoryRecalcAffectedCostsCommandHandler : IRequestHandler<InventoryRecalcAffectedCostsCommand, int>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;

        InventoryRecalcAffectedCostsCommandHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public Task<int> Handle(InventoryRecalcAffectedCostsCommand request, CancellationToken cancellationToken)
        {

            while (_context.CostAffectedInventoryChangeList.Length > 0)
            {
                //                Dictionary<long, DataAccessLayer.Model.Inventory.InventoryChange> _costAffectedInventoryChangeList = new Dictionary<long, DataAccessLayer.Model.Inventory.InventoryChange>(_context.CostAffectedInventoryChangeList);
                DataAccessLayer.Model.Inventory.InventoryChange[] _costAffectedInventoryChangeList= { };

                ArrayList a = new ArrayList();
                a.Clear();
                a.Add()

                _costAffectedInventoryChangeList = (DataAccessLayer.Model.Inventory.InventoryChange[])_costAffectedInventoryChangeList.Concat(_context.CostAffectedInventoryChangeList);

                _context.CostAffectedInventoryChangeList.


                Array.Clear(_context.CostAffectedInventoryChangeList);

                foreach (var _inventoryChange in _costAffectedInventoryChangeList.Values)
                {
                    //                    Dictionary<int, DataAccessLayer.Model.Inventory.InventoryChange> xyz=new Dictionary<int, DataAccessLayer.Model.Inventory.InventoryChange>;
                    //                    var r = xyz.Where(x => x.Key == 123).FirstOrDefault();

                    if (_inventoryChange.EntityId == (int)ModuleEnum.mdInventory)
                    {
                        // Send inventory Movement Cost Repost command for inventory
                        // Return Back Inventory List affected By Change of Cost
                    }

                    if (_inventoryChange.EntityId == (int)ModuleEnum.mdSale)
                    {
                        // Send Sale Cost of goods Sold Repost command for inventory
                        // Return Back Inventory List affected By Change of Cost
                    }

                    if (_inventoryChange.EntityId == (int)ModuleEnum.mdProduction)
                    {
                        // Send Sale Cost of goods Sold Repost command for inventory
                        // Return Back Inventory List affected By Change of Cost
                    }

                }


            }


            return null;
        }
    }

}
