namespace LAB_08
{
    public static class LinearCongruentialGenerator
    {
        private const int A = 421;
        private const int C = 1663;
        private const int N = 7875;
        private static int _seed = 1;

        public static int Seed
        {
            set
            {
                _seed = value;
            }
        }

        // X = (A * seed + C) mod N
        public static int Rand()
        {
            _seed = (A * _seed + C) % N;
            return _seed;
        }
    }
}
