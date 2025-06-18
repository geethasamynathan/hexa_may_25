namespace Authentication_Demo1.DTOs
{
    public class ProductCreationDTO
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Category { get; set; }
        public int Manufacturing_Cost { get; set; }
        public int Selling_Price { get; set; }
        public int StockQuantity { get; set; }
        public string ProductImageUrl { get; set; }  // Stores image URL or relative path
        public DateTime? ManufacturedDate { get; set; }
    }
}
