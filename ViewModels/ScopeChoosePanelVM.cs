using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LotoPS1.ViewModels
{
    internal class ScopeChoosePanelVM:INotifyPropertyChanged
    {
        #region Structor
        #region Con
        #endregion
        #region De
        #endregion
        #endregion


        #region Data

        #endregion

        #region Methods 

        #endregion

        #region BindProperty

        #endregion


        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion
    }
}
