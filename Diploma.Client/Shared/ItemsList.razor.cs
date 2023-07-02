namespace Diploma.Client.Shared
{
    public partial class ItemsList
    {
        protected override void OnInitialized()
        {
            ItemService.ItemsChanged += StateHasChanged;
        }

        public void Dispose()
        {
            ItemService.ItemsChanged -= StateHasChanged;
        }
    }
}
