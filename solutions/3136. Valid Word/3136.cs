// Approach: Check length ≥ 3, all alnum, has ≥ 1 vowel and ≥ 1 consonant.
// Time: O(n) Space: O(1)

public class Solution
{
    public bool IsValid(string word)
    {
        return word.Length >= 3 && word.All(char.IsLetterOrDigit) &&
               word.Any(c => IsVowel(c)) &&
               word.Any(c => IsConsonant(c));
    }

    private bool IsVowel(char c)
    {
        return "aeiouAEIOU".IndexOf(c) != -1;
    }

    private bool IsConsonant(char c)
    {
        return char.IsLetter(c) && !IsVowel(c);
    }
}