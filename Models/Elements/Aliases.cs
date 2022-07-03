using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoPS1.Models.Elements
{
    internal class Aliases
    {
        internal class Alias 
        {
            // New-Alias py3 D:\Zeta_tools\py\python.exe
            // Command - Target - Source
            public readonly string Command = "New-Alias";
            public string Target;
            public string Source;
            public Alias(string _target, string _source)
            {
                Target = _target;
                Source = _source;
            }
            public override string ToString()
            {
                return $"{Command} {Target} {Source} ";
            }
        }
        public readonly string Identity = "#aliases";
        public List<Alias> Commands = new();
        public Dictionary<string, bool> CommandsTargetName = new();
        public void AddAliase(Alias aliase)
        {
            if (!CommandsTargetName.ContainsKey(aliase.Target))
            {
                Commands.Add(aliase);
                CommandsTargetName.Add(aliase.Target, true);
            }
            //TODO: Target 命名冲突
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
