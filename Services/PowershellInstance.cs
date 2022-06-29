using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
namespace LotoPS1.Services
{
    public class PowershellInstance
    {
        public static PowershellInstance Pwsh = null;
        public PowerShell PowerShell = null;
        private PowershellInstance() { 
            this.PowerShell = PowerShell.Create();
        }
        public static PowershellInstance GetPwshInstance() {
            if (Pwsh == null) { 
                Pwsh = new PowershellInstance();
            }
            return Pwsh;
        }
        public static string DefaultPowershellProfileString()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\WindowsPowerShell\\profile.ps1";
        }
    }
}
