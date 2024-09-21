public class Solution
{
    public IList<int> LexicalOrder(int n)
    {
        List<int> ans = new List<int>();
        int curr = 1;

        while (ans.Count < n)
        {
            ans.Add(curr);
            if (curr * 10 <= n)
                curr *= 10;
            else
            {
                while (curr % 10 == 9 || curr == n)
                    curr /= 10;
                ++curr;
            }
        }

        return ans;
    }
}