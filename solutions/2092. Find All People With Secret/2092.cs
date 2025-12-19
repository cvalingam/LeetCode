public class Solution
{
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
    {
        List<int> ans = new List<int>();
        UnionFind uf = new UnionFind(n);
        var timeToPairs = new SortedDictionary<int, List<(int, int)>>();

        uf.UnionByRank(0, firstPerson);

        foreach (var m in meetings)
        {
            if (!timeToPairs.ContainsKey(m[2]))
                timeToPairs[m[2]] = new List<(int, int)>();
            timeToPairs[m[2]].Add((m[0], m[1]));
        }

        foreach (var pairs in timeToPairs.Values)
        {
            HashSet<int> peopleUnioned = new HashSet<int>();
            foreach (var pair in pairs)
            {
                int x = pair.Item1;
                int y = pair.Item2;
                uf.UnionByRank(x, y);
                peopleUnioned.Add(x);
                peopleUnioned.Add(y);
            }
            foreach (var person in peopleUnioned)
            {
                if (!uf.Connected(person, 0))
                    uf.Reset(person);
            }
        }

        for (int i = 0; i < n; ++i)
        {
            if (uf.Connected(i, 0))
                ans.Add(i);
        }

        return ans;
    }

    class UnionFind
    {
        private int[] id;
        private int[] rank;

        public UnionFind(int n)
        {
            id = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; ++i)
                id[i] = i;
        }

        public void UnionByRank(int u, int v)
        {
            int i = Find(u);
            int j = Find(v);
            if (i == j)
                return;
            if (rank[i] < rank[j])
                id[i] = j;
            else if (rank[i] > rank[j])
                id[j] = i;
            else
            {
                id[i] = j;
                ++rank[j];
            }
        }

        public bool Connected(int u, int v)
        {
            return Find(u) == Find(v);
        }

        public void Reset(int u)
        {
            id[u] = u;
        }

        private int Find(int u)
        {
            if (id[u] == u) 
                return u;
            return id[u] = Find(id[u]);
        }
    }
}