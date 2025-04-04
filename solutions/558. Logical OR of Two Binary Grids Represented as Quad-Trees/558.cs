// Definition for a QuadTree node.
public class Node
{
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() { }
    public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
    {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}

public class Solution
{
    public Node Intersect(Node quadTree1, Node quadTree2)
    {
        if (quadTree1.isLeaf)
            return quadTree1.val ? quadTree1 : quadTree2;
        if (quadTree2.isLeaf)
            return quadTree2.val ? quadTree2 : quadTree1;

        Node topLeft = Intersect(quadTree1.topLeft, quadTree2.topLeft);
        Node topRight = Intersect(quadTree1.topRight, quadTree2.topRight);
        Node bottomLeft = Intersect(quadTree1.bottomLeft, quadTree2.bottomLeft);
        Node bottomRight = Intersect(quadTree1.bottomRight, quadTree2.bottomRight);

        if (topLeft.val == topRight.val &&
            topLeft.val == bottomLeft.val &&
            topLeft.val == bottomRight.val &&
            topLeft.isLeaf && topRight.isLeaf &&
            bottomLeft.isLeaf && bottomRight.isLeaf)
            return new Node(topLeft.val, true);
        return new Node(false, false, topLeft, topRight, bottomLeft, bottomRight);
    }
}