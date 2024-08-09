namespace ShoppingApp.Model
{
    public class LineItem
    {
        public int LineItemId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public LineItem(int lineItemId, int quantity, Product product)
        {
            LineItemId = lineItemId;
            Quantity = quantity;
            Product = product;
        }

        public double CalculateLineItemCost()
        {
            double lineItemCost = Quantity * Product.CalculateDiscountedPrice();
            return lineItemCost;
        }
    }
}
