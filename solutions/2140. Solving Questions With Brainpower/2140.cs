public class Solution
{
    private int numQuestions; // Total number of questions
    public long MostPoints(int[][] questions)
    {
        numQuestions = questions.Length; // Initialize number of questions
        long[] dp = new long[numQuestions]; // Initialize the cache array
        Array.Fill(dp, -1);
        return TopDown(0, dp, questions); // Start the depth-first search from the first question   
    }

    // Recursive method using Depth-First Search to calculate the maximum points
    private long TopDown(int index, long[] dp, int[][] questions)
    {
        if (index >= numQuestions) // Base case: if the index exceeds the number of questions
            return 0; // No more points can be earned, return 0

        if (dp[index] != -1)  // If the result for this index is already computed
            return dp[index]; // Return the cached result

        int points = questions[index][0]; // Points for the current question
        int bonus = questions[index][1]; // Bonus (number of questions to skip) for the current question

        // Recur in two scenarios: either answer the current question and jump over the bonus questions,
        // or move to the next question. Take the maximum of these two choices.
        return dp[index] = Math.Max(points + TopDown(index + bonus + 1, dp, questions), TopDown(index + 1, dp, questions));
    }
}