using MudBlazor;

namespace Diploma.Client.Shared
{
    public partial class MainLayout
    {
        bool _drawerOpen = false;
        Anchor anchor;

        void DrawerToggle(Anchor anchor)
        {
            _drawerOpen = !_drawerOpen;
            this.anchor = anchor;
        }

        private void NavigateToHomePage()
        {
            NavigationManager.NavigateTo("");
        }

        private MudTheme _currentTheme = new MudTheme()
        {
            Palette = new PaletteLight
            {
                AppbarBackground = "#FAFAFA",
            },
        };
    }
}
