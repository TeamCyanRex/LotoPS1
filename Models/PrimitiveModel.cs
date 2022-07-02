using LotoPS1.Models.Elements;
namespace LotoPS1.Models
{
    //  代码模型的数据
    internal class PrimitiveModel
    {
        public Aliases aliasesModel { get; set; } = new();
        public Modules modulesModel { get; set; } = new();
        public Settings settingsModel { get; set; } = new();
        public Welcome welcomeModel { get; set; } = new();
    }
}
