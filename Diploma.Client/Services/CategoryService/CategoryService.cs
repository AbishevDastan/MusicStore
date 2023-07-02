using Diploma.DTO;
using System.Net.Http.Json;

namespace Diploma.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        //public List<CategoryDTO> AdminCategories { get; set; } = new List<CategoryDTO>();

        //public event Action OnChange;

        //public async Task AddCategory(CategoryDTO categoryDTO)
        //{
        //    var response = await _httpClient.PostAsJsonAsync("api/category/admin", categoryDTO);
        //    AdminCategories = (await response.Content.ReadFromJsonAsync<List<CategoryDTO>>());
        //    await GetCategories();
        //    OnChange.Invoke();
        //}

        //public CategoryDTO CreateCategory()
        //{
        //    var newCategory = new CategoryDTO
        //    {
        //        IsNew = true,
        //        IsBeingEdited = true
        //    };

        //    AdminCategories.Add( newCategory );
        //    OnChange.Invoke();
        //    return newCategory;
        //}

        //public async Task GetAdminCategories()
        //{
        //    var response = await _httpClient.GetFromJsonAsync<List<CategoryDTO>>("api/category/admin");

        //    if (response != null)
        //    {
        //        AdminCategories = response;
        //    }
        //}

        public async Task GetCategories()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CategoryDto>>("api/category");

            if (response != null)
            {
                Categories = response;
            }
        }

        public async Task<CategoryDto> GetCategory(int categoryId)
        {
            var result = await _httpClient.GetFromJsonAsync<CategoryDto>($"api/category/{categoryId}");
            return result;
        }

        //public async Task RemoveCategory(int categoryId)
        //{
        //    var response = await _httpClient.DeleteAsync($"api/category/admin/{categoryId}");
        //    AdminCategories = await response.Content.ReadFromJsonAsync<List<CategoryDTO>>();
        //    await GetCategories();
        //    OnChange.Invoke();
        //}

        //public async Task UpdateCategory(CategoryDTO categoryDTO)
        //{
        //    var response = await _httpClient.PutAsJsonAsync($"api/category/admin", categoryDTO);
        //    AdminCategories = (await response.Content.ReadFromJsonAsync<List<CategoryDTO>>());
        //    await GetCategories();
        //    OnChange.Invoke();
        //}
    }
}
