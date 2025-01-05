public class Solution
{
    public string ShiftingLetters(string s, int[][] shifts)
    {
        StringBuilder sb = new StringBuilder();
        int currShift = 0;
        int[] timeline = new int[s.Length + 1];

        foreach (var shift in shifts)
        {
            int start = shift[0];
            int end = shift[1];
            int direction = shift[2];
            int diff = direction == 1 ? 1 : -1;
            timeline[start] += diff;
            timeline[end + 1] -= diff;
        }

        for (int i = 0; i < s.Length; ++i)
        {
            currShift = (currShift + timeline[i]) % 26;
            int num = (s[i] - 'a' + currShift + 26) % 26;
            sb.Append((char)('a' + num));
        }

        return sb.ToString();
    }
}