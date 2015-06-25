namespace MoneyView.Data
{
    public interface IConstantProvider
    {
        T FindConstant<T>(string name, string[] arguments);
        T FindConstant<T>(string name);
        T FindConstant<T>(string name, T defaultValue);
        T FindConstant<T>(string name, T defaultValue, string[] arguments);
    }
}