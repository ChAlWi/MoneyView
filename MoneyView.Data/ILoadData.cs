using System.Collections.Generic;

namespace MoneyView.Data
{
    public interface ILoadData
    {
        IEnumerable<AccountEntry> LoadEntries();
    }
}