


using ffmpeg.ImageConverter.FFmpeg;
using (FFmpegStream fmpeg_strm = new FFmpegStream())
{
    //var size = new SResize()
    //{
    //    Height = 2000,
    //    Width = 2000
    //};
    //string path_ = @"C:\Users\UnderKo\Downloads\Demo.mp4";
    //string out_path_ = @$"out_jM4HawARwrY{size}.png";
    //string out_path_format_jpeg = @$"out_jM4HawARwrY{size}.jpeg";
    //if (fmpeg_strm.Resize(path_, out_path_, size))
    //{
    //    Console.WriteLine(Path.GetFullPath(out_path_));
    //    if (fmpeg_strm.FormatImage(out_path_, out_path_format_jpeg))
    //    {
    //        Console.WriteLine(Path.GetFullPath(out_path_format_jpeg));
    //    }
    //}


    string str_ = fmpeg_strm.GetMetadata(@"C:\Users\UnderKo\Downloads\chrome_MzRBSJtJ0R.png");

    //  Console.WriteLine(str_);


    Console.ReadKey();
}