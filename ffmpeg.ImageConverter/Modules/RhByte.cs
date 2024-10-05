namespace ffmpeg.ImageConverter.Modules
{
    public static class RhByte
    {
        public static Random R = new Random();


        public static string IntRandom(int max)
        {
            Byte[] bytes = new Byte[max];
            R.NextBytes(bytes);
            var hexArray = Array.ConvertAll(bytes, x => R.Next(0, 2) > 1 ? x.ToString("X2") : x.ToString("X2").ToLower());
            return String.Concat(hexArray);

        }
    }
}
