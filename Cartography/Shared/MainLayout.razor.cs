namespace Cartography.Shared
{

    public partial class MainLayout
    {


        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        bool _drawerOpen = false;

    }

}
