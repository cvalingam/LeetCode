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