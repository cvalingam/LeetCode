public class Solution
{
    public int[] AvoidFlood(int[] rains)
    {
        int n = rains.Length;
        int[] result = new int[n];
        // Initialize all days with -1 (default for rainy days)
        for (int i = 0; i < n; i++)
            result[i] = -1;

        // SortedSet to store indices of sunny days (when rains[i] == 0)
        // Using SortedSet for efficient search of the next available sunny day
        SortedSet<int> sunnyDays = new SortedSet<int>();

        // Dictionary to store the last occurrence index of each lake that was filled
        // Key: lake number, Value: day index when it last rained on this lake
        Dictionary<int, int> lastRainedLakes = new Dictionary<int, int>();

        for (int day = 0; day < n; day++)
        {
            int lake = rains[day];

            if (lake > 0)
            {
                // It's raining on this lake
                if (lastRainedLakes.ContainsKey(lake))
                {
                    // This lake was already full, we need to dry it before today
                    // Find the first sunny day after the last time it rained on this lake
                    int lastRainedDay = lastRainedLakes[lake];
                    int? dryDay = null;

                    // SortedSet does not have a direct higher method, so we use GetViewBetween
                    foreach (var sunnyDay in sunnyDays.GetViewBetween(lastRainedDay + 1, n))
                    {
                        dryDay = sunnyDay;
                        break;
                    }

                    if (dryDay == null)
                        // No sunny day available to dry this lake - flooding occurs
                        return new int[0];

                    // Use this sunny day to dry the current lake
                    result[dryDay.Value] = lake;
                    sunnyDays.Remove(dryDay.Value);
                }
                // Update the last rained day for this lake
                lastRainedLakes[lake] = day;
            }
            else
            {
                // It's a sunny day, add to available sunny days
                sunnyDays.Add(day);
                // Temporarily set to 1 (can be any positive number if not used)
                result[day] = 1;
            }
        }

        return result;
    }
}