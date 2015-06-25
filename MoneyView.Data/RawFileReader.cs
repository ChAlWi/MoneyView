using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MoneyView.Data
{
    public class RawFileReader : ILoadRawData
    {
        private readonly IConstantProvider _constantProvider;

        public RawFileReader(IConstantProvider constantProvider)
        {
            _constantProvider = constantProvider;
        }

        public IEnumerable<string> Load()
        {
            var folder = _constantProvider.FindConstant<string>("IMPORT_FOLDER");
            if (!Directory.Exists(folder)) return Enumerable.Empty<string>();
            var listToReturn = new List<string>();
            foreach (var file in Directory.GetFiles(folder))
                listToReturn.AddRange(File.ReadLines(file, Encoding.Default).Skip(1));

            return listToReturn;
        }
    }
}
