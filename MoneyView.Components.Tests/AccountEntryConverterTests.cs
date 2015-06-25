using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyView.Model;
using NMoneys;
using NSubstitute;
using AccountEntry = MoneyView.Data.AccountEntry;

namespace MoneyView.Components.Tests
{
    [TestClass]
    public class AccountEntryConverterTests
    {


        private AccountEntryConverter CreateSut(IKnowBankAccounts bankAccounts = null)
        {
            return new AccountEntryConverter(
                bankAccounts ?? Substitute.For<IKnowBankAccounts>()
                );
        }


        [TestMethod]
        public void When_account_entry_converter_have_to_convert_null_it_returns_null()
        {
            var result = CreateSut().Convert(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void When_account_number_has_the_number_123456_then_the_bank_account_has_the_number_123456()
        {
            var bankAccounts = NSubstitute.Substitute.For<IKnowBankAccounts>();
            bankAccounts.Find("123456").Returns(new BankAccount("123456", "", "", "", "", null));
            var entryToConvert = new AccountEntry("123456",decimal.Zero,"EUR",DateTime.Now,DateTime.Now,"recipient","category","description");
            var result = CreateSut(bankAccounts).Convert(entryToConvert);
            Assert.AreEqual(result.Account.AccountNumber,"123456");
        }
        [TestMethod]
        public void When_amount_of_entry_was_2015_komma_12_then_the_value_of_entry_has_the_amount_of_2015_komma_12()
        {
            var entryToConvert = new AccountEntry("123456", decimal.Parse("2015,12"), "EUR", DateTime.Now, DateTime.Now, "recipient", "category", "description");
            var result = CreateSut().Convert(entryToConvert);
            Assert.AreEqual(result.Value.Amount, decimal.Parse("2015,12"));
        }

        [TestMethod]
        public void When_currency_of_entry_was_CHF_then_the_entry_has_the_currency_iso_code_CHF()
        {
            var entryToConvert = new AccountEntry("123456", decimal.Parse("2015,12"), "CHF", DateTime.Now, DateTime.Now, "recipient", "category", "description");
            var result = CreateSut().Convert(entryToConvert);
            Assert.AreEqual(result.Value.CurrencyCode, CurrencyIsoCode.CHF);
        }

        [TestMethod]
        public void The_value_date_should_be_the_same()
        {
            var valueDate = DateTime.Now.Date;
            var entryToConvert = new AccountEntry("123456", decimal.Parse("2015,12"), "CHF", valueDate, DateTime.Now, "recipient", "category", "description");
            var result = CreateSut().Convert(entryToConvert);
            Assert.AreEqual(result.ValueDate, valueDate);
        }

        [TestMethod]
        public void The_booking_date_should_be_the_same()
        {
            var bookingDate = DateTime.Now.Date;
            var entryToConvert = new AccountEntry("123456", decimal.Parse("2015,12"), "CHF", DateTime.Now, bookingDate, "recipient", "category", "description");
            var result = CreateSut().Convert(entryToConvert);
            Assert.AreEqual(result.BookingDate, bookingDate);
        }

        [TestMethod]
        public void When_recipient_of_entry_has_the_name_anton_the_result_should_have_a_contact_with_the_name_anton()
        {
            var entryToConvert = new AccountEntry("123456", decimal.Parse("2015,12"), "CHF", DateTime.Now, DateTime.Now, "anton", "category", "description");
            var result = CreateSut().Convert(entryToConvert);
            Assert.AreEqual(result.Recipient.FirstName, "anton");
        }

        [TestMethod]
        public void When_category_of_entry_was_ausgabe_then_the_result_has_a_category_with_id_ausgabe()
        {
            var entryToConvert = new AccountEntry("123456", decimal.Parse("2015,12"), "CHF", DateTime.Now, DateTime.Now, "recipient", "ausgabe", "description");
            var result = CreateSut().Convert(entryToConvert);
            Assert.AreEqual(result.Category.Id, "ausgabe");
        }

        [TestMethod]
        public void When_description_of_entry_was_hurzelgrumpf_then_the_result_has_a_description_hurzelgrumpf()
        {
            var entryToConvert = new AccountEntry("123456", decimal.Parse("2015,12"), "CHF", DateTime.Now, DateTime.Now, "recipient", "ausgabe", "hurzelgrumpf");
            var result = CreateSut().Convert(entryToConvert);
            Assert.AreEqual(result.Description, "hurzelgrumpf");
        }
        [TestMethod]
        public void It_should_have_called_i_know_bank_accounts()
        {
            var bankAccount = NSubstitute.Substitute.For<IKnowBankAccounts>();
            var entryToConvert = new AccountEntry("123456", decimal.Parse("2015,12"), "CHF", DateTime.Now, DateTime.Now, "recipient", "ausgabe", "hurzelgrumpf");
            var result = CreateSut(bankAccount).Convert(entryToConvert);
            bankAccount.Received(1).Find("123456");
        }

    }
}
