using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MoneyView.Data
{
    public class JsonDataProvider : ISaveData, ILoadData
    {
        private const string FileName = "JsonDataProvider.json";
        private readonly IConstantProvider _constantProvider;

        public JsonDataProvider(IConstantProvider constantProvider)
        {
            _constantProvider = constantProvider;
        }

        public void Save(AccountEntry entry)
        {
            var entries = LoadEntries().ToList();
            entries.Add(entry);
            var path = _constantProvider.FindConstant<string>("JSON_DATA_PROVIDER_PATH");
            var file = Path.Combine(path, FileName);
            string json = JsonConvert.SerializeObject(entries);
            File.WriteAllText(file, json, Encoding.Default);
        }

        public IEnumerable<AccountEntry> LoadEntries()
        {
            var path = _constantProvider.FindConstant<string>("JSON_DATA_PROVIDER_PATH");
            var file = Path.Combine(path, FileName);
            if (!File.Exists(file)) return Enumerable.Empty<AccountEntry>();
            return JsonConvert.DeserializeObject<IEnumerable<AccountEntry>>(File.ReadAllText(file, Encoding.Default));
        }
    }
}
