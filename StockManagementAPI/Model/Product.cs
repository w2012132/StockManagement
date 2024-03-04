namespace StockManagementAPI.Model
{
    public class Product
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Guid CategoryId  { get; set; }
        public string BarcodeNo { get; set; }
        public string ProductCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string EditedBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
