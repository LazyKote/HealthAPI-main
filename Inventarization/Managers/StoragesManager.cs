using HealthAPI.Context;
using HealthAPI.Controllers.DTO;
using HealthAPI.Models;
using HealthAPI.Replicates;
using Microsoft.EntityFrameworkCore;

namespace HealthAPI.Managers
{
    public class StoragesManager
    {

        protected ApplicationContext ApplicationContext { get; set; }
        protected DBContext DBContext { get; set; }
        public StoragesManager (ApplicationContext applicationContext) { ApplicationContext = applicationContext;  DBContext = applicationContext.CreateDbContext(); }

        private List<Storage> _storages { get; set; } = new List<Storage> ();

        public Storage[] Storages { get => _storages.ToArray (); }
        public bool Read()
        {
            try
            {
                DBContext.Storages.Include(it => it.EFProducts).ToList();
                foreach (EFStorage item in DBContext.Storages)
                {
                    if(item.IsDeleted != true) _storages.Add(new Storage(item));
                }
                return true;
            }
            catch { throw; }
        }

        public Storage Get(int id) => _storages.FirstOrDefault(it => it.Id == id);

        public Storage Create(StorageModel model)
        {
            try
            {
                EFStorage storage = new EFStorage()
                {
                    Name = model.name,
                    Address = model.address,
                    PhoneNumber = model.phoneNumber,
                    Owner = model.owner
                };
                DBContext.Add(storage);
                DBContext.SaveChanges();

                Storage replicate = new Storage(storage);
                _storages.Add(replicate);

                return replicate;
            }
            catch { throw; }
        }

        public Storage Update(StorageModel model)
        {
            try
            {

                EFStorage _storage = DBContext.Storages.FirstOrDefault(it => it.Id == model.id);


                _storage.Name = model.name;
                _storage.Address = model.address;
                _storage.PhoneNumber = model.phoneNumber;
                _storage.Owner = model.owner;

                DBContext.Update(_storage);
                DBContext.SaveChanges();

                _storages.Remove(_storages.FirstOrDefault(it => it.Id == model.id));
                Storage repl = new Storage(_storage);
                _storages.Add(repl);

                return repl;
            }
            catch { throw; }
        }

        public Product[] GetProducts(int storageId)
        {
            return Get(storageId).Products.ToArray();
        }

        public Product[] AttachProduct(int storageId, int productId)
        {
            var Product = ApplicationContext.ProductsManager.Get(productId);

            var _storage = DBContext.Storages.FirstOrDefault(it => it.Id == storageId);
            _storage.EFProducts.Add(Product.Context);

            DBContext.Update(_storage);
            DBContext.SaveChanges();

            var Storage = Get(storageId);
            Storage.Products.Add(Product);

            return GetProducts(storageId);
        }

        public Product[] DettachProduct(int storageId, int productId)
        {
            var Product = ApplicationContext.ProductsManager.Get(productId);

            var _storage = DBContext.Storages.FirstOrDefault(it => it.Id == storageId);
            _storage.EFProducts.Remove(Product.Context);

            DBContext.Update(_storage);
            DBContext.SaveChanges();


            var Storage = Get(storageId);
            Storage.Products.Remove(Product);

            return GetProducts(storageId);
        }

        public bool Delete(int id)
        {
            try
            {

                EFStorage _storage = DBContext.Storages.FirstOrDefault(it => it.Id == id);
                _storage.IsDeleted = true;
                DBContext.Update(_storage);
                DBContext.SaveChanges();
                _storages.Remove(_storages.FirstOrDefault(it => it.Id == id));
                return true;

            }
            catch { throw; }



        }

    }
}
