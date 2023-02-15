using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog.Sys___Workshop_1_v2.Model;


namespace Prog.Sys___Workshop_1_v2.ViewModel
{
    class UpperModelView : INotifyPropertyChanged
    {
        DataContainer dataContainer = new DataContainer();

        private string _displayText;
        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                OnPropertyChanged("DisplayText");
            }
        }

        public UpperModelView()
        {
            _displayText = dataContainer.init;
        }

        public string messageServer()
        {
            return dataContainer.info; ;
        }

        public string flexSomeUppercase(string str)
        {
            if (str.Length > 8)
            {
                str = dataContainer.error;
            }
            else
            {
                str = str.ToUpper();
            }
            return str;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
