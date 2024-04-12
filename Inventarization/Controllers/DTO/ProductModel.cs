using HealthAPI.Replicates;

namespace HealthAPI.Controllers.DTO
{
    public class ProductModel
    {
        public ProductModel() { }
        public ProductModel(Product context)
        {
            id = context.Id;
            name = context.Name;
            quantity = context.Quantity;
            price = context.Price;
            status = context.Status;
        }

        public int id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public string status { get; set; }
    }
}   
