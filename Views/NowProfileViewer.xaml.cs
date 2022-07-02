using LotoPS1.ViewModels;
using LotoPS1.Models;
namespace LotoPS1.Views;

public partial class NowProfileViewer : ContentView
{
    public NowProfileViewer()
    {
        InitializeComponent();
    }
    #region Components Reference
    MainPage mainPage = null;
    #endregion
    #region Datas
    private ElementsParser ElementsParser = null;
    private ProfileSupervisor ProfileSupervisor = null;
    public static readonly BindableProperty PrimitiveBufferProperty =
 BindableProperty.Create("PrimitiveBuffer", typeof(string), typeof(NowProfileViewerVM), "");
    public string PrimitiveBuffer
    {
        get => (string)GetValue(PrimitiveBufferProperty);
        set
        {
            SetValue(PrimitiveBufferProperty, value);

            editor.Text = CastPrimitiveToFormattedCode(value);
        }
    }
    #endregion
    #region View Methods 
    #endregion
    #region Auxiliary Functions
    string CastPrimitiveToFormattedCode(string primitiveCode)
    {
        if (ElementsParser == null)
            ElementsParser = new ElementsParser(primitiveCode);
        if (ProfileSupervisor == null)
            ProfileSupervisor = new ProfileSupervisor(ElementsParser.model);
        return ProfileSupervisor.ToFormattedCode();

    }
    #endregion
}