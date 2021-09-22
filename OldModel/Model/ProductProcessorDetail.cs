using System;
using System.Collections.Generic;

#nullable disable

namespace OldModel.Model
{
    public partial class ProductProcessorDetail
    {
        public ProductProcessorDetail()
        {
            ProductProcessorProductBrandFeatures = new HashSet<ProductProcessorProductBrandFeature>();
            ProductProcessorProductFeatures = new HashSet<ProductProcessorProductFeature>();
        }

        public long ProductProcessorDetailId { get; set; }
        public long ProductProcessorId { get; set; }
        public int? LocationId { get; set; }
        public byte[] Version { get; set; }
        public string BarCode { get; set; }
        public string ProductTemplateCode { get; set; }
        public int? ProductTemplateId { get; set; }
        public int? ProductTemplateIdDictionary { get; set; }
        public int? ProductId { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Qty { get; set; }
        public string BrandName { get; set; }
        public int? BrandId { get; set; }
        public string BrandIdDictionary { get; set; }
        public string ProductGroup { get; set; }
        public int? ProductGroupId { get; set; }
        public int? ProductGroupIdDictionary { get; set; }
        public string ProductLabel { get; set; }
        public long? ProductLabelId { get; set; }
        public long? ProductLabelIdDictionary { get; set; }
        public int? SalesSchemaId1 { get; set; }
        public int? SalesSchemaId2 { get; set; }
        public int? SalesSchemaId3 { get; set; }
        public int? SalesSchemaId4 { get; set; }
        public int? SalesSchemaId5 { get; set; }
        public decimal? SalesPrice1 { get; set; }
        public decimal? SalesPrice2 { get; set; }
        public decimal? SalesPrice3 { get; set; }
        public decimal? SalesPrice4 { get; set; }
        public decimal? SalesPrice5 { get; set; }

        public virtual ProductProcessor ProductProcessor { get; set; }
        public virtual ICollection<ProductProcessorProductBrandFeature> ProductProcessorProductBrandFeatures { get; set; }
        public virtual ICollection<ProductProcessorProductFeature> ProductProcessorProductFeatures { get; set; }
    }
}
