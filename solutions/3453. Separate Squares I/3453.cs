public class Solution
{
    public double SeparateSquares(int[][] squares)
    {
        double halfArea = squares.Sum(square => Math.Pow(square[2], 2)) / 2;
        var events = new List<int[]>();

        foreach (var square in squares)
        {
            int y = square[1];
            int l = square[2];
            events.Add(new int[] { y, 1, l });     // start of square
            events.Add(new int[] { y + l, 0, l }); // end of square
        }

        events.Sort((a, b) => a[0].CompareTo(b[0]));

        double area = 0;
        int width = 0;
        int prevY = 0;

        foreach (var e in events)
        {
            int y = e[0];
            int l = e[2];
            double areaGain = width * (long)(y - prevY);
            if (area + areaGain >= halfArea)
                return prevY + (halfArea - area) / width;
            area += areaGain;
            width += (e[1] == 1) ? l : -l;
            prevY = y;
        }

        throw new ArgumentException();
    }
}