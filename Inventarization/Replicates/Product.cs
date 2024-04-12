using HealthAPI.Models;

namespace HealthAPI.Replicates
{
    public class Product
    {

        public EFProduct Context { get; set; }
        public Product(EFProduct context) { Context = context; }

        public int Id { get => Context.Id; }
        public string Name { get => Context.Name; set => Context.Name = value; }
        public int Quantity { get => Context.Quantity; set => Context.Quantity = value; }
        public int Price { get => Context.Price; set => Context.Price = value; }
        public string Status { get => Context.Status; set => Context.Status = value; }

        public List<Storage> Storages { get => Context.Storages.Select(it => new Storage(it)).ToList(); }
    }
}
