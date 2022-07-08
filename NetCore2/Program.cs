using NetCore2.Services;
using NetCore2.Services.Interfaces;

class Hello
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Making a new file");
        IFileService fileService = new FileService();
        string excelFileName = @"D:\PROYECTS\TEMP_FILES\files\users.xlsx";
        string textFileName = @"D:\PROYECTS\TEMP_FILES\files\users.txt";

        List<string> data = fileService.ReadExcelFileContent(excelFileName);
        bool result = fileService.FromExcelToTextFile(textFileName, data);

        Console.WriteLine(result ? "Archivo generado con éxito" : "Error al generar el archivo");
    }
}