
namespace MoneyView.Data
{
    public class ConstantProvider :IConstantProvider
    {
        public T FindConstant<T>(string name, string[] arguments)
        {
            return default(T);
        }

        public T FindConstant<T>(string name)
        {
            return default(T);
        }

        public T FindConstant<T>(string name, T defaultValue)
        {
            return defaultValue;
        }

        public T FindConstant<T>(string name, T defaultValue, string[] arguments)
        {
            return defaultValue;
        }
    }
}
