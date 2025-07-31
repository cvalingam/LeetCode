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