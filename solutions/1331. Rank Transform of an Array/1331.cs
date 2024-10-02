public class Solution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        int[] sortedArr = (int[])arr.Clone();
        Dictionary<int, int> rank = new Dictionary<int, int>();

        Array.Sort(sortedArr);

        foreach (int a in sortedArr)
        {
            if (!rank.ContainsKey(a))
                rank[a] = rank.Count + 1;
        }

        for (int i = 0; i < arr.Length; ++i)
            arr[i] = rank[arr[i]];

        return arr;
    }
}