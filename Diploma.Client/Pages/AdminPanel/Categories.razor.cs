//using Diploma.DTO;

//namespace Diploma.Client.Pages.AdminPanel
//{
//    public partial class Categories
//    {
//        CategoryDTO editingCategory = null;

//        protected override async Task OnInitializedAsync()
//        {
//            await CategoryService.GetAdminCategories();
//            CategoryService.OnChange += StateHasChanged;
//        }

//        public void Dispose()
//        {
//            CategoryService.OnChange -= StateHasChanged;
//        }

//        private void CreateNewCategory()
//        {
//            editingCategory = CategoryService.CreateCategory();
//        }

//        private void EditCategory(CategoryDTO category)
//        {
//            category.IsBeingEdited = true;
//            editingCategory = category;
//        }

//        private async Task UpdateCategory()
//        {
//            if (editingCategory.IsNew)
//                await CategoryService.AddCategory(editingCategory);
//            else
//                await CategoryService.UpdateCategory(editingCategory);
//            editingCategory = new CategoryDTO();
//        }

//        private async Task CancelEditing()
//        {
//            editingCategory = new CategoryDTO();
//            await CategoryService.GetAdminCategories();
//        }

//        private async Task DeleteCategory(int id)
//        {
//            await CategoryService.RemoveCategory(id);
//        }
//    }
//}
