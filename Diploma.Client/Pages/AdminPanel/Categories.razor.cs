using Diploma.DTO;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class Categories
    {
        CategoryDto editingCategory = null;

        protected override async Task OnInitializedAsync()
        {
            await CategoryService.GetAdminCategories();
            CategoryService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            CategoryService.OnChange -= StateHasChanged;
        }

        private void CreateNewCategory()
        {
            editingCategory = CategoryService.CreateCategory();
        }

        private void EditCategory(CategoryDto category)
        {
            category.IsBeingEdited = true;
            editingCategory = category;
        }

        private async Task UpdateCategory()
        {
            if (editingCategory.IsNew)
                await CategoryService.AddCategory(editingCategory);
            else
                await CategoryService.UpdateCategory(editingCategory);
            editingCategory = new CategoryDto();
        }

        private async Task CancelEditing()
        {
            editingCategory = new CategoryDto();
            await CategoryService.GetAdminCategories();
        }

        private async Task DeleteCategory(int id)
        {
            await CategoryService.RemoveCategory(id);
        }
    }
}
