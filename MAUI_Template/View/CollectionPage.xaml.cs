namespace MAUI_Template.View;

public partial class CollectionPage : ContentPage
{
	public CollectionPage(CollectionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}