using NetCore2.Services.Interfaces;
using SpreadsheetLight;
using System.Text;


namespace NetCore2.Services
{
    public class FileService : IFileService
    {
        public bool CreateFile(string fileName)
        {
            try
            {
                Console.WriteLine("Creating a new file");
                File.Create(fileName);

                if ( File.Exists(fileName) )
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void WriteIntoFile(string file, string message)
        {
            try
            {
                Console.WriteLine("Writing into the file");
                using (FileStream fs = File.Create(file))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(message);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Everything failed -> " + e.Message);
            }        
        }

        public void AppendIntoFile(string file, string message)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(file))
                {
                    sw.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Everything failed -> " + e.Message);
            }
        }

        public List<string> ReadExcelFileContent(string fileName)
        {
            SLDocument sl = new SLDocument(fileName);
            List<string> content = new();
            int iRow = 2;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                string codigo = sl.GetCellValueAsString(iRow, 1);
                string nombre = sl.GetCellValueAsString(iRow, 2);
                string apellidos = sl.GetCellValueAsString(iRow, 3);
                int edad = sl.GetCellValueAsInt32(iRow, 4);
                content.Add($"{codigo} \t\t {nombre} \t\t {apellidos} \t\t {edad}");
                iRow++;
            }
            return content;
        }

        public bool FromExcelToTextFile(string fileName, List<string> content)
        {
            try
            {
                this.WriteIntoFile(fileName, "From Excel to TXT");
                this.AppendIntoFile(fileName, "");

                string header = "CODIGO \t NOMBRE \t\t APELLIDOS \t\t EDAD";

                this.AppendIntoFile(fileName, header);
                foreach (string item in content)
                {
                    this.AppendIntoFile(fileName, item);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
