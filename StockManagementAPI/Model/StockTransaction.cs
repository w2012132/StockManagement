using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagementAPI.Model
{
    public class StockTransaction
    {
        public long StockTransactionId { get; set; }
        public long ProductId { get; set; }
        public decimal TransactionQty { get; set; }
        public string TransactionType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
