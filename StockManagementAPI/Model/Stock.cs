using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagementAPI.Model
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public long StockId { get; set; }
        public long ProductId { get; set; }
        public string BatchNo { get; set; }
        public int Quantity { get; set; }
        public string EditedById { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
