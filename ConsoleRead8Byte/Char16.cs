namespace ConsoleRead8Byte
{
    struct Char16
    {
        public byte Data;
        public string Data16Str;
        public override string ToString()
        {
            return $"{Data}[{Data16Str}][{(char)Data}]";
        }
    };
}
