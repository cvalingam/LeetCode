public class Solution
{
    public string LargestNumber(int[] nums)
    {
        // Create a list of strings to store the numbers as strings
        List<string> stringNumbers = new List<string>();

        // Convert each integer in the array to a string and add it to the list
        foreach (int num in nums)
            stringNumbers.Add(num.ToString());

        // Sort the list using a custom comparator
        // The custom comparator defines the order based on the concatenation result
        // This ensures that the largest number is formed after sorting
        stringNumbers.Sort((str1, str2) => (str2 + str1).CompareTo(str1 + str2));

        // After sorting, if the largest number is "0", it means all numbers were zeros
        // In that case, return "0"
        if (stringNumbers[0] == "0")
            return "0";

        // Join all the strings in the list to get the final largest number representation
        return string.Join("", stringNumbers);
    }
}