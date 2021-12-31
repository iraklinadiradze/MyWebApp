using Application.Common.Interfaces;
using Application.Domains.Procurment.Purchase;
using Application.Domains.Procurment.Purchase.Commands.UpdatePurchaseStatusCommand;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Context;
using Serilog.Sinks.InMemory;
using System;
using System.Linq;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace Application.Test.Domains.Procurment.Purchase
{

    [Collection("Sequential")]
    public class PurchaseUpdateStatusTest : IClassFixture<Application.Test.TestContext.TestContext>
    {

        //        private readonly ITestOutputHelper _testOutputHelper;

        //        Application.Test.TestContext.TestContext _testContext;

        ICoreDBContext _dbContext { get; set; }
        IMediator _mediator { get; set; }

        ILogger _Logger;

        ITestOutputHelper _testoutputHelper;

        public PurchaseUpdateStatusTest(Application.Test.TestContext.TestContext testContext, ITestOutputHelper testoutputHelper)
        {
            testContext.InjectLogger(testoutputHelper);

            _dbContext = testContext._dbContext;
            _mediator = testContext._mediator;
            _Logger = testContext._Logger;
            _testoutputHelper = testoutputHelper;
        }


        [Fact]
        public void CheckPurchaseTest1()
        {
            //          var _testContext = new TestContext.TestContext(_testOutputHelper);
//            InMemorySink.Instance.Dispose();

            LogContext.PushProperty("TestFunction", "CheckPurchaseTest1");
            _Logger.Information("Start CheckPurchaseTest1");

            Application.Model.Procurment.Purchase _purchase = _dbContext.Purchase.FirstOrDefault();

            _purchase.PurchaseName = "DDDDDDDD1213213123";
            _dbContext.Purchase.Update(_purchase);

            Application.Model.Procurment.Purchase _purchase1 = (from e in _dbContext.Purchase
                                                               select e).FirstOrDefault();

            _Logger.Information("End CheckPurchaseTest1");
            _Logger.Information("");

            Assert.Equal(_purchase.PurchaseName, _purchase1.PurchaseName );
        }


        [Fact]
        public async void CheckPurchaseFullTest()
        {

//            InMemorySink.Instance.Dispose();

            LogContext.PushProperty("TestFunction", "CheckPurchaseFullTest");
            _Logger.Information("Start CheckPurchaseFullTest");

            Application.Model.Procurment.Purchase _purchase = _dbContext.Purchase.FirstOrDefault();

            UpdatePurchaseStatusCommand _updatePurchaseStatusCommand = new UpdatePurchaseStatusCommand { 
                Id = _purchase.Id, 
                SenderId = 0, 
                PurchaseDetailId = null, 
                PurchaseAction = PurchaseAction.paFullPost 
            };

            var result = await _mediator.Send(_updatePurchaseStatusCommand);

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            _Logger.Information("End CheckPurchaseFullTest");
            _Logger.Information("");
            
            var i = await _dbContext.Inventory.ToListAsync();
            var ic = await _dbContext.InventoryChange.ToListAsync();

            Assert.Equal(6, i.Count());
        }


        [Fact]
        public async void CheckPurchaseQtyTest()
        {
 
            try
            {

                LogContext.PushProperty("TestFunction", "CheckPurchaseQtyTest");
                _Logger.Information("Start CheckPurchaseQtyTest");

                Application.Model.Procurment.Purchase _purchase = _dbContext.Purchase.FirstOrDefault();

                UpdatePurchaseStatusCommand _updatePurchaseStatusCommand = new UpdatePurchaseStatusCommand
                {
                    Id = _purchase.Id,
                    SenderId = 0,
                    PurchaseDetailId = null,
                    PurchaseAction = PurchaseAction.paQtyPost
                };

                var result = await _mediator.Send(_updatePurchaseStatusCommand);

                await _dbContext.SaveChangesAsync(CancellationToken.None);

                _Logger.Information("End CheckPurchaseQtyTest");
                }
                catch (Exception ex)
                {
                    _Logger.Error("{ErrorMessage}", ex.Message);
                    _Logger.Error("{StackTrace}", ex.StackTrace);
                }


            var i = await _dbContext.Inventory.ToListAsync();
    //            var ic = await _dbContext.InventoryChange.ToListAsync();

                Assert.Equal(6, i.Count() );

        }


        [Fact]
        public async void CheckPurchaseFinTest()
        {

            LogContext.PushProperty("TestFunction", "CheckPurchaseFinTest");
            _Logger.Information("Start CheckPurchaseFinTest");

            Application.Model.Procurment.Purchase _purchase = _dbContext.Purchase.FirstOrDefault();

            UpdatePurchaseStatusCommand _updatePurchaseStatusCommand = new UpdatePurchaseStatusCommand
            {
                Id = _purchase.Id,
                SenderId = 0,
                PurchaseDetailId = null,
                PurchaseAction = PurchaseAction.paQtyPost
            };

            var result = await _mediator.Send(_updatePurchaseStatusCommand);

            UpdatePurchaseStatusCommand _updatePurchaseStatusCommand1 = new UpdatePurchaseStatusCommand
            {
                Id = _purchase.Id,
                SenderId = 0,
                PurchaseDetailId = null,
                PurchaseAction = PurchaseAction.paCostPost
            };

            var result1 = await _mediator.Send(_updatePurchaseStatusCommand1);

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            _Logger.Information("End CheckPurchaseFinTest");

            var i = await _dbContext.Inventory.ToListAsync();
            var ic = await _dbContext.InventoryChange.ToListAsync();

            Assert.Equal(6, i.Count());

        }

    }

}
