namespace LotoPS1.Models.Elements
{
    internal class Modules
    {
        /*
            function lsmod
            {
                Param(
                    [string] $chosen
                )
                $chosen = "ls-" + $chosen
                &$chosen
            }
        */
        internal class Params
        {
            public readonly string Identity = "Params";
            public List<Tuple<string, string>> TypeNamePairs;
        }
        internal class Function
        {
            public readonly string Identity = "function";
            public string Name;
            public Params Params;
            public List<string> Lines;
            public string Description;
        }
        internal class Module
        {
            public string Name { get; set; }
            public List<Function> Functions;

        }
        internal class AboutAll
        {

        }
        public readonly string Identity = "#modules";
        public List<Module> LaModules;
    }
}
