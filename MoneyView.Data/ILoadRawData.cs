using System.Collections.Generic;

namespace MoneyView.Data
{
    public interface ILoadRawData
    {
        IEnumerable<string> Load();
    }
}