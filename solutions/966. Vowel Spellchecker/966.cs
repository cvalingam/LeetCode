public class Solution
{
    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        // Set for exact match checking
        HashSet<string> exactWords = new HashSet<string>();

        // Map for case-insensitive matches (lowercase -> first occurrence in wordlist)
        Dictionary<string, string> caseInsensitiveMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Map for vowel-error matches (vowel pattern -> first occurrence in wordlist)
        Dictionary<string, string> vowelPatternMap = new Dictionary<string, string>();

        // Build the data structures from wordlist
        foreach (string word in wordlist)
        {
            // Add to exact match set
            exactWords.Add(word);

            // Add to case-insensitive map (only first occurrence)
            string lowercaseWord = word.ToLower();
            if (!caseInsensitiveMap.ContainsKey(lowercaseWord))
                caseInsensitiveMap[lowercaseWord] = word;

            // Add to vowel pattern map (only first occurrence)
            string vowelPattern = ReplaceVowelsWithWildcard(lowercaseWord);
            if (!vowelPatternMap.ContainsKey(vowelPattern))
                vowelPatternMap[vowelPattern] = word;
        }

        // Process each query
        int queryCount = queries.Length;
        string[] results = new string[queryCount];

        for (int i = 0; i < queryCount; i++)
        {
            string query = queries[i];

            // Priority 1: Check for exact match
            if (exactWords.Contains(query))
            {
                results[i] = query;
                continue;
            }

            // Priority 2: Check for case-insensitive match
            string lowercaseQuery = query.ToLower();
            if (caseInsensitiveMap.TryGetValue(lowercaseQuery, out string caseInsensitiveMatch))
            {
                results[i] = caseInsensitiveMatch;
                continue;
            }

            // Priority 3: Check for vowel-error match
            string queryVowelPattern = ReplaceVowelsWithWildcard(lowercaseQuery);
            if (vowelPatternMap.TryGetValue(queryVowelPattern, out string vowelPatternMatch))
            {
                results[i] = vowelPatternMatch;
                continue;
            }

            // No match found
            results[i] = "";
        }

        return results;
    }

    /**
     * Replaces all vowels in the string with wildcard character '*'.
     * 
     * @param word Input string (should be lowercase)
     * @return String with vowels replaced by '*'
     */
    private string ReplaceVowelsWithWildcard(string word)
    {
        char[] characters = word.ToCharArray();

        for (int i = 0; i < characters.Length; i++)
        {
            char currentChar = characters[i];
            // Check if current character is a vowel
            if (currentChar == 'a' || currentChar == 'e' || currentChar == 'i' ||
                currentChar == 'o' || currentChar == 'u')
                characters[i] = '*';
        }

        return new string(characters);
    }
}