namespace Supermarket.DTO
{
    public class ProductResponse
    {
        public int ProductId { get; set; }

        public int UserId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public bool ProductStatus { get; set; }

        public virtual UserResponse User { get; set; } = null!;
    }
}
