namespace LAB_08
{
    using System.Text;

    public static class RC4Crypt
    {
        public static string Crypt(string data, byte[] key)
        {
            return Encoding.GetEncoding(1251).GetString(Crypt(Encoding.GetEncoding(1251).GetBytes(data), key));
        }

        public static byte[] Crypt(byte[] data, byte[] key)
        {
            int a, i, j, k, tmp;
            int[] box = new int[256];
            byte[] result = new byte[data.Length];

            for (i = 0; i < box.Length; i++)
            {
                box[i] = i;
            }

            for (j = i = 0; i < box.Length; i++)
            {
                j = (j + box[i] + key[i % key.Length]) % box.Length;
                tmp = box[i];
                box[i] = box[j];
                box[j] = tmp;
            }

            for (a = j = i = 0; i < data.Length; i++)
            {
                a = a + 1;
                a = a % box.Length;
                j = j + box[a];
                j = j % box.Length;
                tmp = box[a];
                box[a] = box[j];
                box[j] = tmp;
                k = box[(box[a] + box[j]) % box.Length];
                result[i] = (byte)(data[i] ^ k);
            }

            return result;
        }
    }
}
