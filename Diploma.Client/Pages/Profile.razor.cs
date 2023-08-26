using Diploma.Domain.Entities;

namespace Diploma.Client.Pages
{
    public partial class Profile
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        DeliveryInformation deliveryInfo = new DeliveryInformation();
        User user = new User();

        protected override async Task OnInitializedAsync()
        {
            deliveryInfo = await DeliveryService.GetDeliveryInfo(UserId);
            user = await UserService.GetCurrentUser(UserId);
        }

        private void EditDeliveryInfo()
        {
            NavigationManager.NavigateTo("/delivery/{id:int}");
        }
    }
}
