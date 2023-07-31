using Diploma.DTO;

namespace Diploma.Client.Pages
{
    public partial class Orders
    {
        public List<OrderOverview> orders;

        protected override async Task OnInitializedAsync()
        {
            orders = await _orderService.GetOrdersForUser();
        }
    }
}
