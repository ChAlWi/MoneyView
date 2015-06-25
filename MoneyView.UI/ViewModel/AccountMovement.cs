using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using MoneyView.UI.Annotations;

namespace MoneyView.UI.ViewModel
{
    public class AccountMovement : INotifyPropertyChanged
    {
        private string _accountNumber;
        private decimal _value;
        private string _currency;
        private DateTime _valueDate;
        private DateTime _bookingDate;
        private string _recipient;
        private string _category;
        private string _description;


        public BitmapImage CategoryImage
        {
            get
            {
                return new BitmapImage(new Uri("/MoneyView.UI;component/Resources/book_add.png", UriKind.RelativeOrAbsolute)); 
            }
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                if (value == _accountNumber) return;
                _accountNumber = value;
                OnPropertyChanged();
            }
        }

        public decimal Value
        {
            get { return _value; }
            set
            {
                if (value == _value) return;
                _value = value;
                OnPropertyChanged();
            }
        }

        public string Currency
        {
            get { return _currency; }
            set
            {
                if (value == _currency) return;
                _currency = value;
                OnPropertyChanged();
            }
        }

        public DateTime ValueDate
        {
            get { return _valueDate; }
            set
            {
                if (value.Equals(_valueDate)) return;
                _valueDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime BookingDate
        {
            get { return _bookingDate; }
            set
            {
                if (value.Equals(_bookingDate)) return;
                _bookingDate = value;
                OnPropertyChanged();
            }
        }

        public string Recipient
        {
            get { return _recipient; }
            set
            {
                if (value == _recipient) return;
                _recipient = value;
                OnPropertyChanged();
            }
        }

        public string Category
        {
            get { return _category; }
            set
            {
                if (value == _category) return;
                _category = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged();
            }
        }

        public AccountMovement(string accountNumber, decimal value, string currency, DateTime valueDate, DateTime bookingDate, string recipient, string category, string description)
        {
            AccountNumber = accountNumber;
            Value = value;
            Currency = currency;
            ValueDate = valueDate;
            BookingDate = bookingDate;
            Recipient = recipient;
            Category = category;
            Description = description;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
