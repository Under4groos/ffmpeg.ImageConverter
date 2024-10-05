using ffmpeg.ImageConverter.Provides;

namespace ffmpeg.ImageConverter.FFmpeg
{
    public class FFmpegStream
    {
        private string __path_ffmpeg = string.Empty;
        public FFmpegStream(string path_exe)
        {
            if (__valid(path_exe))
            {
                __path_ffmpeg = path_exe;
            }
        }
        public FFmpegStream()
        {
            string ffmpeg = PathEnvironment.GetEnvironmentVariableFind("ffmpeg");
            ffmpeg = Path.Combine(ffmpeg, "ffmpeg.exe");
            if (__valid(ffmpeg))
            {
                __path_ffmpeg = ffmpeg;


            }
        }
        private bool __valid(string path_exe)
        {
            return string.IsNullOrEmpty(path_exe) && File.Exists(path_exe);
        }
    }
}
