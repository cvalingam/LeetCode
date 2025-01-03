public class Solution
{
    public int MaximumWhiteTiles(int[][] tiles, int carpetLen)
    {
        if (tiles.Any(tile => tile[1] - tile[0] + 1 >= carpetLen))
            return carpetLen;

        int ans = 0;
        List<int> starts = new List<int>();
        int[] prefix = new int[tiles.Length + 1];

        Array.Sort(tiles, (a, b) => a[0].CompareTo(b[0]));

        foreach (var tile in tiles)
            starts.Add(tile[0]);

        for (int i = 0; i < tiles.Length; ++i)
        {
            int length = tiles[i][1] - tiles[i][0] + 1;
            prefix[i + 1] = prefix[i] + length;
        }

        for (int i = 0; i < tiles.Length; ++i)
        {
            int s = tiles[i][0];
            int carpetEnd = s + carpetLen - 1;
            int endIndex = FirstGreater(starts, carpetEnd) - 1;
            int notCover = Math.Max(0, tiles[endIndex][1] - carpetEnd);
            ans = Math.Max(ans, prefix[endIndex + 1] - prefix[i] - notCover);
        }

        return ans;
    }

    private int FirstGreater(List<int> A, int target)
    {
        int i = A.BinarySearch(target + 1);
        return i < 0 ? -i - 1 : i;
    }
}