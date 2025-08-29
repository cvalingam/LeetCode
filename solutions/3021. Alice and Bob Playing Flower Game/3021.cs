public class Solution
{
    public long FlowerGame(int petals, int players)
    {
        // a1 represents half the petals, rounded up
        long upperHalfPetals = (petals + 1) / 2;
        // b1 represents half the players, rounded up
        long upperHalfPlayers = (players + 1) / 2;
        // a2 represents half the petals, rounded down
        long lowerHalfPetals = petals / 2;
        // b2 represents half the players, rounded down
        long lowerHalfPlayers = players / 2;

        // Return the sum of cross-products of upper and lower halves of petals and players
        // This probably follows some game rule logic based on the distribution of petals and players
        return upperHalfPetals * lowerHalfPlayers + lowerHalfPetals * upperHalfPlayers;
    }
}