using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StockManagementAPI.Model
{
    [Table("DispatchDetail")]
    public class DispatchDetail
    {
        [Key]
        public long DispatchDetailID { get; set; }
        public Guid DispatchId { get; set; } // Foreign key reference to Dispatch
        public long OrderDetailsId { get; set; } // Foreign key reference to OrderDetail
        public int Quantity { get; set; }
        public string Status { get; set; } // Example values: Packed, Shipped, Delivered
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string EditedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        // Navigation properties
        [JsonIgnore]
        public virtual Dispatch? Dispatch { get; set; }
        [JsonIgnore]
        public virtual OrderDetail? OrderDetail { get; set; }
    }
}
