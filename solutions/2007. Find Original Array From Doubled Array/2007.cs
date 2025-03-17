public class Solution
{
    public int[] FindOriginalArray(int[] changed)
    {
        List<int> ans = new List<int>();
        Queue<int> q = new Queue<int>();

        Array.Sort(changed);

        foreach (int num in changed)
        {
            if (q.Count > 0 && num == q.Peek())
                q.Dequeue();
            else
            {
                q.Enqueue(num * 2);
                ans.Add(num);
            }
        }

        return q.Count == 0 ? ans.ToArray() : new int[] { };
    }
}