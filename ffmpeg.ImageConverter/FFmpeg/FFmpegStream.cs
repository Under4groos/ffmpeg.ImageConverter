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
            if (_valid(path_exe))
            {
                __path_ffmpeg = path_exe;
            }
        }
        public FFmpegStream()
        {
            string ffmpeg = PathEnvironment.GetEnvironmentVariableFind("ffmpeg");
            ffmpeg = Path.Combine(ffmpeg, "ffmpeg.exe");
            if (_valid(ffmpeg))
            {
                __path_ffmpeg = ffmpeg;


            }
        }
        /// ffmpeg -i input.jpg -vf scale=320:240 output_320x240.png
        public bool Resize(string path, string out_path, SResize imgSize)
        {

            if (!_valid(__path_ffmpeg))
                return false;
            _valid_remove(out_path);



            string command = $"-i \"{path}\" -vf scale={imgSize.Width}:{imgSize.Height} \"{out_path}\"";
            return _run_ffmpeg(command);

        }
        /// ffmpeg -i input.png -preset ultrafast output.jpg
        public bool FormatImage(string path, string out_path)
        {

            if (!_valid(__path_ffmpeg))
                return false;
            _valid_remove(out_path);

            string command = $"-i \"{path}\" -preset  ultrafast \"{out_path}\"";
            return _run_ffmpeg(command);

        }


        private void _valid_remove(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
        private bool _valid(string path_exe)
        {
            return !string.IsNullOrEmpty(path_exe) && File.Exists(path_exe);
        }
        /// <summary>
        /// Startup ffmpeg 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private bool _run_ffmpeg(string command)
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

            GC.SuppressFinalize(this);

        }
    }
}
