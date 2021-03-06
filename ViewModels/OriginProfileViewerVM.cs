using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LotoPS1.ViewModels
{
    internal class OriginProfileViewerVM:INotifyPropertyChanged
    {
        #region Structor
        #region Con
        #endregion
        #region De
        #endregion
        #endregion


        #region Data
        private StringBuilder originProfileBuffer => originProfileBuffer ?? new StringBuilder();
        public string OriginProfileBuffer
        {
            get { return originProfileBuffer.ToString(); }
            set
            {
                originProfileBuffer.Clear();
                originProfileBuffer.Append(value);
            }
        }
        private StringBuilder formatedCode = new StringBuilder();
        public string FormatedCode
        {
            get { return formatedCode.ToString(); }
            set
            {
                formatedCode.Clear();
                formatedCode.Append(value);
            }
        }
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
