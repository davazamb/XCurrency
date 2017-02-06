using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XCurrency.Services;

namespace XCurrency.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private DialogService dialogService;
        private decimal pesos;
        private decimal dollars;
        private decimal bs;
        private decimal euros;
        #endregion
        #region Constructors

        public MainViewModel()
        {
            dialogService = new DialogService();
        }

        #endregion


        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties
        public decimal Pesos
        {
            set
            {
                if (pesos != value)
                {
                    pesos = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pesos"));
                }
            }
            get
            {
                return pesos;
            }
        }

        public decimal Dollars
        {
            set
            {
                if (dollars != value)
                {
                    dollars = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dollars"));
                }
            }
            get
            {
                return dollars;
            }
        }

        public decimal Bs
        {
            set
            {
                if (bs != value)
                {
                    bs = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bs"));
                }
            }
            get
            {
                return bs;
            }
        }

        public decimal Euros
        {
            set
            {
                if (euros != value)
                {
                    euros = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Euros"));
                }
            }
            get
            {
                return euros;
            }
        }

        #endregion

        #region Commands
        public ICommand ConvertCommand { get { return new RelayCommand(ConvertMoney); } }

        private async void ConvertMoney()
        {
            if (Pesos <= 0)
            {
                await dialogService.ShowMessage("Error", "You must enter a value greater than zero in pesos");
                return;
            }

            Dollars = Pesos / (Decimal)640.61499;
            Bs = Pesos * (Decimal)4.35;
            Euros = Pesos / (Decimal)690.935298;
        } 
        #endregion
    }
}
