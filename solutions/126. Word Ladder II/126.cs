public class Solution
{
    Dictionary<string, int> mpp;
    IList<IList<string>> ans;
    string b;

    private void WLDFS(string word, List<string> seq)
    {
        if (word.Equals(b))
        {
            var dup = new List<string>(seq);
            dup.Reverse();
            ans.Add(dup);
            return;
        }

        int steps = mpp[word];
        int n = word.Length;

        for (int i = 0; i < n; i++)
        {
            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                char[] replacedCharArray = word.ToCharArray();
                replacedCharArray[i] = ch;
                string newWord = new string(replacedCharArray);
                if (mpp.ContainsKey(newWord) && mpp[newWord] + 1 == steps)
                {
                    seq.Add(newWord);
                    WLDFS(newWord, seq);
                    seq.RemoveAt(seq.Count - 1);
                }
            }
        }
    }

    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> set = new HashSet<string>();
        foreach (string word in wordList)
        {
            set.Add(word);
        }

        Queue<string> q = new Queue<string>();
        b = beginWord;
        q.Enqueue(beginWord);
        mpp = new Dictionary<string, int>();

        mpp.Add(beginWord, 1);

        int n = beginWord.Length;
        set.Remove(beginWord);

        while (q.Count > 0)
        {
            string word = q.Dequeue();
            int steps = mpp[word];

            if (word.Equals(endWord))
                break;

            for (int i = 0; i < n; i++)
            {
                for (char ch = 'a'; ch <= 'z'; ch++)
                {
                    char[] replacedCharArray = word.ToCharArray();
                    replacedCharArray[i] = ch;
                    string newWord = new string(replacedCharArray);
                    if (set.Contains(newWord))
                    {
                        q.Enqueue(newWord);
                        set.Remove(newWord);
                        if (!mpp.ContainsKey(newWord))
                            mpp.Add(newWord, steps + 1);
                        else
                            mpp[newWord] = steps + 1;
                    }
                }
            }
        }
        ans = new List<IList<string>>();

        if (mpp.ContainsKey(endWord))
        {
            List<string> seq = new List<string>();
            seq.Add(endWord);
            WLDFS(endWord, seq);
        }

        return ans;
    }
}