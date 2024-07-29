public class Solution
{
    public int NumTeams(int[] rating)
    {
        int ans = 0;

        for (int i = 1; i < rating.Length - 1; i++)
        {
            int smaller_left = 0, bigger_left = 0;

            for (int j = 0; j < i; j++)
            {
                if (rating[j] < rating[i])
                    smaller_left++;
                else if (rating[j] > rating[i])
                    bigger_left++;
            }

            int smaller_right = 0, bigger_right = 0;
            for (int j = i + 1; j < rating.Length; j++)
            {
                if (rating[j] < rating[i])
                    smaller_right++;
                else if (rating[j] > rating[i])
                    bigger_right++;
            }

            ans += smaller_left * bigger_right + bigger_left * smaller_right;
        }

        return ans;
    }
}