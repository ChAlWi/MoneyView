using System;

namespace MoneyView.Data
{
    public class AccountEntry
    {
        public string AccountNumber { get; set; }
        public decimal Value { get; set; }
        public string Currency { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime BookingDate { get; set; }
        public string Recipient { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public AccountEntry(string accountNumber, decimal value, string currency, DateTime valueDate, DateTime bookingDate, string recipient, string category, string description)
        {
            AccountNumber = accountNumber;
            Value = value;
            Currency = currency;
            ValueDate = valueDate;
            BookingDate = bookingDate;
            Recipient = recipient;
            Category = category;
            Description = description;
        }
    }
}
