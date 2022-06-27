using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoPS1.Models.Elements
{
    internal class Aliases
    {
        internal class Alias {
            public readonly string Command = "New-Alias";
            public string Target;
            public string Source;
        }
        public readonly string Identity = "#aliases";
        public List<Alias> Commands;
    }
}
