public class CustomStack
{
    private int maxSize;
    private Stack<int> stack = new Stack<int>();
    private List<int> pendingIncrements = new List<int>();
    public CustomStack(int maxSize)
    {
        this.maxSize = maxSize;
    }

    public void Push(int x)
    {
        if (stack.Count == maxSize)
            return;
        stack.Push(x);
        pendingIncrements.Add(0);
    }

    public int Pop()
    {
        if (stack.Count == 0)
            return -1;
        int i = stack.Count - 1;
        int pendingIncrement = pendingIncrements[i];
        pendingIncrements.RemoveAt(i);
        if (i > 0)
            pendingIncrements[i - 1] += pendingIncrement;
        return stack.Pop() + pendingIncrement;
    }

    public void Increment(int k, int val)
    {
        if (stack.Count == 0)
            return;
        int i = Math.Min(k - 1, stack.Count - 1);
        pendingIncrements[i] += val;
    }
}