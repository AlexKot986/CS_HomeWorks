foreach (var arg in args)
    Console.WriteLine(arg);

var currentDirectory = Directory.GetCurrentDirectory();

string extention = args[0];
string text = args[1];


string path = @"E:/GBrains";// Директория начала поиска


try
{
    GetSortFiles(new DirectoryInfo(path), extention, text);
}
catch (UnauthorizedAccessException e)
{
    Console.WriteLine("-------------Отказано в доступе!------------" + e.Message);
}

void GetSortFiles(DirectoryInfo directoryInfo, string fileExtention, string text)
{
    foreach (var directory in directoryInfo.GetDirectories())
    {
        GetSortFiles(directory, fileExtention, text);

        directory.GetFiles()
                 .ToList()
                 .FindAll(f => f.Extension.ToLower() == fileExtention)
                 .Where(f => GetFileConteinsText(f.FullName, text))
                 // Чтобы исключить текущий файл
                 //.Where(f => (f.FullName != new DirectoryInfo(Directory.GetCurrentDirectory() + "/../../../Program.cs").FullName) &&
                 //(f.FullName != new DirectoryInfo(@"E:\GBrains\CS\CS_Homeworks\H8_PathStreamsDir\Program.cs").FullName))
                 .ToList()
                 .ForEach(f => Console.WriteLine(f.FullName));
    }
}

bool GetFileConteinsText(string file, string text)
{
    using (var streamReader = new StreamReader(file))
    {
        while (!streamReader.EndOfStream)
        {
            if (streamReader.ReadLine().ToLower().Contains(text.ToLower()))
                return true;
        }
    }
    return false;
}