using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Blazor.Extensions.Storage;
using DemoBlazor.Models;
using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Services
{
    public class ProductService:IProductService
    {
        private HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
        }

        
        public Task<Product[]> GetProducts()
        {
            return _httpClient.GetJsonAsync<Product[]>("https://localhost:44335/api/products/getall");
        }

        public Task<Product> GetProductById(int productId)
        {
            return _httpClient.GetJsonAsync<Product>("https://localhost:44335/api/products/getbyid?productId="+productId);
        }

        public async Task Save(Product product)
        {
            await _httpClient.PostJsonAsync("https://localhost:44335/api/products/update", product);
        }

        public async Task Add(Product product)
        {
            
            await _httpClient.PostJsonAsync("https://localhost:44335/api/products/add", product);
        }
    }
}
