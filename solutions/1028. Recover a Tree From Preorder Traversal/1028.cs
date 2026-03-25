// Approach: Single-pass with a depth counter; track current index i; at each position count leading dashes to determine depth, then recursively build left/right subtrees.
// Time: O(n) Space: O(n)

public class TreeNode

    public TreeNode RecoverFromPreorder(string traversal)
    {
        return RecoverFromPreorder(traversal, 0);
    }

    private TreeNode RecoverFromPreorder(string traversal, int depth)
    {
        int nDashes = 0;
        while (i + nDashes < traversal.Length && traversal[i + nDashes] == '-')
            nDashes++;

        if (nDashes != depth)
            return null;

        i += depth;
        int start = i;
        while (i < traversal.Length && char.IsDigit(traversal[i]))
            i++;

        return new TreeNode(int.Parse(traversal.Substring(start, i - start)),
                            RecoverFromPreorder(traversal, depth + 1),
                            RecoverFromPreorder(traversal, depth + 1));
    }
}