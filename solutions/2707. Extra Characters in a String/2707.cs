public class Solution
{
    public int MinExtraChar(string s, string[] dictionary)
    {
        // Create a set from the dictionary for efficient lookup of words.
        HashSet<string> wordSet = new HashSet<string>(dictionary);

        int n = s.Length; // Get the length of the string s

        // Create an array to store the minimum number of extra characters needed.
        // f[i] will be the minimum count for substring s[0..i)
        int[] minExtraChars = new int[n + 1];
        minExtraChars[0] = 0; // Base case: no extra characters needed for an empty string

        // Iterate over each character in the string
        for (int i = 1; i <= n; ++i)
        {
            // By default, assume one more extra char than the minExtraChars of the previous substring
            minExtraChars[i] = minExtraChars[i - 1] + 1;

            // Check each possible substring ending at current character i
            for (int j = 0; j < i; ++j)
            {
                // If the substring from index j to i is in the dictionary,
                // update minExtraChars[i] if a smaller value is found
                if (wordSet.Contains(s.Substring(j, i - j)))
                {
                    minExtraChars[i] = Math.Min(minExtraChars[i], minExtraChars[j]);
                }
            }
        }

        // Return the minimum extra characters for the entire string
        return minExtraChars[n];
    }
}