using Diploma.DTO.Item;

namespace Diploma.Client.Pages.AdminPanel
{
    public partial class ItemsStatistics
    {
        private List<ItemDetailsForStatistics> items;

        protected override async Task OnInitializedAsync()
        {
            items = await _itemService.GetStatistics();
        }
    }
}
