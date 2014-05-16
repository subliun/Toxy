namespace Toxy
{
    static class Config
    {
        public static bool TypingDetection = false;
        public static bool Encrypted = false;
        public static int Style = 3;

        public static bool Save(string loc)
        {
            return true;
        }

        public static bool Load(string loc)
        {
            return true;
        }
    }
}
