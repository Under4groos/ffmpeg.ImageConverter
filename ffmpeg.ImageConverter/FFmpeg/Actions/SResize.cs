namespace ffmpeg.ImageConverter.FFmpeg.Actions
{
    public struct SResize
    {
        public int Width;
        public int Height;
        public override string ToString()
        {
            return $"_{Width}_{Height}_";
        }
    }
}
