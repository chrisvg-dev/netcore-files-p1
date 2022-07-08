using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore2.Services.Interfaces
{
    public interface IFileService
    {
        bool CreateFile(string fileName);
        void WriteIntoFile(string file, string message);
        void AppendIntoFile(string file, string message);
        List<string> ReadExcelFileContent(string file);
        bool FromExcelToTextFile(string fileName, List<string> content);
    }
}
