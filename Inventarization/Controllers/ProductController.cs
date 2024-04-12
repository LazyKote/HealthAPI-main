using HealthAPI.Context;
using HealthAPI.Controllers.DTO;
using HealthAPI.Replicates;
using Microsoft.AspNetCore.Mvc;

namespace HealthAPI.Controllers
{
    public class ProductController:BaseController
    {
        public ProductController(ApplicationContext _appContext):base(_appContext) { }


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
            res.products = ApplicationContext.ProductsManager.Products.Select(it => new ProductModel(it));
            return Send(true, res);
        }


        [HttpGet("[controller]/[action]")]
        public JsonResult Get(int id)
        {
            var res = GetCommon();
            res.products = new ProductModel(ApplicationContext.ProductsManager.Products.FirstOrDefault(it => it.Id == id));
            return Send(true, res);
        }

        [HttpPost("[controller]/[action]")]
        public JsonResult Create([FromBody] ProductModel model)
        {
            Product doctor = ApplicationContext.ProductsManager.Create(model);

            var res = GetCommon();
            res.products = new ProductModel(doctor);
            return Send(true, res);
        }

        [HttpPut("[controller]/[action]")]
        public JsonResult Update([FromBody] ProductModel model)
        {

            Product doctor = ApplicationContext.ProductsManager.Update(model);

            var res = GetCommon();
            res.products = new ProductModel(doctor);
            return Send(true, res);
        }

        [HttpDelete("[controller]/[action]")]
        public JsonResult Delete(int id)
        {
            ApplicationContext.ProductsManager.Delete(id);
            var res = GetCommon();
            res.products = ApplicationContext.ProductsManager.Products.Select(it => new ProductModel(it));
            return Send(true, res);
        }
    }
}
