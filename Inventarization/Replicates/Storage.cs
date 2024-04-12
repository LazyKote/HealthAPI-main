using HealthAPI.Models;

namespace HealthAPI.Replicates
{
    public class Storage
    {
        private EFStorage Context { get; set; }
        public Storage(EFStorage context) { Context = context; }
        public int Id { get => Context.Id; }
        public string Name { get => Context.Name; set => Context.Name = value; }

        public string Address { get => Context.Address; set => Context.Address = value; }
        public int PhoneNumber { get => Context.PhoneNumber; set => Context.PhoneNumber = value; }
        public string Owner { get => Context.Owner; set => Context.Owner = value; }
        public List<Product> Products { 
            get => Context.EFProducts.Select(it => new Product(it)).ToList();
        }
    }
}
