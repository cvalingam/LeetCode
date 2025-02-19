public class Solution
{
    public string GetHappyString(int n, int k)
    {
        var nextLetters = new Dictionary<char, string> {
            {'a', "bc"}, {'b', "ac"}, {'c', "ab"}
        };
        var q = new Queue<string>(new[] { "a", "b", "c" });

        while (q.Peek().Length != n)
        {
            var u = q.Dequeue();
            foreach (var nextLetter in nextLetters[u[u.Length - 1]])
                q.Enqueue(u + nextLetter);
        }

        if (q.Count < k)
            return "";

        for (int i = 0; i < k - 1; ++i)
            q.Dequeue();
        return q.Peek();
    }
}