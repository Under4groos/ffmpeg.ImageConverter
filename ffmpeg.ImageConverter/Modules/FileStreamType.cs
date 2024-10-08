using System.Text.RegularExpressions;

namespace ffmpeg.ImageConverter.Modules
{
    public static class FileStreamType
    {
        public static string GetFileType(string path)
        {
            if (!File.Exists(path))
                return string.Empty;
            try
            {
                using (FileStream fs = File.OpenRead(path))
                {
                    byte[] buffer = new byte[10];
                    fs.Read(buffer, 0, buffer.Length);


                    string str_ = string.Join("", from ch in buffer select (char)ch);
                    str_ = Regex.Match(str_, "[A-Z]+").Value;

                    return string.IsNullOrEmpty(str_) ? string.Empty : str_;
                }
            }
            catch (Exception)
            {

                return string.Empty;
            }

        }
    }
}
