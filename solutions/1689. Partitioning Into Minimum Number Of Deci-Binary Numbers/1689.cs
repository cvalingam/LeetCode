// Approach: The answer is the maximum digit in n (each deci-binary number contributes 1 to each digit position).
// Time: O(|n|) Space: O(1)

public class Solution
{
    public int MinPartitions(string n)
    {
        return n.Max(c => c - '0');
    }
}