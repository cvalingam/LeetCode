public class Solution {
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital) {
        var pqMin = new PriorityQueue<IPO, IPO>(Comparer<IPO>.Create((a, b) => a.capital.CompareTo(b.capital)));
        var pqMax = new PriorityQueue<IPO, IPO>(Comparer<IPO>.Create((a, b) => b.profit.CompareTo(a.profit)));

        for(int i = 0; i < capital.Length; i++)
        {
            var ipo = new IPO(profits[i], capital[i]);
            pqMin.Enqueue(ipo, ipo);
        }

        while(k-- > 0)
        {
            while(pqMin.Count > 0 && pqMin.Peek().capital <= w)
            {
                pqMax.Enqueue(pqMin.Peek(), pqMin.Peek());
                pqMin.Dequeue();
            }

            if(pqMax.Count == 0)
                break;

            w += pqMax.Dequeue().profit;
        }

        return w;
    }
}

public class IPO
{
    public int profit;
    public int capital;

    public IPO(int pro, int cap)
    {
        this.profit = pro;
        this.capital = cap;
    }
}