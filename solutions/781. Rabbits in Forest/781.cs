// Approach: Count each reported answer value; for each distinct answer a, group size = a+1, and we need ceil(count / (a+1)) full groups.
// Time: O(n) Space: O(n)

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