public class Solution
{
    public string CountAndSay(int n)
    {
        string val = "1";

        for (int i = 1; i < n; i++)
        {
            char c = val[0];
            StringBuilder s = new StringBuilder();
            int cnt = 1;

            for (int j = 1; j < val.Length; j++)
            {
                if (c != val[j])
                {
                    s.Append(cnt);
                    s.Append(c);
                    cnt = 0;
                    c = val[j];
                }
                cnt++;
            }
            s.Append(cnt);
            s.Append(c);
            val = s.ToString();
        }

        return val;
    }
}