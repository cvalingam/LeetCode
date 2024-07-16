public class Solution
{
    public int NumFriendRequests(int[] ages)
    {
        int ans = 0;
        int[] count = new int[121];

        foreach (int age in ages)
            ++count[age];

        for (int ageA = 1; ageA <= 120; ++ageA)
        {
            for (int ageB = 1; ageB <= 120; ++ageB)
            {
                int countA = count[ageA];
                int countB = count[ageB];
                if (countA > 0 && countB > 0 && Request(ageA, ageB))
                {
                    if (ageA == ageB)
                        ans += countA * (countB - 1);
                    else
                        ans += countA * countB;
                }
            }
        }

        return ans;
    }

    private bool Request(int ageA, int ageB)
    {
        return !(ageB <= 0.5 * ageA + 7 || ageB > ageA || ageB > 100 && ageA < 100);
    }
}