using Diploma.DTO;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class EditCategory
    {
        [Parameter]
        public int? Id { get; set; }

        string btnText = string.Empty;

        CategoryDto categoryDto = new() { };

        protected override void OnInitialized()
        {
            btnText = Id == null ? "Save" : "Update Category";
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id is not null)
            {
                var result = await CategoryService.GetCategory((int)Id);
                if (result != null)
                {
                    categoryDto = result;
                }
                else
                {
                    NavigationManager.NavigateTo("/category/admin");
                }
            }
        }

        async Task HandleSubmit()
        {
            if (Id == null)
            {
                await CategoryService.CreateCategory(categoryDto);
            }
            else
            {
                await CategoryService.UpdateCategory((int)Id, categoryDto);
            }
        }

        async Task DeleteCategory()
        {
            await CategoryService.DeleteCategory(categoryDto.Id);
        }
    }
}
