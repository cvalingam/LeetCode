public class Solution
{
    // Cache to store already computed results for expressions.
    private static Dictionary<string, List<int>> memoizationCache = new Dictionary<string, List<int>>();
    public IList<int> DiffWaysToCompute(string expression)
    {
        return ComputeAllPossibleResults(expression);
    }

    // Recursive function to compute all possible results from the input expression.
    private List<int> ComputeAllPossibleResults(string expression)
    {
        // Check if the result for this expression is cached.
        if (memoizationCache.ContainsKey(expression))
            return memoizationCache[expression];

        List<int> results = new List<int>();

        // Base case: if expression is a single number, return it as the only result.
        if (!expression.Contains("+") && !expression.Contains("-") && !expression.Contains("*"))
        {
            results.Add(int.Parse(expression));
            return results;
        }

        // Iterate through each character of the expression string.
        for (int i = 0; i < expression.Length; i++)
        {
            char operation = expression[i];
            // When an operator is found, divide the expression into two parts.
            if (operation == '-' || operation == '+' || operation == '*')
            {
                List<int> resultsLeft = ComputeAllPossibleResults(expression.Substring(0, i));
                List<int> resultsRight = ComputeAllPossibleResults(expression.Substring(i + 1));

                // Compute all combinations of results from left and right sub-expressions.
                foreach (int leftResult in resultsLeft)
                {
                    foreach (int rightResult in resultsRight)
                    {
                        if (operation == '-')
                            results.Add(leftResult - rightResult);
                        else if (operation == '+')
                            results.Add(leftResult + rightResult);
                        else if (operation == '*')
                            results.Add(leftResult * rightResult);
                    }
                }
            }
        }

        // Cache the computed results for the current expression.
        memoizationCache[expression] = results;

        // Return all the computed results.
        return results;
    }
}