using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LotoPS1.ViewModels
{
    internal class FileControlFooterVM:INotifyPropertyChanged
    {
        #region Structor
        #region Con
        #endregion
        #region De
        #endregion
        #endregion


        #region Data
        private FileInfo _profileFile;
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    OnPropertyChanged();

                }
            }
        }
        private bool IsChecked = false;
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
