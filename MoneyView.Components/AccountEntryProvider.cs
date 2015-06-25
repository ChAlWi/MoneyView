using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyView.Data;
using MoneyView.Model;
using AccountEntry = MoneyView.Model.AccountEntry;

namespace MoneyView.Components
{
    public class AccountEntryProvider : IFindAccountEntries
    {
        private readonly ILoadData _loadDataEntries;
        private readonly IConvertAccountEntries _converter;

        public AccountEntryProvider(ILoadData loadDataEntries, IConvertAccountEntries converter)
        {
            _loadDataEntries = loadDataEntries;
            _converter = converter;
        }

        public AccountEntry Find(string id)
        {
            //TODO: Implement Id for AccountEntries
            return _converter.Convert(_loadDataEntries.LoadEntries().FirstOrDefault());
        }

        public AccountEntry[] All()
        {
            return _loadDataEntries.LoadEntries().Select(_converter.Convert).ToArray();
                
        }

        public AccountEntry[] Find(AccountEntryFilter filter)
        {
            throw new NotImplementedException();
        }
    }

    public interface IConvertAccountEntries
    {
        AccountEntry Convert(Data.AccountEntry entry);
    }
}
