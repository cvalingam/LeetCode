public class Solution
{
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
    {
        int totalCandies = 0; // To keep track of the total number of candies collected
        int boxCount = status.Length; // Number of boxes
        bool[] boxHas = new bool[boxCount]; // Keeps track of whether we have access to a box
        bool[] boxOpened = new bool[boxCount]; // Keeps track of whether we've opened a box
        Queue<int> queue = new Queue<int>(); // Queue to process the boxes to be opened

        // Initialize by going through the initial boxes
        foreach (int boxIndex in initialBoxes)
        {
            boxHas[boxIndex] = true; // Mark that we have this box
            // If we can open it, add its candies and enqueue it for further processing
            if (status[boxIndex] == 1)
            {
                totalCandies += candies[boxIndex];
                boxOpened[boxIndex] = true;
                queue.Enqueue(boxIndex);
            }
        }

        // Process the queue while there are boxes to open
        while (queue.Count > 0)
        {
            int currentBoxIndex = queue.Dequeue(); // Take the next box from the queue

            // Process all keys in the current box
            foreach (int keyIndex in keys[currentBoxIndex])
            {
                status[keyIndex] = 1; // Change the status to open for the boxes for which we now have keys
                // If we have not opened the box and now found the key, add candies and enqueue it
                if (boxHas[keyIndex] && !boxOpened[keyIndex])
                {
                    totalCandies += candies[keyIndex];
                    boxOpened[keyIndex] = true;
                    queue.Enqueue(keyIndex);
                }
            }

            // Process all boxes contained inside the current box
            foreach (int containedBoxIndex in containedBoxes[currentBoxIndex])
            {
                boxHas[containedBoxIndex] = true; // Mark that we now have this box
                // If we can open it and haven't before, add candies and enqueue
                if (status[containedBoxIndex] == 1 && !boxOpened[containedBoxIndex])
                {
                    totalCandies += candies[containedBoxIndex];
                    boxOpened[containedBoxIndex] = true;
                    queue.Enqueue(containedBoxIndex);
                }
            }
        }

        // Return the total candies collected from all boxes we could open
        return totalCandies;
    }
}