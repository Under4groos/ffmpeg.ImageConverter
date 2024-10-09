using ffmpeg.ImageConverter.FFmpeg.Actions;
using ffmpeg.ImageConverter.Provides;
using System.Diagnostics;

namespace ffmpeg.ImageConverter.FFmpeg
{
    public class FFmpegStream : IDisposable
    {
        public string PathFFmpeg
        {
            get; private set;
        }

        public FFmpegStream(string path_exe)
        {
            if (_valid(path_exe))
            {
                PathFFmpeg = path_exe;
            }
        }
        public FFmpegStream()
        {
            string ffmpeg = PathEnvironment.GetEnvironmentVariableFind("ffmpeg");
            ffmpeg = Path.Combine(ffmpeg, "ffmpeg.exe");
            if (_valid(ffmpeg))
            {
                PathFFmpeg = ffmpeg;


            }
            else
            {
                ffmpeg = Path.Combine("Bin", "ffmpeg.exe");
                if (_valid(ffmpeg))
                {
                    PathFFmpeg = ffmpeg;
                }
            }
        }
        /// ffmpeg -i input.jpg -vf scale=320:240 output_320x240.png
        public bool Resize(string path, string out_path, SResize imgSize)
        {

            if (!_valid(PathFFmpeg))
                return false;
            _valid_remove(out_path);



            string command = $"-i \"{path}\" -vf scale={imgSize.Width}:{imgSize.Height} \"{out_path}\"";
            return _run_ffmpeg(command);

        }
        /// ffmpeg -i input.png -preset ultrafast output.jpg
        public bool FormatImage(string path, string out_path, Action<string> dataReceivedEventHandler)
        {

            if (!_valid(PathFFmpeg))
                return false;
            _valid_remove(out_path);

            string command = $"-i \"{path}\" -preset  ultrafast \"{out_path}\"";
            return _run_ffmpeg(command, dataReceivedEventHandler);

        }

        public string GetMetadata(string path)
        {
            if (!_valid(PathFFmpeg) || !File.Exists(path))
                return string.Empty;
            string metadata = "";
            //_run_ffmpeg($"-i \"{path}\"", (o, e) =>
            //{
            //    metadata += e.Data;
            //});

            //foreach (var item in metadata.Split('\n'))
            //{
            //    Console.WriteLine(item);
            //}

            return metadata;

        }


        public void _valid_remove(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public bool ValidFFMPEG()
        {
            return _valid(PathFFmpeg);
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
        public bool _run_ffmpeg(string command, Action<string> dataReceivedEventHandler = null)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo(PathFFmpeg, command)
            {
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            Process proc = new Process();
            proc.StartInfo = procStartInfo;
            proc.OutputDataReceived += (o, e) => dataReceivedEventHandler?.Invoke(e.Data);

            try
            {
                proc.Start();
                proc.BeginOutputReadLine();

                proc.WaitForExit();


                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }




        }

        public void Dispose()
        {

            GC.SuppressFinalize(this);

        }
    }
}
