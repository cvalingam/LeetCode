// Approach: BFS from start index. From each index i, jump to i-arr[i] or i+arr[i].
// Mark visited to avoid re-processing. Return true if any reachable index has arr[index]==0.
// Time: O(n) Space: O(n)

public class Solution
{
    public bool CanReach(int[] arr, int start)
    {
        int n = arr.Length;
        Queue<int> q = new Queue<int>();
        q.Enqueue(start);
        bool[] seen = new bool[n];

        while (q.Count > 0)
        {
            int node = q.Dequeue();
            if (arr[node] == 0)
                return true;
            if (seen[node])
                continue;
            if (node - arr[node] >= 0)
                q.Enqueue(node - arr[node]);
            if (node + arr[node] < n)
                q.Enqueue(node + arr[node]);
            seen[node] = true;
        }

        return false;
    }
}