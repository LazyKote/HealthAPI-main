using HealthAPI.Context;
using HealthAPI.Controllers.DTO;
using HealthAPI.Replicates;
using Microsoft.AspNetCore.Mvc;

namespace HealthAPI.Controllers
{
    public class StorageController:BaseController
    {
        public StorageController(ApplicationContext _appContext):base(_appContext) { }

        [HttpGet("[controller]/[action]")]
        public JsonResult Init()
        {
            var res = GetCommon();
            return Send(true, res);
        }

        [HttpGet("[controller]/[action]")]
        public JsonResult GetAll()
        {
            var res = GetCommon();
            res.storages = ApplicationContext.StorageManager.Storages.Select(it => new StorageModel(it));
            return Send(true, res);
        }


        [HttpGet("[controller]/[action]")]
        public JsonResult Get(int id)
        {
            var res = GetCommon();
            res.storages = new StorageModel(ApplicationContext.StorageManager.Storages.FirstOrDefault(it => it.Id == id));
            return Send(true, res);
        }

        [HttpPost("[controller]/[action]")]
        public JsonResult Create([FromBody] StorageModel model)
        {
            Storage storage = ApplicationContext.StorageManager.Create(model);

            var res = GetCommon();
            res.storages = new StorageModel(storage);
            return Send(true, res);
        }

        [HttpPut("[controller]/[action]")]
        public JsonResult Update([FromBody] StorageModel model)
        {

            Storage storage = ApplicationContext.StorageManager.Update(model);

            var res = GetCommon();
            res.storages = new StorageModel(storage);
            return Send(true, res);
        }

        [HttpGet("[controller]/[action]")]
        public JsonResult GetProducts(int storageId)
        {

            Product[] products = ApplicationContext.StorageManager.GetProducts(storageId);

            var res = GetCommon();
            res.products = products.Select(it => new ProductModel(it));
            return Send(true, res);
        }
        [HttpPost("[controller]/[action]")]
        public JsonResult AttachProduct(int storageId, int productId)
        {

            Product[] products = ApplicationContext.StorageManager.AttachProduct(storageId, productId);

            var res = GetCommon();
            res.products = products.Select(it => new ProductModel(it));
            return Send(true, res);
        }
        [HttpPost("[controller]/[action]")]
        public JsonResult DettachProduct(int storageId, int productId)
        {

            Product[] products = ApplicationContext.StorageManager.DettachProduct(storageId, productId);

            var res = GetCommon();
            res.products = products.Select(it => new ProductModel(it));
            return Send(true, res);
        }

        [HttpDelete("[controller]/[action]")]
        public JsonResult Delete(int id)
        {
            ApplicationContext.StorageManager.Delete(id);
            var res = GetCommon();
            res.Storages = ApplicationContext.StorageManager.Storages.Select(it => new StorageModel(it));
            return Send(true, res);
        }
    }
}
