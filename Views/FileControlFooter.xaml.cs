using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace LotoPS1.Views;

public partial class FileControlFooter : ContentView
{
    #region Components Reference
    MainPage mainPage = null;
    #endregion
    public FileControlFooter(){
        InitializeComponent();
    }
    #region File control footer
    #region Datas
    
    #endregion
    #region View Methods 
    public void DefaultClicked(object sender, EventArgs args)
    {

    }
    public async void BrowserClicked(object sender, EventArgs args)
    {
        var customFileType = new FilePickerFileType(
            new Dictionary<DevicePlatform, IEnumerable<string>>
            {

                    { DevicePlatform.WinUI, new[] {  ".ps1" } },

            });

        PickOptions options = new()
        {
            PickerTitle = "Please select a Powershell file",
            FileTypes = customFileType,
        };
        await PickProfileFile(options);

    }
    public void OpenClicked(object sender, EventArgs args)
    {

    }
    public void CheckClicked(object sender, EventArgs args)
    {

    }
    public void SaveClicked(object sender, EventArgs args)
    {
    }
    public void SettingClicked(object sender, EventArgs args)
    {

    }

    #endregion
    #region Auxiliary Functions
    public async Task<FileResult> PickProfileFile(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("ps1", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();

                    //originProfileBuffer.Append(stream);
                    //nowProfileBuffer.Append(stream);
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            LoadMainPage();
            await mainPage.PickFileFiled(ex.Message);
        }

        return null;
    }
    private void LoadMainPage() {
        if (mainPage == null) {
            mainPage = (MainPage)(Parent.Parent.Parent);
        }
    }
    #endregion
    #endregion

    public void GetLabel(object sender, EventArgs args) {
        LoadMainPage();
       var brandName =(BrandName)mainPage.FindByName("brandName");
       var label=(Label)brandName.FindByName("label");
       string msg=label.Text;
       mainPage.DisplayAlert("Hi",msg,"Ok");

    }
   
}