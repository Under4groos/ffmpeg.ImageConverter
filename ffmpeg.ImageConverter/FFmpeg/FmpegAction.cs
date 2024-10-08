using ffmpeg.ImageConverter.FFmpeg.Actions;
using ffmpeg.ImageConverter.Interfaces;
namespace ffmpeg.ImageConverter.FFmpeg
{
    public class FmpegAction : IFFmpegAction
    {
        public string? Command
        {
            get; set;
        }
        public SResize? ImageSize
        {
            get; set;
        }

        public bool Run()
        {
            throw new NotImplementedException();
        }
    }
}
