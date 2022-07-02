
namespace LotoPS1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		// development
		Application.Current.UserAppTheme = AppTheme.Light;

		MainPage = new AppShell();
	}
}
