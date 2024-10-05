using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace ffmpeg.ImageConverter.Helper
{
    public static class Interop
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetEnvironmentVariable(string lpName, string lpValue);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetEnvironmentVariable(string lpName, [Out] StringBuilder lpBuffer, int nSize);

        [System.Security.SecuritySafeCritical]
        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)]
        public static string GetEnvironmentVariable(string variable)
        {
            if (variable == null)
                throw new ArgumentNullException("variable");
            Contract.EndContractBlock();
            StringBuilder blob = new StringBuilder(128);
            int requiredSize = GetEnvironmentVariable(variable, blob, blob.Capacity);

            if (requiredSize == 0)
            {
                return null;
            }

            while (requiredSize > blob.Capacity)
            {
                blob.Capacity = requiredSize;
                blob.Length = 0;
                requiredSize = GetEnvironmentVariable(variable, blob, blob.Capacity);
            }
            return blob.ToString();
        }

        public static string[] GetEnvironmentVariableList(string variable)
        {
            return Interop.GetEnvironmentVariable(variable).Split(';');
        }
    }
}
