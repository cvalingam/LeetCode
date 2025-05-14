public class Solution
{
    public int LengthAfterTransformations(string s, int t, IList<int> nums)
    {
        // T[i][j] := the number of ways to transform ('a' + i) to ('a' + j)
        int[][] T = GetTransformationMatrix(nums);
        int[][] poweredT = MatrixPow(T, t);
        int[] count = new int[26];
        // lengths[i] := the total length of ('a' + i) after t transformations
        long[] lengths = new long[26];

        foreach (char c in s)
            ++count[c - 'a'];

        for (int i = 0; i < 26; ++i)
        {
            for (int j = 0; j < 26; ++j)
            {
                lengths[j] += (long)count[i] * poweredT[i][j];
                lengths[j] %= MOD;
            }
        }

        return (int)(lengths.Sum() % MOD);
    }

    private const int MOD = 1_000_000_007;

    private int[][] GetTransformationMatrix(IList<int> nums)
    {
        int[][] T = new int[26][];
        for (int i = 0; i < 26; ++i)
            T[i] = new int[26];

        for (int i = 0; i < nums.Count; ++i)
        {
            for (int step = 1; step <= nums[i]; ++step)
                ++T[i][(i + step) % 26];
        }
        return T;
    }

    private int[][] GetIdentityMatrix(int sz)
    {
        int[][] I = new int[sz][];
        for (int i = 0; i < sz; ++i)
        {
            I[i] = new int[sz];
            I[i][i] = 1;
        }
        return I;
    }

    // Returns A * B.
    private int[][] MatrixMult(int[][] A, int[][] B)
    {
        int sz = A.Length;
        int[][] C = new int[sz][];
        for (int i = 0; i < sz; ++i)
        {
            C[i] = new int[sz];
            for (int j = 0; j < sz; ++j)
            {
                for (int k = 0; k < sz; ++k)
                    C[i][j] = (int)((C[i][j] + (long)A[i][k] * B[k][j]) % MOD);
            }
        }
        return C;
    }

    // Returns M^n.
    private int[][] MatrixPow(int[][] M, int n)
    {
        if (n == 0)
            return GetIdentityMatrix(M.Length);

        if (n % 2 == 1)
            return MatrixMult(M, MatrixPow(M, n - 1));

        return MatrixPow(MatrixMult(M, M), n / 2);
    }
}