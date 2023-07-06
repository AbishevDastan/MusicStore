namespace Diploma.Client.Shared
{
    public partial class CategoriesNavMenu
    {
        protected override async Task OnInitializedAsync()
        {
            await CategoryService.GetCategories();
        }
    }
}
