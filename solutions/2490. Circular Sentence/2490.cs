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