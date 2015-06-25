using System;
using System.Collections.Generic;

namespace MoneyView.Model
{
    public class AccountComparer : IEqualityComparer<BankAccount>
    {
        public bool Equals(BankAccount x, BankAccount y)
        {
            if (!x.AccountNumber.Equals(y.AccountNumber))
                return false;
            if (!x.BankName.Equals(y.BankName))
                return false;
            if (!x.BankNumber.Equals(y.BankNumber))
                return false;
            if (!x.Bic.Equals(y.BankNumber))
                return false;
            if (!x.Iban.Equals(y.Iban))
                return false;

            if (!new ContactComparer().Equals(x.Owner, y.Owner))
                return false;

            return true;

        }

        public int GetHashCode(BankAccount obj)
        {
            throw new NotImplementedException();
        }
    }
}