namespace Diploma.Client.Shared
{
    public partial class CategoriesButton
    {
        private bool showCategoriesMenu = false;

        private string CategoriesMenuCssClass => showCategoriesMenu ? "show-categories-menu" : null;

        private void ToggleCategoriesMenu()
        {
            showCategoriesMenu = !showCategoriesMenu;
        }

        private async Task HideCategoriesMenu()
        {
            await Task.Delay(200);
            showCategoriesMenu = false;
        }

        protected override async Task OnInitializedAsync()
        {
            await CategoryService.GetCategories();
        }
    }
}
