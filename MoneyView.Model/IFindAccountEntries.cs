namespace MoneyView.Model
{
    public interface IFindAccountEntries
    {
        AccountEntry Find(string id);
        AccountEntry[] All();
        AccountEntry[] Find(AccountEntryFilter filter);
    }
}
