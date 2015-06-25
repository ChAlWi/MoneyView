namespace MoneyView.Data
{
    public interface IConvertRawData
    {
        AccountEntry Convert(string data);
    }
}