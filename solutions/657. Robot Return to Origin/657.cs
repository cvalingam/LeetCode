public class Solution
{
    public bool JudgeCircle(string moves)
    {
        int right = 0;
        int up = 0;

        foreach (char move in moves)
        {
            switch (move)
            {
                case 'R':
                    right++;
                    break;
                case 'L':
                    right--;
                    break;
                case 'U':
                    up++;
                    break;
                case 'D':
                    up--;
                    break;
            }
        }

        return right == 0 && up == 0;
    }
}