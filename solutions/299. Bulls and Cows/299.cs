public class Solution
{
    public string GetHint(string secret, string guess)
    {
        int A = 0;
        int B = 0;
        int[] count1 = new int[10];
        int[] count2 = new int[10];

        for (int i = 0; i < secret.Length; ++i)
        {
            if (secret[i] == guess[i])
                ++A;
            else
            {
                ++count1[secret[i] - '0'];
                ++count2[guess[i] - '0'];
            }
        }

        for (int i = 0; i < 10; ++i)
            B += Math.Min(count1[i], count2[i]);

        return $"{A}A{B}B";
    }
}