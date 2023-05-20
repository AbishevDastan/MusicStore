using Diploma.Domain.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;

namespace Diploma.Client.Pages
{
    public partial class ItemDetails
    {
        private Item? item = null;

        [Parameter]
        public int Id { get; set; }
        private string message = string.Empty; 

        protected override async Task OnParametersSetAsync()
        {
            message = "Loading product...";
            var result = await ItemService.GetItem(Id);
            if (!result.Success) 
            {
                message = result.Message;
            }
            else
            {
                item = result.Data;
            }
        }
    }
}
