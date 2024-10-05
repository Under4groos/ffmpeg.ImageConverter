using ffmpeg.ImageConverter.Helper;

namespace ffmpeg.ImageConverter.Provides
{
    public static class PathEnvironment
    {
        public static string GetEnvironmentVariableFind(string variable)
        {
            try
            {
                return Interop.GetEnvironmentVariableList("Path").Where(str => Path.GetFileName(str) == variable).First();
            }
            catch (Exception)
            {

                return string.Empty;
            }

        }
    }
}
