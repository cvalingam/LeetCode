public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int columnCount = strs[0].Length;
        int rowCount = strs.Length;
        int deletionCount = 0;

        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            for (int rowIndex = 1; rowIndex < rowCount; rowIndex++)
            {
                if (strs[rowIndex][columnIndex] < strs[rowIndex - 1][columnIndex])
                {
                    deletionCount++;
                    break;
                }
            }
        }

        return deletionCount;
    }
}