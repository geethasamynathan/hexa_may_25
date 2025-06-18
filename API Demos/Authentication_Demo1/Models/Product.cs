namespace Authentication_Demo1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Manufacturing_Cost { get; set; }
        public DateTime? ManufacturedDate { get; set; }
        public int Selling_Price { get; set; }
        public bool IsActive { get; set; }
        public string ProductImageUrl { get; set; }  // Stores image URL or relative path
        public string SKU { get; set; }  // Stock Keeping Unit - unique code
        public string Category { get; set; } // e.g., Electronics, Clothing
        public int StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}
