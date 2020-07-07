namespace CS460_Hwk06.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Warehouse.StockItems")]
    public partial class StockItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockItem()
        {
            // ask or figure out what these do/are for.....
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            InvoiceLines = new HashSet<InvoiceLine>();
            OrderLines = new HashSet<OrderLine>();
            SpecialDeals = new HashSet<SpecialDeal>();
            StockItemStockGroups = new HashSet<StockItemStockGroup>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
        }
        //===============================================================================
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StockItemID { get; set; }

        //===============================================================================
        [Required, DisplayName("Stock Item Name:")]
        [StringLength(100)]
        public string StockItemName { get; set; }

        //===============================================================================
        public int SupplierID { get; set; }

        //===============================================================================
        public int? ColorID { get; set; }

        //===============================================================================
        public int UnitPackageID { get; set; }

        //===============================================================================
        public int OuterPackageID { get; set; }

        //===============================================================================
        [StringLength(50)]
        public string Brand { get; set; }

        //===============================================================================
        [DisplayName("Size:")]
        [StringLength(20)]
        public string Size { get; set; }

        //===============================================================================
        [DisplayName("Lead Time (in days):")]
        public int LeadTimeDays { get; set; }

        //===============================================================================
        public int QuantityPerOuter { get; set; }

        //===============================================================================
        public bool IsChillerStock { get; set; }

        //===============================================================================
        [StringLength(50)]
        public string Barcode { get; set; }

        //===============================================================================
        public decimal TaxRate { get; set; }

        //===============================================================================
        [DisplayName("Unit Cost:")]
        public decimal UnitPrice { get; set; }

        //===============================================================================
        [DisplayName("Recommended Retail:")]
        public decimal? RecommendedRetailPrice { get; set; }

        //===============================================================================
        [DisplayName("Typical Weight per Unit:")]
        public decimal TypicalWeightPerUnit { get; set; }

        //===============================================================================
        public string MarketingComments { get; set; }

        //===============================================================================
        public string InternalComments { get; set; }

        //===============================================================================
        public byte[] Photo { get; set; }

        //===============================================================================
        public string CustomFields { get; set; }

        //===============================================================================
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayName("Item Tags:")]
        public string Tags { get; set; }

        //===============================================================================
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        public string SearchDetails { get; set; }

        //===============================================================================
        public int LastEditedBy { get; set; }

        //===============================================================================
        [Column(TypeName = "datetime2")]
        [DisplayName("Valid Since:")]
        public DateTime ValidFrom { get; set; }

        //===============================================================================
        [Column(TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }

        //===============================================================================
        public virtual Person Person { get; set; }

        //===============================================================================
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }

        //===============================================================================
        public virtual Supplier Supplier { get; set; }

        //===============================================================================
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }

        //===============================================================================
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        //===============================================================================
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }

        //===============================================================================
        public virtual Color Color { get; set; }

        //===============================================================================
        public virtual PackageType PackageType { get; set; }

        //===============================================================================
        public virtual PackageType PackageType1 { get; set; }

        //===============================================================================
        public virtual StockItemHolding StockItemHolding { get; set; }

        //===============================================================================
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockItemStockGroup> StockItemStockGroups { get; set; }

        //===============================================================================
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }

        //===============================================================================
    }
}
