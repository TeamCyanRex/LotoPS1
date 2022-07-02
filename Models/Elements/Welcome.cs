using System.Text;

namespace LotoPS1.Models.Elements
{
    internal class Welcome
    {
        public readonly string Identity = "#readonly";
        public List<string> Commands = new();
        public void CommandAdd(string cmd)
        {
            Commands.Add(cmd);
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(Identity);
            foreach(var item in Commands)
            {
                sb.AppendLine(item);
            }
            return sb.ToString();
        }
    }
}
