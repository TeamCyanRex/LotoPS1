using LotoPS1.Models;
using LotoPS1.ViewModels;

namespace LotoPS1.Views;

public partial class OriginProfileViewer : ContentView
{
	public OriginProfileViewer()
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
 BindableProperty.Create("PrimitiveBuffer", typeof(string), typeof(OriginProfileViewerVM), "");
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
        ElementsParser = new ElementsParser(primitiveCode);
        ProfileSupervisor = new ProfileSupervisor(ElementsParser.model);
        return ProfileSupervisor.ToFormattedCode();

    }
    #endregion
}