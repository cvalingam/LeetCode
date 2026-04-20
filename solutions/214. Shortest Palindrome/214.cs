// Approach: Find the longest palindromic prefix of s using KMP / rolling hash.
// Construct the string s + '#' + reverse(s) and compute the KMP failure function.
// The last value of the failure function gives the length of the longest palindromic prefix.
// Prepend the reverse of the remaining suffix (s[prefixLen..]) to s to form the shortest palindrome.
// Rolling hash implementation: compare hash of prefix from left and from right simultaneously.
// Time: O(n) Space: O(n) for the reversed string and hash computation.

public class Solution
{
    public string ShortestPalindrome(string s)
    {
        // we use a prime number as a base for computing rolling hash
        const int baseValue = 131;
        int multiplier = 1;  // modular multiplication factor, initially 1
        const int mod = (int)1e9 + 7; // we will use a large prime number to mod the result to avoid overflow
        int prefixHash = 0; // rolling hash from the front
        int suffixHash = 0; // rolling hash from the back
        int palindromeIdx = 0; // the index till the string is a palindrome     
        int length = s.Length; // length of the string

        // iterate through the string to update the prefix and suffix hashes
        for (int i = 0; i < length; ++i)
        {
            // convert character to number (assuming lowercase 'a' to 'z')
            int charValue = s[i] - 'a' + 1;
            // update the prefix hash and ensure it is within the bounds by taking modulo
            prefixHash = (int)(((long)prefixHash * baseValue + charValue) % mod);
            // update the suffix hash and ensure it is within the bounds by taking modulo
            suffixHash = (int)((suffixHash + (long)charValue * multiplier) % mod);
            // update the multiplier for the next character
            multiplier = (int)(((long)multiplier * baseValue) % mod);

            // if the prefix and suffix are equal, then we know the string up to index i is a palindrome
            if (prefixHash == suffixHash)
                palindromeIdx = i + 1;
        }

        // If the whole string is a palindrome, return it as is
        if (palindromeIdx == length)
            return s;

        // We need to add the reverse of the substring from palindromeIdx to the end to the front
        // to make the string a palindrome
        string suffixToBeAdded = new string(s.Substring(palindromeIdx).ToCharArray().Reverse().ToArray());

        // Return the string with the suffix added in front to form the shortest palindrome
        return suffixToBeAdded + s;
    }
}