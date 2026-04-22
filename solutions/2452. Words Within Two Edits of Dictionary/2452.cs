// Approach: For each word in `queries`, we compare it against every word in `dictionary`.
// Since all words have the same length, we iterate through characters and count the differences.
// If we find a dictionary word where the difference is at most 2 (i.e., less than 3 edits), we add
// the query word to the result list and stop checking further dictionary words for this query.
// This brute-force pairing approach works efficiently within the constraints.
//
// Time: O(Q * D * L), where Q is the number of query words, D is the number of dictionary words, and L is the string length.
// Space: O(1) auxiliary space (excluding the output list), as we only count character differences.

public class Solution
{
    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        var ans = new List<string>();

        foreach (var query in queries)
        {
            foreach (var word in dictionary)
            {
                if (GetDiff(query, word) < 3)
                {
                    ans.Add(query);
                    break;
                }
            }
        }

        return ans;
    }

    private int GetDiff(string query, string word)
    {
        int diff = 0;
        for (int i = 0; i < query.Length; ++i)
        {
            if (query[i] != word[i])
                ++diff;
        }
        
        return diff;
    }
}