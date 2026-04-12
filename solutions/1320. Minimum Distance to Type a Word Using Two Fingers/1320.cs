// Approach: Top-down DP with memoization over state (left finger position, right finger
// position, current index). At each character, try typing with left or right finger and
// take the minimum total movement. Use virtual position 26 for an unused finger.
// Time: O(27*27*n) Space: O(27*27*n)
public class Solution
{
    public int MinimumDistance(string word)
    {
        int?[][][] mem = new int?[27][][];
        for (int i = 0; i < 27; i++)
        {
            mem[i] = new int?[27][];
            for (int j = 0; j < 27; j++)
            {
                mem[i][j] = new int?[word.Length];
            }
        }
        return MinimumDistance(word, 26, 26, 0, mem);
    }

    private int MinimumDistance(string word, int i, int j, int k, int?[][][] mem)
    {
        if (k == word.Length)
            return 0;
        if (mem[i][j][k].HasValue)
            return mem[i][j][k].Value;
        int c = word[k] - 'A';
        int moveLeft = Dist(i, c) + MinimumDistance(word, c, j, k + 1, mem);
        int moveRight = Dist(j, c) + MinimumDistance(word, i, c, k + 1, mem);
        mem[i][j][k] = Math.Min(moveLeft, moveRight);
        return mem[i][j][k].Value;
    }

    private int Dist(int a, int b)
    {
        if (a == 26) // the first hovering state
            return 0;
        int x1 = a / 6;
        int y1 = a % 6;
        int x2 = b / 6;
        int y2 = b % 6;
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }
}