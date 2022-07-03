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
        string modulesPshPattern = "";
        // primCode 整个psh文件内容
        public ElementsParser(string primCode)
        {
            HandleAliases(primCode);
            HandleWelcome(primCode);
            HandleSettings(primCode);
            //HandleModules(primCode);
        }
        void HandleWelcome(string code)
        {
            var tmp = Regex.Matches(code, welcomePshPattern);
            StringBuilder sb = new StringBuilder();
            foreach (Match match in tmp)
            {
                sb.AppendLine(match.Groups[1].ToString());
            }
            WelcomeParser(sb.ToString());
        }
        void HandleSettings(string code)
        {

            var tmp = Regex.Matches(code, settingsPshPattern);
            StringBuilder sb = new StringBuilder();
            foreach (Match match in tmp)
            {
                sb.AppendLine(match.Groups[1].ToString());
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
            if (res == null) return;
            foreach (Match match in res)
            {
                var tmp = match.Groups;
                string target = tmp[2].ToString();
                string source = tmp[3].ToString();
                model.aliasesModel.AddAliase(new Aliases.Alias(target, source));
            }
        }
        void SettingsParser(string psg)
        {
            var tmp = Regex.Matches(psg, @"(.+)\r\n");
            foreach (var item in tmp)
            {
                var t = item.ToString();
                ParseSettings(t);
            }
        }
        // Single Line
        void ParseSettings(string code)
        {
            var captureCommand = Regex.Matches(code, @"^([\w\-]+)");
            string command = captureCommand.ElementAt(0).Value;
            var captureRes = Regex.Matches(code, @"(?:[\w\-]+)\s(.+)\r");
            var props = captureRes.ElementAt(0).Groups[1].ToString();
            if (JudegeSingleCommand(props))
            {
                Settings.Setting setting = new(command, true);
                string prop = props;
                setting.SetSingleProp(prop);
                model.settingsModel.SettingAdd(setting);
            }
            else
            {
                Settings.Setting setting = new(command, false);
                var divProps = Regex.Matches(props, @"-([\w\-]+)\s+([\w]+)");
                foreach(Match match in divProps)
                {
                    var item = match.Groups;
                    Settings.SettingProp settingProp = new(item[1].Value, item[2].Value);
                    setting.SettingPropAdd(settingProp);
                }
                model.settingsModel.SettingAdd(setting);
            }
        }
        bool JudegeSingleCommand(string cmd)
        {
            var captureWords = Regex.Matches(cmd, @"([\w\-]+)");
            return captureWords.Count == 1;
        }
    }
}
