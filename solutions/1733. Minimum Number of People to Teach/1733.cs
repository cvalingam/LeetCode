public class Solution
{
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
    {
        // Set to store people who cannot communicate with at least one friend
        HashSet<int> peopleNeedingHelp = new HashSet<int>();

        // Check each friendship pair to find those who cannot communicate
        foreach (var friendship in friendships)
        {
            int person1 = friendship[0];
            int person2 = friendship[1];

            // If these two friends don't share a common language
            if (!HaveCommonLanguage(person1, person2, languages))
            {
                peopleNeedingHelp.Add(person1);
                peopleNeedingHelp.Add(person2);
            }
        }

        // If everyone can already communicate, no teaching needed
        if (peopleNeedingHelp.Count == 0)
            return 0;

        // Count how many people needing help already know each language
        int[] languageCount = new int[n + 1];  // Index 0 unused, languages are 1 to n

        foreach (int person in peopleNeedingHelp)
        {
            // For each language this person knows
            foreach (int language in languages[person - 1])
                // person-1 because array is 0-indexed
                languageCount[language]++;
        }

        // Find the language known by the most people who need help
        int maxPeopleKnowingLanguage = 0;
        foreach (int count in languageCount)
            maxPeopleKnowingLanguage = Math.Max(maxPeopleKnowingLanguage, count);

        // The minimum people to teach = total people needing help - those who already know the best language
        return peopleNeedingHelp.Count - maxPeopleKnowingLanguage;
    }

    /**
     * Checks if two people share at least one common language.
     * 
     * @param person1   First person (1-indexed)
     * @param person2   Second person (1-indexed)
     * @param languages 2D array of languages known by each person
     * @return true if they share a common language, false otherwise
     */
    private bool HaveCommonLanguage(int person1, int person2, int[][] languages)
    {
        // Check each language of person1 against each language of person2
        foreach (int language1 in languages[person1 - 1])
        {  // person1-1 for 0-indexed array
            foreach (int language2 in languages[person2 - 1])
            {  // person2-1 for 0-indexed array
                if (language1 == language2)
                    return true;  // Found a common language
            }
        }
        
        return false;  // No common language found
    }
}