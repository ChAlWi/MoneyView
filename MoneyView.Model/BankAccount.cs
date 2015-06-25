namespace MoneyView.Model
{
    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        public string BankNumber { get; private set; }
        public string Iban { get; private set; }
        public string Bic { get; private set; }
        public string BankName { get; private set; }
        public Contact Owner { get; private set; }

        public BankAccount(string accountNumber, string bankNumber, string iban, string bic, string bankName, Contact owner)
        {
            AccountNumber = accountNumber;
            BankNumber = bankNumber;
            Iban = iban;
            Bic = bic;
            BankName = bankName;
            Owner = owner;
        }
    }
}
