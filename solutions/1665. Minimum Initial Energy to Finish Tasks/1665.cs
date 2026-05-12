// Approach: Sort tasks by (actual - minimum) in ascending order.
// Greedily process sorted tasks tracking prevSaved (cumulative energy saved/spent).
// If prevSaved < minimum required for current task, top up the initial energy.
// Time: O(n log n) Space: O(1)

public class Solution
{
    public int MinimumEffort(int[][] tasks)
    {
        int ans = 0;
        int prevSaved = 0;

        Array.Sort(tasks, (a, b) => (a[0] - a[1]).CompareTo(b[0] - b[1]));

        foreach (var task in tasks)
        {
            int actual = task[0];
            int minimum = task[1];
            if (prevSaved < minimum)
            {
                ans += minimum - prevSaved;
                prevSaved = minimum - actual;
            }
            else
                prevSaved -= actual;
        }

        return ans;
    }
}