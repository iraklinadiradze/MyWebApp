using System;
using System.Collections.Generic;
using System.Text;
// using Application.Model;

namespace DataAccessLayer.Model
{
    public class DataSeed
    {
        CoreDBContext _dbContext;

        public DataSeed(CoreDBContext dbContext )
        {
            _dbContext = dbContext;
        }

        public void SeedStaticData()
        {

            // General Schema

            _dbContext.Currency.AddRange(
                new []
                {
                    new Application.Model.Core.Currency{ CurrencyCode="GEL", CurrencyDescrip ="Georgian Lari" } ,
                    new Application.Model.Core.Currency{ CurrencyCode="USD", CurrencyDescrip ="US Dollar" } ,
                    new Application.Model.Core.Currency{ CurrencyCode="EUR", CurrencyDescrip ="Euro" } ,
                    new Application.Model.Core.Currency{ CurrencyCode="GBP", CurrencyDescrip ="British Pound" } 
                }
             );

            _dbContext.Country.AddRange(
                new[]
                {
                    new Application.Model.Core.Country{ Code="GEO", Name="Republic of Georgia"} ,
                    new Application.Model.Core.Country{ Code="USA", Name="United States Of America"},
                    new Application.Model.Core.Country{ Code="GER", Name="Germany"},
                    new Application.Model.Core.Country{ Code="AZE", Name="Azerbaijan"},
                    new Application.Model.Core.Country{ Code="ARM", Name="Armenia"},
                    new Application.Model.Core.Country{ Code="TUR", Name="Turkey"}
                }
             );

            /*
            _dbContext.User.AddRange(
                new[]
                {
                    new Core.User{ Username="inadir", Password="123", Firstname="Irakli", Lastname="Nadiradze"} 
                }
             );
            */

            // Clients Schema

            // Products Schema
            _dbContext.ProductUnit.AddRange( 
                new[]
                {
                    new Application.Model.Product.ProductUnit{ ProductUnitName ="ცალი" } ,
                    new Application.Model.Product.ProductUnit{ ProductUnitName ="კილოგრამი" } ,
                    new Application.Model.Product.ProductUnit{ ProductUnitName ="გრამი" } ,
                    new Application.Model.Product.ProductUnit{ ProductUnitName ="მეტრი" } ,
                    new Application.Model.Product.ProductUnit{ ProductUnitName ="სანტიმეტრი" },
                    new Application.Model.Product.ProductUnit{ ProductUnitName ="მილიმეტრი" }

                }
             );


            // Inventory Schema
            _dbContext.InventoryChangeType.AddRange(
                new[]
                {
                    new Application.Model.Inventory.InventoryChangeType{ ChangeCode="PRC", ChangeName="შესყიდვა" , IsFinRelated= true, IsQtyRelated=false} ,
                    new Application.Model.Inventory.InventoryChangeType{ ChangeCode="MVM", ChangeName="გადაზიდვა" , IsFinRelated= true, IsQtyRelated=false} ,
                    new Application.Model.Inventory.InventoryChangeType{ ChangeCode="SAL", ChangeName="გაყიდვა" , IsFinRelated= true, IsQtyRelated=false} ,
                    new Application.Model.Inventory.InventoryChangeType{ ChangeCode="WRO", ChangeName="ჩამოწერა" , IsFinRelated= true, IsQtyRelated=false} ,
                    new Application.Model.Inventory.InventoryChangeType{ ChangeCode="PRD", ChangeName="ტრანსფორმაცია" , IsFinRelated= true, IsQtyRelated=false} 
                }
             );

        }



    }
}
