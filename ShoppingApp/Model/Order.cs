namespace ShoppingApp.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime DateTime { get; set; }
        public List<LineItem> Items { get; set; } = new List<LineItem>();

        public Order(int orderId, DateTime dateAndTime)
        {
            OrderId = orderId;
            DateTime = dateAndTime;
        }

        public double CalculateOrderPrice()
        {
            double orderPrice = 0;
            foreach (LineItem item in Items)
            {
                orderPrice += item.CalculateLineItemCost();
            }
            return orderPrice;
        }
    }
}
