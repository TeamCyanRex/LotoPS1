using System.ComponentModel;
using System.Runtime.CompilerServices;
using LotoPS1.Services;
using LotoPS1.ViewModels;
namespace LotoPS1.Views;

public partial class FileControlFooter : ContentView
{
    #region Components Reference
    MainPage mainPage = null;
    NowProfileViewer nowProfileViewer = null;
    OriginProfileViewer originProfileViewer = null;
    #endregion
    public FileControlFooter(){
        InitializeComponent();
    }
    #region File control footer
    #region Datas
    public FileInfo ProfileFileUrl=null;
    #endregion
    #region View Methods 
    public void DefaultClicked(object sender, EventArgs args)
    {
        SetProfileViewer(SetDefaultProfileFile());
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
        var file=await PickProfileFile(options);
        if (file == null) {
            return;
        }
        fileUrl.Text = file.FullPath;
        SetProfileViewer(new FileInfo(file.FullPath));

    }
    public async void OpenClicked(object sender, EventArgs args)
    {
        if (fileUrl.Text==null||fileUrl.Text=="") {
            return;
        }
        ProfileFileUrl =await CreateProfileFile(fileUrl.Text);
        fileUrl.Text = ProfileFileUrl!=null?ProfileFileUrl.ToString():"";
        if (fileUrl.Text != "") {
            SetProfileViewer(ProfileFileUrl);
        }
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
    private void SetProfileViewer(FileInfo profileFileUrl)
    {
        LoadNowProfileViewer();
        LoadOriginProfileViewer();
        var stream=profileFileUrl.OpenText().ReadToEnd();
        fileUrl.Text=profileFileUrl.FullName;
        /*
         Editor now=(Editor)nowProfileViewer.FindByName("editor");
        Editor origin = (Editor)originProfileViewer.FindByName("editor");
        now.Text = stream;
        origin.Text = stream;
        */
        originProfileViewer.PrimitiveBuffer = stream;
        nowProfileViewer.PrimitiveBuffer = stream;

    }
    private static FileInfo SetDefaultProfileFile() {
        string path=PowershellInstance.DefaultPowershellProfileString();
        if (!File.Exists(path)) {
            File.Create(path);
        }
        return new FileInfo(path);
    }
    public async Task<FileResult> PickProfileFile(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
               return result;
            }
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
    private bool IsSuffixPS1(string path) {
        var suffix=Path.GetExtension(path);
        if (suffix == null)
        {
            return false;
        }
        else {
            return suffix.ToLower() == ".ps1";
        }
    }
    private async Task<FileInfo> CreateProfileFile(string pathString) {
        try
        {
            LoadMainPage();
            if (!File.Exists(pathString))
            {
                if (!IsSuffixPS1(pathString)) {
                    if (await mainPage.DisplayAlert("This Path Url does not point to a Powershell file", "Do you want to Add a \".ps1\" suffix to path?(if No,this open will be cancel)", "Yes", "No"))
                    {
                        pathString += ".ps1";
                        return await CreateProfileFile(pathString);
                    }
                    else {
                        return null;
                    }
                }

                if (await mainPage.DisplayAlert("We can't find this File", "Can we create a new file named this?(if No,this open will be cancel)", "Yes", "No"))
                {
                    File.Create(pathString).Close();
                }
                else {
                    return null;
                }
               
            }
            var file = new FileInfo(pathString);
            return file;
        }
        catch (Exception ex)
        {
            bool res =await mainPage.DisplayAlert("Solve Path url failed!","Do you want to accept default(Recommend) profile path?","Yes","No");
            return res?SetDefaultProfileFile():null;
        }
    }
    private void LoadNowProfileViewer() {
        if (nowProfileViewer == null) {
            LoadMainPage();
            nowProfileViewer=(NowProfileViewer)mainPage.FindByName("now");
        }
        
    }
    private void LoadOriginProfileViewer() {
        if (originProfileViewer == null) { 
            LoadMainPage() ;
            originProfileViewer = (OriginProfileViewer)mainPage.FindByName("origin");
        }
    }
    #endregion
    #endregion

   
}