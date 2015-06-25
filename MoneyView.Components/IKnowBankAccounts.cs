using MoneyView.Model;

namespace MoneyView.Components
{
    public interface IKnowBankAccounts
    {
        BankAccount Find(string accountNumber);
    }
}
