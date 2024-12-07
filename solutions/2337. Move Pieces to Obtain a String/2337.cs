public class Solution
{
    public bool CanChange(string start, string target)
    {
        int length = start.Length;
        int startIndex = 0; // start's index
        int targetIndex = 0; // target's index

        while (startIndex <= length && targetIndex <= length)
        {
            while (startIndex < length && start[startIndex] == '_')
                ++startIndex;
            while (targetIndex < length && target[targetIndex] == '_')
                ++targetIndex;
            if (startIndex == length || targetIndex == length)
                return startIndex == length && targetIndex == length;
            if (start[startIndex] != target[targetIndex])
                return false;
            if (start[startIndex] == 'R' && startIndex > targetIndex)
                return false;
            if (start[startIndex] == 'L' && startIndex < targetIndex)
                return false;
            ++startIndex;
            ++targetIndex;
        }

        return true;
    }
}