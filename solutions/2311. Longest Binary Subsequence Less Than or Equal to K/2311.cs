public class Solution
{
    public int LongestSubsequence(string s, int k)
    {
        int oneCount = 0;
        int num = 0;
        int pow = 1;

        // Take as many 1s as possible from the right.
        for (int i = s.Length - 1; i >= 0 && num + pow <= k; --i)
        {
            if (s[i] == '1')
            {
                ++oneCount;
                num += pow;
            }
            pow *= 2;
        }

        return s.Count(c => c == '0') + oneCount;
    }
}

public class Solution1
{
    public int LongestSubsequence(string s, int k)
    {
        int longestLength = 0; // The length of the longest valid subsequence
        int decimalValue = 0;  // The decimal value of the considered subsequence

        // Iterate over the string in reverse because the least significant bits
        // can be considered in isolation for the smallest possible addition to the value.
        for (int index = s.Length - 1; index >= 0; --index)
        {
            // If we find a '0', it doesn't add to the value,
            // so we can always include it in the subsequence
            if (s[index] == '0')
            {
                ++longestLength;
            }
            // Only consider '1's if the length of the sequence is less than 30
            // and adding the '1' wouldn't exceed k. We check length < 30
            // because 2^30 exceeds int.MaxValue and cannot be represented by int.
            else if (longestLength < 30 && (decimalValue | (1 << longestLength)) <= k)
            {
                // '|' is the bitwise OR operator. Here we add the value represented by
                // a '1' at the current position to the decimalValue (if it does not exceed k).
                decimalValue |= 1 << longestLength;
                // Increment the length because we've added a '1' to the subsequence.
                ++longestLength;
            }
        }
        return longestLength; // Return the computed length of the longest subsequence
    }
}