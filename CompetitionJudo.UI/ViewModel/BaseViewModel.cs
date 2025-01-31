using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CompetitionJudo.UI.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            try
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler == null)
                {
                    return;
                }

                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
            catch (Exception)
            {
                MessageBox.Show("La dernière opération n'a pas été prise en compte.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        #endregion
    }
}
