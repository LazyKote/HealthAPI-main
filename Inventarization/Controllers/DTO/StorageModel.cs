using HealthAPI.Replicates;

namespace HealthAPI.Controllers.DTO
{
    public class StorageModel
    {
        public StorageModel() { }
        public StorageModel(Storage context)
        {
            id = context.Id;
            name = context.Name;
            address = context.Address;
            phoneNumber = context.PhoneNumber;
            owner = context.Owner;
            products = context.Products.Select(it => new ProductModel(it)).ToArray();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int phoneNumber { get; set; }
        public string owner {  get; set; }
        public ProductModel[] products { get; set; }
    }
}
