using Diploma.Domain.Entities;
using Diploma.DTO.Orders;

namespace Diploma.Client.Pages
{
    public partial class Profile
    {
        List<DeliveryInformation> deliveryInfos;
        DeliveryInformation deliveryInfo;
        User user = new User();
        Order? order = null;
        bool canEditDeliveryInfo;
        bool isPendingOrDelivered;

        protected override async Task OnInitializedAsync()
        {
            deliveryInfos = await DeliveryService.GetDeliveryInfos();
            foreach (var deliveryInfo in deliveryInfos)
            {
                deliveryInfo.IsLinkedToOrder = await OrderService.IsDeliveryInfoLinkedToOrders(deliveryInfo.Id);
            }
            user = await UserService.GetCurrentUser();
        }

        private async Task<bool> CanEditDeliveryInformation()
        {
            canEditDeliveryInfo = true;
            foreach (var orderId in deliveryInfo.OrderIds)
            {
                order = await OrderService.GetOrder(orderId);
                if (order != null && order.Status == OrderStatus.Shipped)
                {
                    canEditDeliveryInfo = false;
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> IsPendingOrDelivered()
        {
            isPendingOrDelivered = true;
            foreach (var orderId in deliveryInfo.OrderIds)
            {
                order = await OrderService.GetOrder(orderId);
                if (order != null)
                {
                    if (order.Status == OrderStatus.Delivered || order.Status == OrderStatus.Pending)
                    {
                        isPendingOrDelivered = false;
                        return false;
                    }
                }
            }
            return true;
        }

        private void EditDeliveryInfo(int deliveryInfoId)
        {
            NavigationManager.NavigateTo($"/delivery/{deliveryInfoId}");
        }

        private async Task DeleteDeliveryInfo(int deliveryInfoId)
        {
            await DeliveryService.DeleteDeliveryInfo(deliveryInfoId);

            deliveryInfo = deliveryInfos.Find(x => x.Id == deliveryInfoId);
            if (deliveryInfo != null)
            {
                deliveryInfos.Remove(deliveryInfo);
            }
            NavigationManager.NavigateTo("/profile");
            StateHasChanged();
        }

        private void AddNewDeliveryInfo()
        {
            NavigationManager.NavigateTo("/delivery");
        }
    }
}
