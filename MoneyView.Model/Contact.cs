namespace MoneyView.Model
{
    public class Contact
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Contact(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
