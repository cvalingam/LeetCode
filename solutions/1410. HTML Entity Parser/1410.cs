// Approach: Sequential string replacement for each HTML entity; process '&amp;' last to avoid double-replacement.
// Time: O(n) Space: O(n)

public class Solution
{
    public string EntityParser(string text)
    {
        var entryToChar = new Dictionary<string, string> {
            { "&quot;", "\"" },
            { "&apos;", "'" },
            { "&gt;", ">" },
            { "&lt;", "<" },
            { "&frasl;", "/" }
        };

        foreach (var entry in entryToChar)
        {
            var entity = entry.Key;
            var c = entry.Value;
            text = text.Replace(entity, c);
        }

        // Process '&' in last.
        return text.Replace("&amp;", "&");
    }
}