# ffmpeg.ImageConverter

Для конвертации изображений, изменения размеров и тд... 

### Example 
```C#

using ffmpeg.ImageConverter.FFmpeg;
using ffmpeg.ImageConverter.FFmpeg.Actions;
using (FFmpegStream fmpeg_strm = new FFmpegStream())
{
    var size = new SResize()
    {
        Height = 250,
        Width = 2000
    };
    string path_ = @"C:\Users\UnderKo\Downloads\u2dmtzT7Tm8.jpg";
    string out_path_ = @$"out_jM4HawARwrY{size}.png";
    string out_path_format_jpeg = @$"out_jM4HawARwrY{size}.jpeg";

    if (fmpeg_strm.Resize(path_, out_path_, size))
    {
        Console.WriteLine(Path.GetFullPath(out_path_));


        if (fmpeg_strm.FormatImage(out_path_, out_path_format_jpeg))
        {
            Console.WriteLine(Path.GetFullPath(out_path_format_jpeg));
        }
    }


    Console.ReadKey();
}
```