public class Solution
{
    public string[] DivideString(string input, int partitionSize, char fillCharacter)
    {
        // Determine the length of the input string.
        int inputLength = input.Length;

        // Calculate the required number of partitions.
        int totalPartitions = (inputLength + partitionSize - 1) / partitionSize;

        // Initialize the answer array with the calculated size.
        string[] partitions = new string[totalPartitions];

        // If the input string is not a multiple of partition size, append fill characters to make it so.
        if (inputLength % partitionSize != 0)
            input += new string(fillCharacter, partitionSize - inputLength % partitionSize);

        // Loop through each partition, filling the partitions array with substrings of the correct size.
        for (int i = 0; i < partitions.Length; ++i)
        {
            // Calculate the start and end indices for the substring.
            int start = i * partitionSize;
            int end = (i + 1) * partitionSize;

            // Extract the substring for the current partition and assign it to the partitions array.
            partitions[i] = input.Substring(start, partitionSize);
        }

        // Return the final array of partitions.
        return partitions;
    }
}