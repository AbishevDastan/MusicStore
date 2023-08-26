using Diploma.Client.Services.CategoryService;
using Diploma.Domain.Entities;
using Diploma.DTO.Category;
using Microsoft.AspNetCore.Components;

namespace Diploma.Client.Pages
{
    public partial class EditDeliveryInfo
    {
        [Parameter]
        public int? Id { get; set; }

        string btnText = string.Empty;

        DeliveryInformation deliveryInfo = new() { };

        protected override void OnInitialized()
        {
            btnText = Id == null ? "Save" : "Update Delivery Information";
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id is not null)
            {
                var result = await DeliveryService.GetDeliveryInfo((int)Id);
                if (result != null)
                {
                    deliveryInfo = result;
                }
                else
                {
                    NavigationManager.NavigateTo("/profile");
                }
            }
        }

        async Task HandleSubmit()
        {
            DeliveryService.AddOrUpdateDeliveryInfo(deliveryInfo);
        }
    }
}
