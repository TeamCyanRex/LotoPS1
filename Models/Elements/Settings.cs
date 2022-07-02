using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoPS1.Models.Elements
{
    internal class Settings
    {
        //Import-Module posh-git
        //Import-Module oh-my-posh
        //Set-PoshPrompt -Theme Avit
        //[string]Command [SettingProp]{-[string]CommandType, [string]CommandProp}*
        public class Setting
        {
            string Command;
            List<SettingProp> settingProps;
            public Setting(string command)
            {
                Command = command;
            }
            public void SettingPropAdd(SettingProp settingProp) { settingProps.Add(settingProp); }
            string ToStringSettingProps()
            {
                StringBuilder sb = new StringBuilder();
                foreach (var prop in settingProps) sb.Append(prop.ToString());
                return sb.ToString();
            }
            public override string ToString()
            {
                return $" {Command} {ToStringSettingProps()} ";
            }
        }
        public class SettingProp
        {
            string CommandType;
            string CommandProp;
            public SettingProp(string commandType, string commandProp)
            {
                CommandType = commandType;
                CommandProp = commandProp;
            }
            public override string ToString()
            {
                return $" -{CommandType} {CommandProp} ";
            }
        }
        public readonly string Identity = "#settings";
        public List<Setting> Commands;
        public void SettingAdd(Setting setting)
        {
            Commands.Add(setting);
        }
    }
}
