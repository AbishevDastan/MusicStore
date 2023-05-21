using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
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

        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();


        public async Task GetCategories()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CategoryDTO>>("api/category");

            if (response != null)
            {
                Categories = response;
            }
        }

        public async Task<CategoryDTO> GetCategory(int categoryId)
        {
            var result = await _httpClient.GetFromJsonAsync<CategoryDTO>($"api/category/{categoryId}");
            return result;
        }
    }
}
