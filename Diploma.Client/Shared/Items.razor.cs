namespace Diploma.Client.Shared
{
    public partial class Items
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
