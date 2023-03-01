using MAUI_Template.View;

namespace MAUI_Template;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("MaterialIcons-Regular.ttf", "IconFontTypes");
			});

        #region DEPENDENCY_INJECTION_REGISTRATION
        /*
         * En el registro se puede usar:
         * 'AddSingleton' : Para que cada que se instancie, siempre retorne la misma.
         * 'AddTransient' : Se creará una diferente cada vez que se instancie (Ejemplo: Una página que muestra los detalles de un producto que viene de una página con una lista de productos, cada una de esas páginas será diferente para cada producto).
         */

        // MainPage
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainViewModel>();
        #endregion

        return builder.Build();
	}
}
