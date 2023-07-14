﻿using Microsoft.AspNetCore.Components.Authorization;


namespace Diploma.Client.Shared
{
    public partial class AccountButton
    {
        //private bool showAccountMenu = false;

        //private string AccountMenuCssClass => showAccountMenu ? "show-menu" : null;

        //private void ToggleAccountMenu()
        //{
        //    showAccountMenu = !showAccountMenu;
        //}

        //private async Task HideAccountMenu()
        //{
        //    await Task.Delay(200);
        //    showAccountMenu = false;
        //}

        private async Task Logout()
        {
            await LocalStorageService.RemoveItemAsync("token");
            await AuthStateProvider.GetAuthenticationStateAsync();
            NavigationManager.NavigateTo("");
        }
    }
}
