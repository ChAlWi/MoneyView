using System;
using System.Collections.Generic;

namespace MoneyView.Model
{
    public class AccountEntryComparer : IEqualityComparer<AccountEntry>
    {
        public bool Equals(AccountEntry x, AccountEntry y)
        {
            if (!new AccountComparer().Equals(x.Account, y.Account))
                return false;

            if (!new ContactComparer().Equals(x.Recipient, y.Recipient))
                return false;

            if (!x.BookingDate.Equals(y.BookingDate))
                return false;
            if (!x.Category.Id.Equals(y.Category.Id))
                return false;
            if (!x.Description.Equals(y.Description))
                return false;
            if (!x.Value.Equals(y.Value))
                return false;
            if (!x.ValueDate.Equals(y.ValueDate))
                return false;

            return true;
        }

        public int GetHashCode(AccountEntry obj)
        {
            throw new NotImplementedException();
        }
    }
}
