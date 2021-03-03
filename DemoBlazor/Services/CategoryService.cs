using System.Net.Http;
using System.Threading.Tasks;
using DemoBlazor.Models;
using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient http)
        {
            _httpClient = http;
        }
        public Task<Category[]> GetCategories()
        {
            return _httpClient.GetJsonAsync<Category[]>("https://localhost:44335/api/categories/getall");
        }
    }
}
