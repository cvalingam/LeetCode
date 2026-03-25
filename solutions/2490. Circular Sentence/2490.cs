// Approach: Check each word boundary where last char of prev equals first char of next; wrap around.
// Time: O(n) Space: O(1)

public class Solution
{
    public bool IsCircularSentence(string sentence)
    {
        for (int i = 0; i < sentence.Length; ++i)
        {
            if (sentence[i] == ' ' && sentence[i - 1] != sentence[i + 1])
                return false;
        }
        
        return sentence[0] == sentence[sentence.Length - 1];
    }
}