public class Solution
{
    public long CountOfSubstrings(string word, int k)
    {
        return F(word, k) - F(word, k + 1);
    }

    private long F(string word, int k)
    {
        long ans = 0;
        int l = 0, x = 0;
        Dictionary<char, int> cnt = new Dictionary<char, int>();
        foreach (char c in word)
        {
            if (Vowel(c))
            {
                if (cnt.ContainsKey(c))
                    cnt[c]++;
                else
                    cnt[c] = 1;
            }
            else
                x++;
            while (x >= k && cnt.Count == 5)
            {
                char d = word[l++];
                if (Vowel(d))
                {
                    if (cnt.ContainsKey(d))
                    {
                        cnt[d]--;
                        if (cnt[d] == 0)
                            cnt.Remove(d);
                    }
                }
                else
                    x--;
            }
            ans += l;
        }
        
        return ans;
    }

    private bool Vowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
}