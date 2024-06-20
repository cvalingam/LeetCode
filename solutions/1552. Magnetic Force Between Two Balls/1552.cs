public class Solution
{
    public int MaxDistance(int[] position, int m)
    {
        Array.Sort(position);

        int low = 1, high = position[position.Length - 1] - position[0];

        while (low < high)
        {
            int mid = high - (high - low) / 2;
            if (numBalls(position, mid) >= m)
                low = mid;
            else
                high = mid - 1;
        }

        return low;
    }

    private int numBalls(int[] position, int force)
    {
        int balls = 0;
        int prevPosition = -force;

        foreach (int pos in position)
        {
            if (pos - prevPosition >= force)
            {
                balls++;
                prevPosition = pos;
            }
        }

        return balls;
    }
}