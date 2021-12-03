using System;
using System.Collections.Generic;
using System.Text;

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
                    new Core.Currency{ CurrencyCode="GEL", CurrencyDescrip ="Georgian Lari" } ,
                    new Core.Currency{ CurrencyCode="USD", CurrencyDescrip ="US Dollar" } ,
                    new Core.Currency{ CurrencyCode="EUR", CurrencyDescrip ="Euro" } ,
                    new Core.Currency{ CurrencyCode="GBP", CurrencyDescrip ="British Pound" } 
                }
             );

            _dbContext.Country.AddRange(
                new[]
                {
                    new Core.Country{ Code="GEO", Name="Republic of Georgia"} ,
                    new Core.Country{ Code="USA", Name="United States Of America"},
                    new Core.Country{ Code="GER", Name="Germany"},
                    new Core.Country{ Code="AZE", Name="Azerbaijan"},
                    new Core.Country{ Code="ARM", Name="Armenia"},
                    new Core.Country{ Code="TUR", Name="Turkey"}
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
                    new Product.ProductUnit{ ProductUnitName ="ცალი" } ,
                    new Product.ProductUnit{ ProductUnitName ="კილოგრამი" } ,
                    new Product.ProductUnit{ ProductUnitName ="გრამი" } ,
                    new Product.ProductUnit{ ProductUnitName ="მეტრი" } ,
                    new Product.ProductUnit{ ProductUnitName ="სანტიმეტრი" },
                    new Product.ProductUnit{ ProductUnitName ="მილიმეტრი" }

                }
             );


            // Inventory Schema
            _dbContext.InventoryChangeType.AddRange(
                new[]
                {
                    new Inventory.InventoryChangeType{ ChangeCode="PRC", ChangeName="შესყიდვა" , IsFinRelated= true, IsQtyRelated=false} ,
                    new Inventory.InventoryChangeType{ ChangeCode="MVM", ChangeName="გადაზიდვა" , IsFinRelated= true, IsQtyRelated=false} ,
                    new Inventory.InventoryChangeType{ ChangeCode="SAL", ChangeName="გაყიდვა" , IsFinRelated= true, IsQtyRelated=false} ,
                    new Inventory.InventoryChangeType{ ChangeCode="WRO", ChangeName="ჩამოწერა" , IsFinRelated= true, IsQtyRelated=false} ,
                    new Inventory.InventoryChangeType{ ChangeCode="PRD", ChangeName="ტრანსფორმაცია" , IsFinRelated= true, IsQtyRelated=false} 
                }
             );

        }



    }
}
