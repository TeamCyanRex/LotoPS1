using LotoPS1.Models.Elements;
using System.Text;
using System.Text.RegularExpressions;
namespace LotoPS1.Models
{
    // 负责代码模型的转化和外部方法
    // 用正则解析
    // 通过正则表达式把pwsh代码
    // 存在parser里面

    internal class ElementsParser
    {
        public PrimitiveModel model = new();
        string welcomePshPattern = @"#welcome\s*([\w[\""\!\'\s]*]*)";
        string aliasesPshPattern = @"#aliases\s*([\w\s\-\:\\\.]*)";
        string settingsPshPattern = @"#settings\s*([\w\-\s]+)";
        // primCode 整个psh文件内容
        public ElementsParser(string primCode)
        {
            HandleAliases(primCode);
            HandleWelcome(primCode);
            //HandleSettings(primCode);
            //HandleModules(primCode);
        }
        void HandleWelcome(string code)
        {
            var tmp = Regex.Matches(code, welcomePshPattern);
            StringBuilder sb = new StringBuilder();
            foreach (Match match in tmp)
            {
                sb.AppendLine(match.Value);
            }
            WelcomeParser(sb.ToString());
        }
        void HandleSettings(string code)
        {

            var tmp = Regex.Matches(code, settingsPshPattern);
            StringBuilder sb = new StringBuilder();
            foreach (Match match in tmp)
            {
                sb.AppendLine(match.Value);
            }
            SettingsParser(sb.ToString());
        }
        void HandleAliases(string code)
        {
            var tmp = Regex.Matches(code, aliasesPshPattern);
            StringBuilder sb = new StringBuilder();
            foreach (Match match in tmp)
            {
                var value = match.Groups;
                sb.AppendLine(value[1].ToString());
            }
            AliasesParser(sb.ToString());
        }
        void HandleModules(string code)
        {
            var tmp = Regex.Matches(code, welcomePshPattern);
            StringBuilder sb = new StringBuilder();
            foreach (Match match in tmp)
            {
                sb.AppendLine(match.Value);
            }
            WelcomeParser(sb.ToString());

        }
        void WelcomeParser(string primCode)
        {
            string welcomeModelPattern = @"([\w]+)\s*\""([\w\s\!\']*)\""";
            foreach (Match match in Regex.Matches(primCode, welcomeModelPattern))
            {
                var tmp = match.Value;
                model.welcomeModel.CommandAdd(tmp);
            }
        }
        void AliasesParser(string primCode)
        {
            // 只匹配到一组数据
            /*
            #aliases

            New-Alias py3 D:\Zeta_tools\py\python.exe
            New-Alias imdbg D:\Zeta_Tools\ImmunityDebugger\ImmunityDebugger.exe
             */
            string aliasesModelPattern = @"([\w\-]+)\s+([\w\-]+)\s+([\w\:\\\.]+)";
            var res = Regex.Matches(primCode, aliasesModelPattern);
            if(res == null) return;
            foreach (Match match in res)
            {
                var tmp = match.Groups;
                string target = tmp[2].ToString();
                string source = tmp[3].ToString();
                model.aliasesModel.AddAliase(new Aliases.Alias(target, source));
            }
        }
        void SettingsParser(string primCode)
        {

        }
    }
}
