// Approach: Maintain a rolling set of OR values of all subarrays ending at the current index; add all values to the global distinct set.
// Time: O(n log max) Space: O(n log max)

using System.Collections.Generic;

public class Solution
{
    public int SubarrayBitwiseORs(int[] arr)
    {
        HashSet<int> result = new HashSet<int>();
        HashSet<int> current = new HashSet<int>();
        
        foreach (int num in arr)
        {
            HashSet<int> next = new HashSet<int>();
            next.Add(num);
            
            foreach (int val in current)
            {
                next.Add(val | num);
            }
            
            current = next;
            
            foreach (int val in current)
            {
                result.Add(val);
            }
        }
        
        return result.Count;
    }
}