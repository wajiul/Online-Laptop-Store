namespace LaptopStoreAPI.Persistence.Models
{
    public class ShoppingCart
    {
        public List<Product> Products { get; set; }
        public int TotalProduct 
        {
            get
            {
                int Count = 0;
                foreach (var item in Products)
                {
                    Count += item.Quantity;
                }
                return Count;
            }
        }
        public int TotalPrice 
        {
            get
            {
                int Cost = 0;
                foreach (var item in Products)
                {
                    Cost += item.Price * item.Quantity;
                }
                return Cost;
            }
        }
        public ShoppingCart()
        {
            Products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void InceraseProduct(int productId)
        {
            var product = Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                return;
           product.Quantity++;
        }
        public void DeceraseProduct(int productId)
        {
            var product = Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                return;
            product.Quantity--;
            if(product.Quantity == 0)
                Products.Remove(product);
        }

    }
}
