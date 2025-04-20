public class Solution
{
    public int NumRabbits(int[] answers)
    {
        int ans = 0;
        int[] count = new int[1000];

        foreach (int answer in answers)
        {
            if (count[answer] % (answer + 1) == 0)
                ans += answer + 1;
            ++count[answer];
        }

        return ans;
    }
}