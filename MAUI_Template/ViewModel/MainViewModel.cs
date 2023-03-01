namespace MAUI_Template.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    #region VARIABLES
    int count = 0;
    #endregion

    #region PROPERTIES
    [ObservableProperty]
    private string text = "Click me";
    #endregion

    #region CONSTRUCTORS
    public MainViewModel()
    {
        Title = "Hello! I'm MainPage"; // Esta propiedad viene del BaseViewModel al igual que "IsBusy" y "IsNotBusy"
    }
    #endregion

    #region COMMANDS
    [RelayCommand]
    private void OnCounterClicked()
    {
        count++;

        if (count == 1)
            Text = $"Clicked {count} time";
        else
            Text = $"Clicked {count} times";
    }
    #endregion
}
