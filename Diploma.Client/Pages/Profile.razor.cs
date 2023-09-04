﻿using Diploma.Domain.Entities;

namespace Diploma.Client.Pages
{
    public partial class Profile
    {
        List<DeliveryInformation> deliveryInfos;
        DeliveryInformation deliveryInfo;
        User user = new User();
        bool isLinked = false;

        protected override async Task OnInitializedAsync()
        {
            deliveryInfos = await DeliveryService.GetDeliveryInfos();
            foreach (var deliveryInfo in deliveryInfos)
            {
                deliveryInfo.IsLinkedToOrder = await OrderService.IsDeliveryInfoLinkedToOrders(deliveryInfo.Id);
            }
            user = await UserService.GetCurrentUser();
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
