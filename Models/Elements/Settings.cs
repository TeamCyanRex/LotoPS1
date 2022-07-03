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
        //[string]Command [SettingProp]{-[string]CommandType, [string]CommandProp}+
        public class Setting
        {
            string Command;
            bool isSingleType;
            string? singleProp;
            List<SettingProp> settingProps;
            public Setting(string command, bool isSingle)
            {
                Command = command;
                if (isSingle) isSingleType = true;
                else
                {
                    isSingleType = false; settingProps = new();
                }
            }
            public void SetSingleProp(string prop)
            {
                singleProp = prop;
            }
            public void SettingPropAdd(SettingProp settingProp) { settingProps.Add(settingProp); }
            string ToStringSettingProps()
            {
                StringBuilder sb = new StringBuilder();
                if (!isSingleType)
                    foreach (var prop in settingProps) sb.Append(prop.ToString());
                else sb.Append(singleProp);
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
        public List<Setting> Commands = new();
        public void SettingAdd(Setting setting)
        {
            Commands.Add(setting);
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(Identity);
            foreach(var item in Commands)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
