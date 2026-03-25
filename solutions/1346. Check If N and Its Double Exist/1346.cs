// Approach: HashSet; for each element check if its double or (if even) its half is already seen.
// Time: O(n) Space: O(n)

public class Solution
{
    public bool CheckIfExist(int[] arr)
    {
        HashSet<int> seen = new HashSet<int>();

        foreach (int a in arr)
        {
            if (seen.Contains(a * 2) || (a % 2 == 0 && seen.Contains(a / 2)))
                return true;
            seen.Add(a);
        }

        return false;
    }
}