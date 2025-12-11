public class Solution
{
    public int CountCoveredBuildings(int n, int[][] buildings)
    {
        // Dictionary to store all y-coordinates for each x-coordinate
        Dictionary<int, List<int>> buildingsAtX = new Dictionary<int, List<int>>();
        // Dictionary to store all x-coordinates for each y-coordinate
        Dictionary<int, List<int>> buildingsAtY = new Dictionary<int, List<int>>();

        // Group buildings by their x and y coordinates
        foreach (var building in buildings)
        {
            int xCoord = building[0];
            int yCoord = building[1];

            if (!buildingsAtX.ContainsKey(xCoord))
                buildingsAtX[xCoord] = new List<int>();
            buildingsAtX[xCoord].Add(yCoord);

            if (!buildingsAtY.ContainsKey(yCoord))
                buildingsAtY[yCoord] = new List<int>();
            buildingsAtY[yCoord].Add(xCoord);
        }

        // Sort all y-coordinates for each x to find min and max efficiently
        foreach (var entry in buildingsAtX.Values)
            entry.Sort();

        // Sort all x-coordinates for each y to find min and max efficiently
        foreach (var entry in buildingsAtY.Values)
            entry.Sort();

        int coveredBuildingCount = 0;

        // Check each building to see if it's covered
        foreach (var building in buildings)
        {
            int xCoord = building[0];
            int yCoord = building[1];

            // Get all buildings on the same vertical line (same x)
            List<int> buildingsOnSameX = buildingsAtX[xCoord];
            // Get all buildings on the same horizontal line (same y)
            List<int> buildingsOnSameY = buildingsAtY[yCoord];

            // Check if building is covered:
            // - There must be buildings to the left and right (on same horizontal line)
            // - There must be buildings above and below (on same vertical line)
            bool hasLeftBuilding = buildingsOnSameY[0] < xCoord;
            bool hasRightBuilding = xCoord < buildingsOnSameY[buildingsOnSameY.Count - 1];
            bool hasBelowBuilding = buildingsOnSameX[0] < yCoord;
            bool hasAboveBuilding = yCoord < buildingsOnSameX[buildingsOnSameX.Count - 1];

            if (hasLeftBuilding && hasRightBuilding && hasBelowBuilding && hasAboveBuilding)
                coveredBuildingCount++;
        }

        return coveredBuildingCount;
    }
}