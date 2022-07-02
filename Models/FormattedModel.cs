using LotoPS1.Models.Elements;
namespace LotoPS1.Models
{
    // 格式化值得是跟踪模型需要的数据
    // 因为它要直接反映到editor
    // 所以它叫格式化

    internal class FormattedModel
    {
        public Aliases aliasesModel { get; set; } = new();
        public Modules modulesModel { get; set; } = new();
        public Settings settingsModel { get; set; } = new();
        public Welcome welcomeModel { get; set; } = new();
    }
}
