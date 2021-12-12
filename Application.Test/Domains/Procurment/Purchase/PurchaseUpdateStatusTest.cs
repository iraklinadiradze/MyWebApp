using Application.Domains.Procurment.Purchase;
using Application.Domains.Procurment.Purchase.Commands.UpdatePurchaseStatusCommand;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
// using System.ComponentModel;
// using Shouldly;
// MediatR.Extensions.Microsoft.DependencyInjection;

// using SimpleInjector;

namespace Application.Test.Domains.Procurment.Purchase
{

    public class PurchaseUpdateStatusTest //: IClassFixture<Application.Test.TestContext.TestContext>
    {

        private readonly ITestOutputHelper _testOutputHelper;

//        Application.Test.TestContext.TestContext _testContext;

        public PurchaseUpdateStatusTest( //Application.Test.TestContext.TestContext testContext, 
            ITestOutputHelper testOutputHelper)
        {
//            _testContext = testContext;
            _testOutputHelper = testOutputHelper;
        }


 //       [Fact]
        public async void CheckPurchaseTest1()
        {
            var _testContext = new TestContext.TestContext();

            var i = await _testContext._dbContext.Inventory.ToListAsync();
            var ic = await _testContext._dbContext.InventoryChange.ToListAsync();

            var c = await _testContext._dbContext.Currency.ToListAsync();

            Assert.Equal(6, i.Count());
        }


  //      [Fact]
        public async void CheckPurchaseFullTest()
        {
            var _testContext = new TestContext.TestContext();

            Application.Model.Procurment.Purchase _purchase = _testContext._dbContext.Purchase.FirstOrDefault();

            UpdatePurchaseStatusCommand _updatePurchaseStatusCommand = new UpdatePurchaseStatusCommand { 
                Id = _purchase.Id, 
                SenderId = 0, 
                PurchaseDetailId = null, 
                PurchaseAction = PurchaseAction.paFullPost 
            };

            var result = await _testContext._mediator.Send(_updatePurchaseStatusCommand);

            await _testContext._dbContext.SaveChangesAsync();

            var i = await _testContext._dbContext.Inventory.ToListAsync();
            var ic = await _testContext._dbContext.InventoryChange.ToListAsync();

            //            _testOutputHelper.WriteLine(i[0].Id.ToString());
            //            _testOutputHelper.WriteLine("");
            //            _testOutputHelper.WriteLine(ic[0].Id.ToString());

        //    Assert.Equal(6, i.Count());
            Assert.Equal(7, i.Count());
        }


//        [Fact]
        public async void CheckPurchaseQtyTest()
        {
            var _testContext = new TestContext.TestContext();

            Application.Model.Procurment.Purchase _purchase = _testContext._dbContext.Purchase.FirstOrDefault();

            UpdatePurchaseStatusCommand _updatePurchaseStatusCommand = new UpdatePurchaseStatusCommand
            {
                Id = _purchase.Id,
                SenderId = 0,
                PurchaseDetailId = null,
                PurchaseAction = PurchaseAction.paQtyPost
            };

            var result = await _testContext._mediator.Send(_updatePurchaseStatusCommand);

            await _testContext._dbContext.SaveChangesAsync();

            var i = await _testContext._dbContext.Inventory.ToListAsync();
            var ic = await _testContext._dbContext.InventoryChange.ToListAsync();

            Assert.Equal(7, i.Count());

        }


        [Fact]
        public async void CheckPurchaseFinTest()
        {
            var _testContext = new TestContext.TestContext();

            Application.Model.Procurment.Purchase _purchase = _testContext._dbContext.Purchase.FirstOrDefault();

            UpdatePurchaseStatusCommand _updatePurchaseStatusCommand = new UpdatePurchaseStatusCommand
            {
                Id = _purchase.Id,
                SenderId = 0,
                PurchaseDetailId = null,
                PurchaseAction = PurchaseAction.paQtyPost
            };

            var result = await _testContext._mediator.Send(_updatePurchaseStatusCommand);

            await _testContext._dbContext.SaveChangesAsync();

//            return;

            UpdatePurchaseStatusCommand _updatePurchaseStatusCommand1 = new UpdatePurchaseStatusCommand
            {
                Id = _purchase.Id,
                SenderId = 0,
                PurchaseDetailId = null,
                PurchaseAction = PurchaseAction.paFinPost
            };

            var result1 = await _testContext._mediator.Send(_updatePurchaseStatusCommand1);

            await _testContext._dbContext.SaveChangesAsync();

            var i = await _testContext._dbContext.Inventory.ToListAsync();
            var ic = await _testContext._dbContext.InventoryChange.ToListAsync();

            Assert.Equal(7, i.Count());

        }

    }

}
