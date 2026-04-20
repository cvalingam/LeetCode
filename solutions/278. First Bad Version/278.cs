/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

// Approach: Binary search for the leftmost position where IsBadVersion returns true.
// Maintain lo = 1 and hi = n; at each step compute mid = lo + (hi - lo) / 2 (avoids overflow).
// If IsBadVersion(mid) is true, the first bad version is at mid or earlier: set hi = mid.
// If false, the first bad version is strictly after mid: set lo = mid + 1.
// When lo == hi, we have found the first bad version.
// Using hi = mid (not mid - 1) ensures we never skip the answer.
// Time: O(log n) Space: O(1)

public class Solution : VersionControl
{
    public int FirstBadVersion(int n)
    {
        int l = 1;
        int r = n;

        while (l < r)
        {
            int m = l + (r - l) / 2;
            if (IsBadVersion(m))
                r = m;
            else
                l = m + 1;
        }

        return l;
    }
}