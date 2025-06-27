public class Solution
{
    public string LongestSubsequenceRepeatedK(string s, int k)
    {
        int[] count = new int[26];
        List<char> possibleChars = new List<char>();
        Queue<string> q = new Queue<string>(new[] { "" });

        foreach (char c in s)
            count[c - 'a']++;

        for (char c = 'a'; c <= 'z'; c++)
        {
            if (count[c - 'a'] >= k)
                possibleChars.Add(c);
        }

        string ans = "";
        while (q.Count > 0)
        {
            string currSubseq = q.Dequeue();
            if (currSubseq.Length * k > s.Length)
                return ans;

            foreach (char c in possibleChars)
            {
                string newSubseq = currSubseq + c;
                if (IsSubsequence(newSubseq, s, k))
                {
                    q.Enqueue(newSubseq);
                    ans = newSubseq;
                }
            }
        }

        return ans;
    }

    private bool IsSubsequence(string subseq, string s, int k)
    {
        int i = 0;
        foreach (char c in s)
        {
            if (c == subseq[i])
            {
                i++;
                if (i == subseq.Length)
                {
                    k--;
                    if (k == 0)
                        return true;

                    i = 0;
                }
            }
        }
        return false;
    }
}