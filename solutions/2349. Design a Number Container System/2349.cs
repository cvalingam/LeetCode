public class NumberContainers
{
    private Dictionary<int, int> indexToNumber = new Dictionary<int, int>();
    private Dictionary<int, SortedSet<int>> numberToIndices = new Dictionary<int, SortedSet<int>>();

    public NumberContainers()
    {

    }

    public void Change(int index, int number)
    {
        if (indexToNumber.TryGetValue(index, out int originalNumber))
        {
            if (numberToIndices.TryGetValue(originalNumber, out SortedSet<int> indices))
            {
                indices.Remove(index);
                if (indices.Count == 0)
                    numberToIndices.Remove(originalNumber);
            }
        }

        if (!numberToIndices.ContainsKey(number))
            numberToIndices[number] = new SortedSet<int>();

        numberToIndices[number].Add(index);
        indexToNumber[index] = number;
    }

    public int Find(int number)
    {
        if (numberToIndices.TryGetValue(number, out SortedSet<int> indices))
        {
            foreach (int index in indices)
                return index;
        }
        return -1;
    }
}

/**
 * Your NumberContainers object will be instantiated and called as such:
 * NumberContainers obj = new NumberContainers();
 * obj.Change(index,number);
 * int param_2 = obj.Find(number);
 */