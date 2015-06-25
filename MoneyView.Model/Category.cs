namespace MoneyView.Model
{
    public class Category
    {
        public string Id { get; private set; }

        public Category(string id)
        {
            Id = id;
        }
    }
}
