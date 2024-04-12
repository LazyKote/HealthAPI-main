using HealthAPI.Context;
using HealthAPI.Controllers.DTO;
using HealthAPI.Models;
using HealthAPI.Replicates;
using Microsoft.EntityFrameworkCore;

namespace HealthAPI.Managers
{
    public class ProductsManager
    {

        protected ApplicationContext ApplicationContext { get; set; }
        protected DBContext DBContext { get; set; }
        public ProductsManager(ApplicationContext applicationContext) { ApplicationContext = applicationContext; DBContext = applicationContext.CreateDbContext(); }

        private List<Product> _products { get; set; } = new List<Product>();

        public Product[] Products { get => _products.ToArray(); }
        public bool Read()
        {
            try
            {

                DBContext.Products.Include(it => it.Storages).ToList();
                foreach (EFProduct item in DBContext.Products)
                {
                    if (item.IsDeleted != true) _products.Add(new Product(item));
                }
                return true;
            }
            catch { throw; }
        }

        public Product Get(int id) => _products.FirstOrDefault(it => it.Id == id);

        public Product Create(ProductModel model)
        {
            try
            {
                EFProduct Product = new EFProduct()
                {
                    Name = model.name,
                    Quantity = model.quantity,
                    Status = model.status,
                    Price = model.price
                };
                DBContext.Add(Product);
                DBContext.SaveChanges();

                Product replicate = new Product(Product);
                _products.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public Product Update(ProductModel model)
        {
            try
            {

                EFProduct _Product = DBContext.Products.FirstOrDefault(it => it.Id == model.id);


                _Product.Name = model.name;
                _Product.Quantity = model.quantity;
                _Product.Price = model.price;
                _Product.Status = model.status;

                DBContext.Update(_Product);

                _products.Remove(_products.FirstOrDefault(it => it.Id == model.id));
                Product repl = new Product(_Product);
                _products.Add(repl);

                return repl;
            }
            catch { throw; }
        }

        public bool Delete(int id)
        {
            try
            {

                EFProduct _Product = DBContext.Products.FirstOrDefault(it => it.Id == id);
                _Product.IsDeleted = true;
                DBContext.Update(_Product);

                _products.Remove(_products.FirstOrDefault(it => it.Id == id));
                return true;

            }
            catch { throw; }
        }
    }
}
