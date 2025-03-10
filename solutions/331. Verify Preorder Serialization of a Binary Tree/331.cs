public class Solution
{
    public bool IsValidSerialization(string preorder)
    {
        int degree = 1; // out-degree (children) - in-degree (parent)

        foreach (var node in preorder.Split(','))
        {
            if (--degree < 0) // One parent
                return false;
            if (node != "#")
                degree += 2; // Two children
        }

        return degree == 0;
    }
}