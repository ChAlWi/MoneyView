namespace MoneyView.Data
{
    public interface IValidateAccountEntry
    {
        bool IsValid(AccountEntry entry);
    }
}