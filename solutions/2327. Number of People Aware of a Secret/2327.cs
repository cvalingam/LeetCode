public class Solution
{
    private const int MOD = (int)1e9 + 7;

    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {
        // Array size with buffer to avoid index out of bounds
        int arraySize = (n << 1) + 10;  // n * 2 + 10

        // Track the net change in people who know the secret on each day
        long[] peopleKnowingSecret = new long[arraySize];

        // Track new people who learn the secret on each day
        long[] newPeoplePerDay = new long[arraySize];

        // Day 1: One person initially knows the secret
        newPeoplePerDay[1] = 1;

        // Process each day from 1 to n
        for (int currentDay = 1; currentDay <= n; ++currentDay)
        {
            // If new people learned the secret on this day
            if (newPeoplePerDay[currentDay] > 0)
            {
                // Add new people to the count of people knowing the secret
                peopleKnowingSecret[currentDay] = (peopleKnowingSecret[currentDay] +
                                                    newPeoplePerDay[currentDay]) % MOD;

                // Schedule when these people will forget the secret
                peopleKnowingSecret[currentDay + forget] =
                    (peopleKnowingSecret[currentDay + forget] -
                     newPeoplePerDay[currentDay] + MOD) % MOD;

                // Calculate when these people can start sharing the secret
                int shareStartDay = currentDay + delay;

                // These people can share from (currentDay + delay) to (currentDay + forget - 1)
                while (shareStartDay < currentDay + forget)
                {
                    // Each person shares with one new person per day during their sharing period
                    newPeoplePerDay[shareStartDay] = (newPeoplePerDay[shareStartDay] +
                                                      newPeoplePerDay[currentDay]) % MOD;
                    ++shareStartDay;
                }
            }
        }

        // Calculate total people who know the secret on day n
        // Sum up all the net changes from day 1 to day n
        long totalPeopleKnowing = 0;
        for (int day = 1; day <= n; ++day)
            totalPeopleKnowing = (totalPeopleKnowing + peopleKnowingSecret[day]) % MOD;

        return (int)totalPeopleKnowing;
    }
}