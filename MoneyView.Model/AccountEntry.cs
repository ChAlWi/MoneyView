using System;
using NMoneys;

namespace MoneyView.Model
{
    public class AccountEntry
    {
        public BankAccount Account { get; private set; }
        public Money Value { get; private set; }
        public DateTime ValueDate { get; private set; }
        public DateTime BookingDate { get; private set; }
        public Contact Recipient { get; private set; }
        public Category Category { get; private set; }
        public string Description { get; private set; }

        public AccountEntry(BankAccount account, Money value, DateTime valueDate, DateTime bookingDate, Contact recipient, Category category, string description)
        {
            Account = account;
            Value = value;
            ValueDate = valueDate;
            BookingDate = bookingDate;
            Recipient = recipient;
            Category = category;
            Description = description;
        }
    }
}
