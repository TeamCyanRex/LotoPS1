using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LotoPS1.Interface
{
    internal interface IElementCodeChanger
    {
        void FromCode(string code);
        string ToCode();
    }
}
