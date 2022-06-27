namespace LotoPS1;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}
    public async Task PickFileFiled(string message)
    {
        await DisplayAlert("Something wrong....", message, "Ok");
    }
}

