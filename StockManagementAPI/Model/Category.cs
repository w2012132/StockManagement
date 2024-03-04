using System.Text.Json.Serialization;

namespace StockManagementAPI.Model
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid? ParentCategoryId { get; set; } // Nullable for top-level categories
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string EditedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        // Navigation property for parent-child relationship (self-referencing)
        [JsonIgnore]
        public virtual Category ParentCategory { get; set; }
        [JsonIgnore]
        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();
    }
}
