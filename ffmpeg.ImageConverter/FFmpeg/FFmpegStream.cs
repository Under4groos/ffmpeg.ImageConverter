using ffmpeg.ImageConverter.FFmpeg.Actions;
using ffmpeg.ImageConverter.Provides;
using System.Diagnostics;

namespace ffmpeg.ImageConverter.FFmpeg
{
    public class FFmpegStream : IDisposable
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
        public bool Resize(string path, string out_path, SResize imgSize)
        {
            if (File.Exists(out_path))
                File.Delete(out_path);
            if (!__valid(__path_ffmpeg))
                return false;

            /// ffmpeg -i input.jpg -vf scale=320:240 output_320x240.png

            string command = $"-i \"{path}\" -vf scale={imgSize.Width}:{imgSize.Height} \"{out_path}\"";
            return _RunFFmpeg(command);

        }
        private bool __valid(string path_exe)
        {
            return !string.IsNullOrEmpty(path_exe) && File.Exists(path_exe);
        }

        private bool _RunFFmpeg(string command)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo(__path_ffmpeg, command);
            Process proc = new Process();
            proc.StartInfo = procStartInfo;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            proc.OutputDataReceived += (o, e) =>
            {

            };

            try
            {
                proc.Start();
                proc.BeginOutputReadLine();
                proc.WaitForExit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }




        }

        public void Dispose()
        {

        }
    }
}
