using Azure;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace Diploma.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public CategoryService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public List<CategoryDto> AdminCategories { get; set; } = new List<CategoryDto>();
        public event Action CategoriesChanged;


        string ICategoryService.Message { get; set; } = "Loading Categories...";

        public async Task GetCategories()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CategoryDto>>("api/category");

            if (response is not null)
            {
                Categories = response;
            }

            CategoriesChanged?.Invoke();
        }

        public async Task<CategoryDto?> GetCategory(int id)
        {
            var response = await _httpClient.GetAsync($"api/category/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<CategoryDto>();
            }
            return null;
        }

        public async Task GetAdminCategories()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CategoryDto>>("api/category/admin");

            if (response is not null)
            {
                AdminCategories = response;
            }
            CategoriesChanged?.Invoke();

        }

        public async Task CreateCategory(CategoryDto categoryDto)
        {
            await _httpClient.PostAsJsonAsync("api/category/admin", categoryDto);
            _navigationManager.NavigateTo("categories/admin");
        }

        public async Task UpdateCategory(int id, CategoryDto categoryDto)
        {
            await _httpClient.PutAsJsonAsync($"api/category/admin/{id}", categoryDto);
            _navigationManager.NavigateTo("categories/admin");
        }

        public async Task DeleteCategory(int id)
        {
            await _httpClient.DeleteAsync($"api/category/admin/{id}");
            _navigationManager.NavigateTo("categories/admin");
        }
    }
}
