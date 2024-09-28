public class MyCircularDeque
{
    private readonly int k;
    private int[] q;
    private int size = 0;
    private int front = 0;
    private int rear;

    /** Initialize your data structure here. Set the size of the deque to be k. */
    public MyCircularDeque(int k)
    {
        this.k = k;
        this.q = new int[k];
        this.rear = k - 1;
    }

    /** Adds an item at the front of Deque. Return true if the operation is successful. */
    public bool InsertFront(int value)
    {
        if (IsFull())
            return false;

        front = (--front + k) % k;
        q[front] = value;
        ++size;
        return true;
    }

    /** Adds an item at the rear of Deque. Return true if the operation is successful. */
    public bool InsertLast(int value)
    {
        if (IsFull())
            return false;

        rear = ++rear % k;
        q[rear] = value;
        ++size;
        return true;
    }

    /** Deletes an item from the front of Deque. Return true if the operation is successful. */
    public bool DeleteFront()
    {
        if (IsEmpty())
            return false;

        front = ++front % k;
        --size;
        return true;
    }

    /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
    public bool DeleteLast()
    {
        if (IsEmpty())
            return false;

        rear = (--rear + k) % k;
        --size;
        return true;
    }

    /** Get the front item from the deque. */
    public int GetFront()
    {
        return IsEmpty() ? -1 : q[front];
    }

    /** Get the last item from the deque. */
    public int GetRear()
    {
        return IsEmpty() ? -1 : q[rear];
    }

    /** Checks whether the circular deque is empty or not. */
    public bool IsEmpty()
    {
        return size == 0;
    }

    /** Checks whether the circular deque is full or not. */
    public bool IsFull()
    {
        return size == k;
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */