public class Solution
{
    public int OpenLock(string[] deadends, string target)
    {
        HashSet<string> set = new HashSet<string>();

        foreach (string val in deadends)
            set.Add(val);

        if (set.Contains("0000"))
            return -1;

        if (target.Equals("0000"))
            return 0;

        int ans = 0;
        Queue<string> q = new Queue<string>();
        q.Enqueue("0000");

        while (q.Count > 0)
        {
            ans++;
            for (int sz = q.Count; sz > 0; sz--)
            {
                char[] str = q.Dequeue().ToCharArray();

                for (int i = 0; i < 4; i++)
                {
                    char cache = str[i];
                    str[i] = (str[i] == '9' ? '0' : (char)(str[i] + 1));
                    string word = new string(str);
                    if (word == target)
                        return ans;

                    if (!set.Contains(word))
                    {
                        q.Enqueue(word);
                        set.Add(word);
                    }

                    str[i] = cache;

                    str[i] = (str[i] == '0' ? '9' : (char)(str[i] - 1));
                    word = new string(str);
                    if (word == target)
                        return ans;

                    if (!set.Contains(word))
                    {
                        q.Enqueue(word);
                        set.Add(word);
                    }

                    str[i] = cache;
                }
            }
        }

        return -1;
    }
}