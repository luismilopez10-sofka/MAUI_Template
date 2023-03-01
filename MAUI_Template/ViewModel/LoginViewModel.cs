using MAUI_Template.Broker.User;
using MAUI_Template.Services;
using MAUI_Template.View;

namespace MAUI_Template.ViewModel;

public partial class LoginViewModel : BaseViewModel
{
    #region VARIABLES
    private ISQLiteRepository _sqliteRepository;
    private IBrkUser _brkUser;
    LoginService _loginService;
    #endregion

    #region PROPERTIES
    [ObservableProperty]
    private string username;
    [ObservableProperty]
    private string password;
    #endregion

    #region CONSTRUCTORS
    public LoginViewModel(LoginService loginService)
    {
        Title = "Login"; // Esta propiedad viene del BaseViewModel
        _sqliteRepository = new SQLiteRepository();
        _brkUser = new BrkUser();
        _loginService = loginService;
    }
    #endregion

    #region COMMANDS
    [RelayCommand]
    private async Task LoginAsync()
    {
        if (IsBusy)
            return;

        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            await Shell.Current.DisplayAlert("Empty Fields", "Please enter all the fields.", "OK");
            return;
        }

        try
        {
            IsBusy = true;

            MdlUser objMdlUser = new(Username, Password);
            string loginResult = await _brkUser.Login(objMdlUser);

            if (loginResult != BrkUser.responses[200].ToString())
            {
                await Shell.Current.DisplayAlert("Login Error", $"{loginResult}", "OK");
                return;
            }


            objMdlUser.Logged = true;
            await _sqliteRepository.Update(objMdlUser);

            //await Task.Delay(3000);
            Debug.WriteLine("Logged");
            //await Shell.Current.DisplayAlert("Success!", $"{loginResult}", "OK");

            await Shell.Current.GoToAsync(nameof(HomePage));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", $"Unable to login: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }


    [RelayCommand]
    private async Task CreateUserAsync()
    {
        if (IsBusy)
            return;

        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            await Shell.Current.DisplayAlert("Empty Fields", "Please enter all the fields.", "OK");
            return;
        }

        try
        {
            IsBusy = true;

            MdlUser objMdlUser = new(Username, Password);

            string creatingResult = await _brkUser.CreateUser(objMdlUser);
            await Shell.Current.DisplayAlert("Info", creatingResult, "OK");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", $"Unable to create: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    #endregion
}