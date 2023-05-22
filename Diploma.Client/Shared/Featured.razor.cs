namespace Diploma.Client.Shared
{
    public partial class Featured
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
