using Diploma.Domain.Entities;

namespace Diploma.Client.Pages
{
    public partial class Profile
    {
        List<DeliveryInformation> deliveryInfos;
        User user = new User();
        Order order;

        protected override async Task OnInitializedAsync()
        {
            deliveryInfos = await DeliveryService.GetDeliveryInfos();
            user = await UserService.GetCurrentUser();
            foreach (DeliveryInformation info in deliveryInfos)
            {
                if (order != null)
                {
                    order = await OrderService.GetOrder(info.OrderId);
                }
            }
        }

        private void EditDeliveryInfo(int deliveryInfoId)
        {
            NavigationManager.NavigateTo($"/delivery/{deliveryInfoId}");
        }

        private async Task DeleteDeliveryInfo(int deliveryInfoId)
        {
            await DeliveryService.DeleteDeliveryInfo(deliveryInfoId);
            NavigationManager.NavigateTo("/profile");
        }

        private void AddNewDeliveryInfo()
        {
            NavigationManager.NavigateTo("/delivery");
        }
    }
}
