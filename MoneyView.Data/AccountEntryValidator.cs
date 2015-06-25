namespace MoneyView.Data
{
    public class AccountEntryValidator : IValidateAccountEntry
    {
        public bool IsValid(AccountEntry entry)
        {
            return true;
        }
    }
}
