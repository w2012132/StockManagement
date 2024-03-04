using System.Text.Json.Serialization;

namespace StockManagementAPI.Model
{
    public class Dispatch
    {
        public Guid DispatchId { get; set; }
        public Guid OrderNo { get; set; } // Foreign key reference to Order
        public DateTime DispatchDate { get; set; }
        public string Carrier { get; set; }
        public string Status { get; set; } // Example values: Prepared, Shipped, Delivered
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string EditedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        // Navigation property to Order
        [JsonIgnore]
        public virtual Order Order { get; set; }

        // Collection navigation property to DispatchDetails
        [JsonIgnore]
        public virtual ICollection<DispatchDetail> DispatchDetails { get; set; } = new List<DispatchDetail>();
    }
}
