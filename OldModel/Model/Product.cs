using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class Product
    {
        public Product()
        {
            SalesSchemaDetails = new HashSet<SalesSchemaDetail>();
        }

        public long ProductId { get; set; }
        public long? ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public int? ProductGroupId { get; set; }
        public string BarCode { get; set; }
        public int? BrandId { get; set; }
        public int? SizeId { get; set; }
        public int? StyleId { get; set; }
        public int? ModelId { get; set; }
        public int? ProductLabelId { get; set; }
        public int? ColorId { get; set; }
        public int? ColorCodeId { get; set; }
        public int? ProductUnitId { get; set; }
        public bool? IsSingle { get; set; }
        public bool? IsWholeQuantity { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Color Color { get; set; }
        public virtual ColorCode ColorCode { get; set; }
        public virtual Model Model { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual ProductLabel ProductLabel { get; set; }
        public virtual ProductUnit ProductUnit { get; set; }
        public virtual Size Size { get; set; }
        public virtual Style Style { get; set; }
        public virtual ICollection<SalesSchemaDetail> SalesSchemaDetails { get; set; }
    }
}
