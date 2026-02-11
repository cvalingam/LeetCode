public class Solution
{
    public int LongestBalanced(int[] nums)
    {
        int n = nums.Length;
        SegmentTree st = new SegmentTree(n);

        Dictionary<int, int> last = new Dictionary<int, int>();

        int now = 0;
        int ans = 0;

        for (int i = 1; i <= n; i++)
        {
            int x = nums[i - 1];
            int det = (x & 1) == 1 ? 1 : -1;

            if (last.ContainsKey(x))
            {
                st.Modify(1, last[x], n, -det);
                now -= det;
            }

            last[x] = i;
            st.Modify(1, i, n, det);
            now += det;

            int pos = st.Query(1, now);
            ans = Math.Max(ans, i - pos);
        }

        return ans;
    }

    class Node
    {
        public int l, r;
        public int mn, mx;
        public int lazy;
    }

    class SegmentTree
    {
        Node[] tr;

        public SegmentTree(int n)
        {
            tr = new Node[n << 2];
            for (int i = 0; i < tr.Length; i++)
            {
                tr[i] = new Node();
            }
            Build(1, 0, n);
        }

        void Build(int u, int l, int r)
        {
            tr[u].l = l;
            tr[u].r = r;
            tr[u].mn = tr[u].mx = 0;
            tr[u].lazy = 0;
            if (l == r) return;
            int mid = (l + r) >> 1;
            Build(u << 1, l, mid);
            Build(u << 1 | 1, mid + 1, r);
        }

        public void Modify(int u, int l, int r, int v)
        {
            if (tr[u].l >= l && tr[u].r <= r)
            {
                Apply(u, v);
                return;
            }
            Pushdown(u);
            int mid = (tr[u].l + tr[u].r) >> 1;
            if (l <= mid) Modify(u << 1, l, r, v);
            if (r > mid) Modify(u << 1 | 1, l, r, v);
            Pushup(u);
        }

        public int Query(int u, int target)
        {
            if (tr[u].l == tr[u].r)
                return tr[u].l;

            Pushdown(u);
            int left = u << 1;
            int right = u << 1 | 1;
            if (tr[left].mn <= target && target <= tr[left].mx)
                return Query(left, target);

            return Query(right, target);
        }

        void Apply(int u, int v)
        {
            tr[u].mn += v;
            tr[u].mx += v;
            tr[u].lazy += v;
        }

        void Pushup(int u)
        {
            tr[u].mn = Math.Min(tr[u << 1].mn, tr[u << 1 | 1].mn);
            tr[u].mx = Math.Max(tr[u << 1].mx, tr[u << 1 | 1].mx);
        }

        void Pushdown(int u)
        {
            if (tr[u].lazy != 0)
            {
                Apply(u << 1, tr[u].lazy);
                Apply(u << 1 | 1, tr[u].lazy);
                tr[u].lazy = 0;
            }
        }
    }
}