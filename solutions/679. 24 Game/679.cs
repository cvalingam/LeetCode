public class Solution
{
    public bool JudgePoint24(int[] nums)
    {
        // Convert the input array of integers to a list of doubles.
        List<double> numList = nums.Select(n => (double)n).ToList();
        // Initiate depth-first search to evaluate all possible results.
        return Dfs(numList);
    }

    // Recursive method to perform depth-first search.
    private bool Dfs(List<double> numList)
    {
        // If there are no numbers, we cannot perform any operations; return false.
        if (numList.Count == 0)
            return false;
        // If there is only one number left, check if it's approximately 24.
        if (numList.Count == 1)
            return Math.Abs(numList[0] - 24.0) < 1e-6;
        // Try all pairs of numbers with all operations.
        for (int i = 0; i < numList.Count; i++)
        {
            for (int j = i + 1; j < numList.Count; j++)
            {
                // Check if the result of any operation on these two numbers
                // combined with the remaining numbers can result in 24.
                for (int operation = 0; operation < 6; operation++)
                {
                    List<double> nextList = GetNextList(numList, i, j, operation);
                    if (nextList.Count > 0 && Dfs(nextList))
                        return true;
                }
            }
        }
        // If no combination resulted in 24, return false.
        return false;
    }

    // Method to create a new list by applying an operation to a pair of numbers.
    private List<double> GetNextList(List<double> numList, int firstIndex, int secondIndex, int operation)
    {
        List<double> nextNumList = new List<double>();
        // Add all numbers except the pair we're operating on.
        for (int k = 0; k < numList.Count; k++)
        {
            if (k != firstIndex && k != secondIndex)
                nextNumList.Add(numList[k]);
        }

        // Perform the operation based on the operation index.
        switch (operation)
        {
            case 0: // Addition
                nextNumList.Add(numList[firstIndex] + numList[secondIndex]);
                break;
            case 1: // Subtraction (first - second)
                nextNumList.Add(numList[firstIndex] - numList[secondIndex]);
                break;
            case 2: // Subtraction (second - first)
                nextNumList.Add(numList[secondIndex] - numList[firstIndex]);
                break;
            case 3: // Multiplication
                nextNumList.Add(numList[firstIndex] * numList[secondIndex]);
                break;
            case 4: // Division (first / second), check for division by zero.
                if (numList[secondIndex] == 0)
                    return new List<double>();
                nextNumList.Add(numList[firstIndex] / numList[secondIndex]);
                break;
            case 5: // Division (second / first), check for division by zero.
                if (numList[firstIndex] == 0)
                    return new List<double>();
                nextNumList.Add(numList[secondIndex] / numList[firstIndex]);
                break;
        }

        // Return the new list of numbers to continue the search.
        return nextNumList;
    }
}