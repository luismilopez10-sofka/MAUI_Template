using MAUI_Template.Helpers;
using MAUI_Template.View;

namespace MAUI_Template.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    #region VARIABLES
    #endregion

    #region PROPERTIES
    [ObservableProperty]
    private List<ListTile> screens = new List<ListTile>{
        new ListTile(IconFont.List, "CollectionView"),
        new ListTile(IconFont.Add_alert, "Alerts"),
        new ListTile(IconFont.Credit_card, "Cards"),
        new ListTile(IconFont.Supervised_user_circle, "Circle Avatar"),
        new ListTile(IconFont.Input, "Text Inputs"),
        new ListTile(IconFont.Slow_motion_video, "Sliders and Checks"),
        new ListTile(IconFont.Build_circle, "Infinite Scroll and Pull Refresh"),
        new ListTile(IconFont.Volume_up, "Volumen"),
        new ListTile(IconFont.Camera, "Camera"),
        new ListTile(IconFont.Gps_fixed, "GPS"),
        new ListTile(IconFont.Bluetooth, "Bluetooth"),
        new ListTile(IconFont.Photo_album, "Gallery"),
    };
    #endregion

    #region CONSTRUCTORS
    public HomeViewModel()
    {
        Title = "Home";
    }
    #endregion

    #region COMMANDS
    [RelayCommand]
    async Task GoToAsync(string screenName)
    {
        switch (screenName)
        {
            case "CollectionView":
                await Shell.Current.GoToAsync($"{nameof(CollectionPage)}");
                break;
            case "Alerts":
                await Shell.Current.GoToAsync($"{nameof(CollectionPage)}");
                break;
            case "Cards":
                await Shell.Current.GoToAsync($"{nameof(CollectionPage)}");
                break;
            case "Circle Avatar":
                await Shell.Current.GoToAsync($"{nameof(CollectionPage)}");
                break;
            case "Text Inputs":
                await Shell.Current.GoToAsync($"{nameof(CollectionPage)}");
                break;
            case "Sliders and Checks":
                await Shell.Current.GoToAsync($"{nameof(CollectionPage)}");
                break;
            case "Infinite Scroll and Pull Refresh":
                await Shell.Current.GoToAsync($"{nameof(CollectionPage)}");
                break;
        }
    }
    #endregion
}

public class ListTile
{
    public string Icon { get; set; }
    public string Title { get; set; }

    public ListTile()
    {
    }

    public ListTile(string icon, string title)
    {
        Icon = icon;
        Title = title;
    }
}