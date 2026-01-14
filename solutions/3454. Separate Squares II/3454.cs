public class Solution
{
    public double SeparateSquares(int[][] squares)
    {
        var xs = new HashSet<int>();
        var segs = new List<int[]>();
        foreach (var sq in squares)
        {
            int x1 = sq[0], y1 = sq[1], l = sq[2];
            int x2 = x1 + l, y2 = y1 + l;
            xs.Add(x1);
            xs.Add(x2);
            segs.Add(new int[] { y1, x1, x2, 1 });
            segs.Add(new int[] { y2, x1, x2, -1 });
        }
        segs.Sort((a, b) => a[0].CompareTo(b[0]));
        int[] st = xs.ToArray();
        Array.Sort(st);
        var tree = new SegmentTree(st);
        var d = new Dictionary<int, int>(st.Length);
        for (int i = 0; i < st.Length; i++)
            d[st[i]] = i;
        double area = 0.0;
        int y0 = 0;
        foreach (var s in segs)
        {
            int y = s[0], x1 = s[1], x2 = s[2], k = s[3];
            area += (double)(y - y0) * tree.Query();
            tree.Modify(1, d[x1], d[x2] - 1, k);
            y0 = y;
        }
        double target = area / 2.0;
        area = 0.0;
        y0 = 0;
        foreach (var s in segs)
        {
            int y = s[0], x1 = s[1], x2 = s[2], k = s[3];
            double t = (double)(y - y0) * tree.Query();
            if (area + t >= target)
                return y0 + (target - area) / tree.Query();
            area += t;
            tree.Modify(1, d[x1], d[x2] - 1, k);
            y0 = y;
        }
        
        return 0.0;
    }
}

class Node
{
    public int l, r, cnt, length;
}

class SegmentTree
{
    private Node[] tr;
    private int[] nums;

    public SegmentTree(int[] nums)
    {
        this.nums = nums;
        int n = nums.Length - 1;
        tr = new Node[n << 2];
        for (int i = 0; i < tr.Length; ++i)
            tr[i] = new Node();
        Build(1, 0, n - 1);
    }

    private void Build(int u, int l, int r)
    {
        tr[u].l = l;
        tr[u].r = r;
        if (l != r)
        {
            int mid = (l + r) >> 1;
            Build(u << 1, l, mid);
            Build(u << 1 | 1, mid + 1, r);
        }
    }

    public void Modify(int u, int l, int r, int k)
    {
        if (tr[u].l >= l && tr[u].r <= r)
            tr[u].cnt += k;
        else
        {
            int mid = (tr[u].l + tr[u].r) >> 1;
            if (l <= mid)
                Modify(u << 1, l, r, k);
            if (r > mid)
                Modify(u << 1 | 1, l, r, k);
        }
        Pushup(u);
    }

    private void Pushup(int u)
    {
        if (tr[u].cnt > 0)
            tr[u].length = nums[tr[u].r + 1] - nums[tr[u].l];
        else if (tr[u].l == tr[u].r)
            tr[u].length = 0;
        else
            tr[u].length = tr[u << 1].length + tr[u << 1 | 1].length;
    }

    public int Query()
    {
        return tr[1].length;
    }
}