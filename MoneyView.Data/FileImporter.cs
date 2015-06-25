using System.Collections.Generic;
using System.Linq;

namespace MoneyView.Data
{
    public class FileImporter
    {
        private readonly ILoadRawData _rawData;
        private readonly ISaveData _dataSaver;
        private readonly IConvertRawData _rawDataConverter;
        private readonly IEqualityComparer<AccountEntry> _equalityComparer;
        private readonly IValidateAccountEntry _validateAccountEntry;

        public FileImporter(
            ILoadRawData rawData, 
            ISaveData dataSaver, 
            IConvertRawData rawDataConverter, 
            IEqualityComparer<AccountEntry> equalityComparer, 
            IValidateAccountEntry validateAccountEntry )
        {
            _rawData = rawData;
            _dataSaver = dataSaver;
            _rawDataConverter = rawDataConverter;
            _equalityComparer = equalityComparer;
            _validateAccountEntry = validateAccountEntry;
        }

        public void StartImport()
        {
            _rawData.Load()
                .Select(_rawDataConverter.Convert)
                .Distinct(_equalityComparer)
                .Where(_validateAccountEntry.IsValid)
                .ToList()
                .ForEach(_dataSaver.Save);
        }
    }
}
