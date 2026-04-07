// Approach: Pre-compute every perimeter cell in traversal order (bottom row → right column
// → top row → left column) and record the facing direction at each cell. Step() advances
// the index modulo perimeter length in O(1). Handle the edge case where no step has been
// taken (direction is "East" regardless of stored direction at index 0).
// Time: O(W+H) constructor, O(1) Step/GetPos/GetDir Space: O(W+H)
public class Robot
{
    private bool isOrigin = true;
    private int i = 0;
    private List<(int[] Key, string Value)> pos = new List<(int[], string)>();

    public Robot(int width, int height)
    {
        pos.Add((new int[] { 0, 0 }, "South"));
        for (int i = 1; i < width; ++i)
            pos.Add((new int[] { i, 0 }, "East"));
        for (int j = 1; j < height; ++j)
            pos.Add((new int[] { width - 1, j }, "North"));
        for (int i = width - 2; i >= 0; --i)
            pos.Add((new int[] { i, height - 1 }, "West"));
        for (int j = height - 2; j > 0; --j)
            pos.Add((new int[] { 0, j }, "South"));
    }

    public void Step(int num)
    {
        isOrigin = false;
        i = (i + num) % pos.Count;
    }

    public int[] GetPos()
    {
        return pos[i].Key;
    }

    public string GetDir()
    {
        return isOrigin ? "East" : pos[i].Value;
    }
}

/**
 * Your Robot object will be instantiated and called as such:
 * Robot obj = new Robot(width, height);
 * obj.Step(num);
 * int[] param_2 = obj.GetPos();
 * string param_3 = obj.GetDir();
 */