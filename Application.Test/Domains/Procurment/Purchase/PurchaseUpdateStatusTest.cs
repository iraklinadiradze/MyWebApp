using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Application.Test.SeedData;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Moq;
using MediatR;
using Application.Domains.Procurment.Purchase.Commands.UpdatePurchaseStatusCommand;
using Application.Domains.Procurment.Purchase;
using Application.Common.Interfaces;
using System.Threading;

namespace Application.Test.Domains.Procurment.Purchase
{
    public class PurchaseUpdateStatusTest : IClassFixture<Application.Test.SeedData.SeedData>
    {

        Application.Test.SeedData.SeedData _seedData;

        public PurchaseUpdateStatusTest(Application.Test.SeedData.SeedData seedData)
        {
            _seedData = seedData;
            _seedData.doMakeSeeding();
        }

        [Fact]

        public async void CheckPurchaseTest()
        {
            Application.Model.Procurment.Purchase _purchase = _seedData._dbContext.Purchase.FirstOrDefault();

            var mediator = new Mock<IMediator>();
            //            var mediator = new NestedMediator();

            UpdatePurchaseStatusCommand _updatePurchaseStatusCommand = new UpdatePurchaseStatusCommand { Id = _purchase.Id, SenderId = 0, PurchaseDetailId = null, PurchaseAction = PurchaseAction.paFullPost };

            mediator.Setup(m => m.Send(It.IsAny<Application.Domains.Procurment.PurchaseDetail.Commands.UpdatePurchaseDetailStatusCommand.UpdatePurchaseDetailStatusCommand>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Application.Model.Procurment.PurchaseDetail()) //<-- return Task to allow await to continue
                .Verifiable("Notification was not sent.");

            UpdatePurchaseStatusCommandHandler _updatePurchaseStatusCommandHandler = new UpdatePurchaseStatusCommandHandler(_seedData._mediator.Object, _seedData._dbContext);

            var result = await _updatePurchaseStatusCommandHandler.Handle(_updatePurchaseStatusCommand, new System.Threading.CancellationToken() );

       //     var result = await _seedData._mediator.Object.Send(_updatePurchaseStatusCommand);


            await _seedData._dbContext.SaveChangesAsync();

            var i = await _seedData._dbContext.Inventory.ToListAsync();
            var ic = await _seedData._dbContext.InventoryChange.ToListAsync();

            Assert.Equal(6, i.Count());
        }


    }

}
