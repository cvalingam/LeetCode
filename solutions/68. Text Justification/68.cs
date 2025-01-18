public class Solution
{
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        List<string> ans = new List<string>();
        List<StringBuilder> row = new List<StringBuilder>();
        int rowLetters = 0;

        foreach (var word in words)
        {
            // If we place the word in this row, it will exceed the maximum width.
            // Therefore, we cannot put the word in this row and have to pad spaces
            // for each word in this row.
            if (rowLetters + row.Count + word.Length > maxWidth)
            {
                int spaces = maxWidth - rowLetters;
                if (row.Count == 1)
                {
                    // Pad all the spaces after row[0].
                    for (int i = 0; i < spaces; ++i)
                        row[0].Append(" ");
                }
                else
                {
                    // Evenly pad all the spaces to each word (except the last one) in
                    // this row.
                    for (int i = 0; i < spaces; ++i)
                        row[i % (row.Count - 1)].Append(" ");
                }
                string joinedRow = string.Join("", row.Select(sb => sb.ToString()));
                ans.Add(joinedRow);
                row.Clear();
                rowLetters = 0;
            }
            row.Add(new StringBuilder(word));
            rowLetters += word.Length;
        }

        string lastRow = string.Join(" ", row.Select(sb => sb.ToString()));
        StringBuilder sb = new StringBuilder(lastRow);
        int spacesToBeAdded = maxWidth - sb.Length;
        for (int i = 0; i < spacesToBeAdded; ++i)
            sb.Append(" ");

        ans.Add(sb.ToString());
        return ans;
    }
}