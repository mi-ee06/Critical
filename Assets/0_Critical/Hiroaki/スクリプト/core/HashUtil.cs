namespace core
{
    public static class HashUtil
    {
        public static int Hash(string text)
        {
            unchecked
            {
                const int p = 16777619;
                int hash = (int)2166136261;
                for (int i = 0; i < text.Length; i++)
                {
                    hash = (hash ^ text[i]) * p;
                }
                return hash;
            }
        }
    }
}