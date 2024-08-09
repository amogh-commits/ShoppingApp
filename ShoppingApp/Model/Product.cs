namespace ShoppingApp.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public double ProductDiscountPercentage { get; set; }

        public Product(int productId, string productName, double productPrice, double productDiscountPercentage)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductDiscountPercentage = productDiscountPercentage;
        }

        public double CalculateDiscountedPrice()
        {
            double finalProductPrice = ProductPrice - ((ProductPrice * ProductDiscountPercentage) / 100);
            return finalProductPrice;
        }
    }
}
