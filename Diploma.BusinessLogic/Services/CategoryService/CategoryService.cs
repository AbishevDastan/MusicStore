using Diploma.Domain;
using Diploma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Category> Categories { get; set; } = new List<Category>();


        public async Task GetCategories()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");

            if (response != null && response.Data != null)
            {
                Categories = response.Data;
            }
        }

        public async Task<ServiceResponse<Category>> GetCategory(int categoryId)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Category>>($"api/Category/{categoryId}");
            return result;
        }
    }
}
