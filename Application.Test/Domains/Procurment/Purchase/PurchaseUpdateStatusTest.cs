using Application.Domains.Procurment.Purchase;
using Application.Domains.Procurment.Purchase.Commands.UpdatePurchaseStatusCommand;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
// using System.ComponentModel;
// using Shouldly;
// MediatR.Extensions.Microsoft.DependencyInjection;

// using SimpleInjector;

namespace Application.Test.Domains.Procurment.Purchase
{

    public class PurchaseUpdateStatusTest : IClassFixture<Application.Test.TestContext.TestContext>
    {

        Application.Test.TestContext.TestContext _testContext;

        public PurchaseUpdateStatusTest(Application.Test.TestContext.TestContext testContext)
        {
            _testContext = testContext;
            //            _seedData.doMakeSeeding();


        }

        [Fact]
        public async void CheckPurchaseTest1()
        {
            var i = await _testContext._dbContext.Inventory.ToListAsync();
            var ic = await _testContext._dbContext.InventoryChange.ToListAsync();

            var c = await _testContext._dbContext.Currency.ToListAsync();

            Assert.Equal(6, i.Count());
        }


        [Fact]

        public async void CheckPurchaseTest()
        {
            Application.Model.Procurment.Purchase _purchase = _testContext._dbContext.Purchase.FirstOrDefault();

            UpdatePurchaseStatusCommand _updatePurchaseStatusCommand = new UpdatePurchaseStatusCommand { Id = _purchase.Id, SenderId = 0, PurchaseDetailId = null, PurchaseAction = PurchaseAction.paFullPost };

            var result = await _testContext._mediator.Send(_updatePurchaseStatusCommand);

            await _testContext._dbContext.SaveChangesAsync();

            var i = await _testContext._dbContext.Inventory.ToListAsync();
            var ic = await _testContext._dbContext.InventoryChange.ToListAsync();

//            Assert.Equal(7, ic.Count());
            Assert.Equal(7, i.Count());
        }


        [Fact]
        public async void CheckPurchaseTest2()
        {
            var i = await _testContext._dbContext.Inventory.ToListAsync();
            var ic = await _testContext._dbContext.InventoryChange.ToListAsync();

            var c = await _testContext._dbContext.Currency.ToListAsync();

            Assert.Equal(7, i.Count());
        }

    }

}
