using MAUI_Template.View;

namespace MAUI_Template;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        #region ROUTES_REGISTRY
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(CollectionPage), typeof(CollectionPage));
        #endregion
    }
}
