using MoneyView.Model;
using NMoneys;

namespace MoneyView.Components
{
    public class AccountEntryConverter : IConvertAccountEntries
    {
        private readonly IKnowBankAccounts _bankAccounts;

        public AccountEntryConverter(IKnowBankAccounts bankAccounts)
        {
            _bankAccounts = bankAccounts;
        }

        public AccountEntry Convert(Data.AccountEntry entry)
        {
            if (entry == null) return null;

            var bankAccount = _bankAccounts.Find(entry.AccountNumber);
            var receipient = new Contact(entry.Recipient, "");
            var category = new Category(entry.Category);
            return new AccountEntry(bankAccount, new Money(entry.Value, entry.Currency), entry.ValueDate,
                entry.BookingDate, receipient, category, entry.Description);

        }
    }
}
