string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
char s = Path.DirectorySeparatorChar;

string folderName = "PoC";
string directoryPath = $"{rootPath}{s}{folderName}";

if(!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}


string timestamp = DateTime.UtcNow.ToString("dd_MM_yyThh_mm_ss");
string fileName = $"{timestamp}.txt";


string fullFilePath = $"{directoryPath}{s}{fileName}";
Console.WriteLine($"Hello, Pristine World! From {Environment.OSVersion}, writing into: {fullFilePath}");

using (StreamWriter writer = new StreamWriter(fullFilePath))
{
    writer.WriteLine($"Hello File, written at: {timestamp}");
}

