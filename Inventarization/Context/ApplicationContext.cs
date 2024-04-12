using HealthAPI.Managers;
using Microsoft.EntityFrameworkCore;

namespace HealthAPI.Context
{
    public class ApplicationContext
    {

        public ApplicationContext(IConfiguration config)
        {
            Version = "0.1";
            Title = "HealthAPI";
            Configuration = config;
            Initialize();
        }

        public void Initialize()
        {

            /*Инициализация менеджеров*/
            StorageManager = new StoragesManager(this);
            ProductsManager = new ProductsManager(this);

            /*StorageManager.Read();*/
            /*ProductsManager.Read();*/

        }

        public StoragesManager StorageManager { get; set; }
        public ProductsManager ProductsManager { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public IConfiguration Configuration { get; set; }

        /*Здесь указать название подключения из appsettings*/
        public DBContext CreateDbContext() => new DBContext(Configuration.GetConnectionString("Connection"));

    }
}
