using System;
using System.Collections.Generic;

namespace MoneyView.Model
{
    public class ContactComparer : IEqualityComparer<Contact>
    {
        public bool Equals(Contact x, Contact y)
        {
            if (!x.FirstName.Equals(y.FirstName))
                return false;
            if (!x.LastName.Equals(y.LastName))
                return false;
            
            return true;
        }

        public int GetHashCode(Contact obj)
        {
            throw new NotImplementedException();
        }
    }
}