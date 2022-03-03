using MicrosWPSShopping.Web.Models;
using MicrosWPSShopping.Web.Services.IServices;
using MicrosWPSShopping.Web.Utils;

namespace MicrosWPSShopping.Web.Services
{
    public class ProductServices : IProductService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "api/v1/product";

        public ProductServices(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<ProductModel> Create(ProductModel model)
        {
            var response = await _httpClient.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAsync<ProductModel>();
            else
                throw new Exception("Algo deu errado na requisição da api WPS :'(");
        }

        public async Task<bool> DeleteById(long id)
        {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAsync<bool>();
            else
                throw new Exception("Algo deu errado na requisição da api WPS :'(");
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAsync<List<ProductModel>>();
        }

        public async Task<ProductModel> GetProductById(long id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<ProductModel> Update(ProductModel model)
        {
            var response = await _httpClient.PutAsJsonAsync(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAsync<ProductModel>();
            else
                throw new Exception("Algo deu errado na requisição da api WPS :'(");
        }
    }
}
