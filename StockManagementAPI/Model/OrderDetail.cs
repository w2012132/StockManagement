using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagementAPI.Model
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public long StockId { get; set; }
        public int OrderedQty { get; set; }

    }
}
