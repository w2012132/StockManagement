namespace StockManagementAPI.Model
{
    public class Order
    {
        public Guid OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public Guid CustomerId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string EditedBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
