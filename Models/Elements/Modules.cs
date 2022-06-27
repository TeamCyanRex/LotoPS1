using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoPS1.Models.Elements
{
    internal class Modules
    {
        internal class Params {
            public readonly string Identity = "Params";
            public List<Tuple<string,string>> TypeNamePairs;
        }
        internal class Function {
            public readonly string Identity = "function";
            public string Name;
            public Params Params;
            public List<string> Lines;
            public string Description;
        }
        internal class Module { 
            public string Name { get; set; }
            public List<Function> Functions;

        }
        internal class AboutAll { 
            
        }
        public readonly string Identity = "#modules";
        public List<Module> LaModules;
    }
}
