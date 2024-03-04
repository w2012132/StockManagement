namespace StockManagementAPI.Model
{
    public class OrderDetail
    {
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public long StockId { get; set; }
        public int OrderedQty { get; set; }

    }
}
