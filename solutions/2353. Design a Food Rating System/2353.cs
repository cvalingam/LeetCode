public class FoodRatings
{
    // Map from cuisine name to a sorted set of (rating, food) pairs
    private Dictionary<string, SortedSet<(int, string)>> cuisineToFoodSet = new Dictionary<string, SortedSet<(int, string)>>();

    // Map from food name to (rating, cuisine) pair for quick lookup
    private Dictionary<string, (int, string)> foodInfo = new Dictionary<string, (int, string)>();

    // Comparator for sorting foods by rating (descending) and name (ascending)
    private static readonly Comparison<(int, string)> foodComparator = (a, b) =>
    {
        // First compare by rating in descending order
        if (a.Item1 != b.Item1)
        {
            return b.Item1.CompareTo(a.Item1);
        }
        // If ratings are equal, compare by food name in ascending order
        return a.Item2.CompareTo(b.Item2);
    };

    /**
     * Initialize the food rating system with foods, their cuisines, and initial ratings
     * @param foods Array of food names
     * @param cuisines Array of cuisine types corresponding to each food
     * @param ratings Array of initial ratings corresponding to each food
     */
    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        for (int i = 0; i < foods.Length; i++)
        {
            string food = foods[i];
            string cuisine = cuisines[i];
            int rating = ratings[i];

            // Add food to the cuisine's sorted set
            if (!cuisineToFoodSet.ContainsKey(cuisine))
            {
                cuisineToFoodSet[cuisine] = new SortedSet<(int, string)>(Comparer<(int, string)>.Create(foodComparator));
            }
            cuisineToFoodSet[cuisine].Add((rating, food));

            // Store food information for quick lookup
            foodInfo[food] = (rating, cuisine);
        }
    }

    public void ChangeRating(string food, int newRating)
    {
        // Get current food information
        var currentInfo = foodInfo[food];
        int oldRating = currentInfo.Item1;
        string cuisine = currentInfo.Item2;

        // Update food information map with new rating
        foodInfo[food] = (newRating, cuisine);

        // Remove old entry from the cuisine's sorted set
        cuisineToFoodSet[cuisine].Remove((oldRating, food));

        // Add new entry with updated rating to the cuisine's sorted set
        cuisineToFoodSet[cuisine].Add((newRating, food));
    }

    public string HighestRated(string cuisine)
    {
        // Return the food name from the first element (highest rated) in the sorted set
        return cuisineToFoodSet[cuisine].Min.Item2;
    }
}

/**
 * Your FoodRatings object will be instantiated and called as such:
 * FoodRatings obj = new FoodRatings(foods, cuisines, ratings);
 * obj.ChangeRating(food,newRating);
 * string param_2 = obj.HighestRated(cuisine);
 */