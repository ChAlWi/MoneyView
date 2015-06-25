using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.TeamFoundation.MVVM;
using MoneyView.Model;
using MoneyView.UI.ViewModel;

namespace MoneyView.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : UserControl, IHaveOverviewOfAccountMovement
    {
        private readonly IFindAccountEntries _findAccountEntries;

        public MainWindowView(IFindAccountEntries findAccountEntries )
        {
            
            InitializeComponent();

            _findAccountEntries = findAccountEntries;
            ImportData = new RelayCommand(Import);
            LoadData = new RelayCommand(ShowData);
            
            Import();
            ShowData();
        }

        private void ShowData()
        {
            listView.ItemsSource = LoadAccountMovements();
        }

        private void Import()
        {
            //var importer = new FileImporter(_rawData,_saveData,_convertRawData, _comparer, _validateAccountEntry);
            //importer.StartImport();
        }



        public ICommand ImportData { get; set; }
        public ICommand LoadData { get; set; }

        private IEnumerable<AccountMovement> LoadAccountMovements()
        {
            return _findAccountEntries.All().Select(
                x =>
                    new AccountMovement(
                        x.Account.AccountNumber,
                        x.Value.Amount,
                        x.Value.CurrencyCode.ToString(),
                        x.ValueDate,
                        x.BookingDate,
                        x.Recipient.FirstName + " " + x.Recipient.LastName,
                        x.Category.Id,
                        x.Description));
        }

    }
}
