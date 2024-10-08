// See https://aka.ms/new-console-template for more information
using ConsoleRead8Byte;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");




void reard(string path)
{
    List<Char16> ch_l = new List<Char16>();
    bool wr_ = false;
    using (FileStream fs = File.OpenRead(path))
    {
        byte[] buffer = new byte[10];
        fs.Read(buffer, 0, buffer.Length);


        string str_ = string.Join("", from ch in buffer select (char)ch);
        str_ = Regex.Match(str_, "[A-Z]+").Value;
        if (!string.IsNullOrEmpty(str_))
            Console.WriteLine(str_);
    }
}

foreach (var item in Directory.GetFiles(@"C:\Users\UnderKo\Downloads"))
{
    reard(item);
}