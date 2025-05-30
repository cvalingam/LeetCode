public class Solution
{
    private int nodeCount; // Number of nodes in the graph
    private List<int>[] graph; // Adjacency list representation of the graph
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        nodeCount = edges.Length;
        graph = new List<int>[nodeCount];

        // Initialize graph adjacency lists
        for (int i = 0; i < nodeCount; i++)
            graph[i] = new List<int>();

        // Build the graph from edge list representation
        for (int i = 0; i < nodeCount; i++)
        {
            if (edges[i] != -1)
                graph[i].Add(edges[i]);
        }

        // Use Dijkstra's algorithm to find shortest paths from both starting nodes
        int[] distancesFromNode1 = Dijkstra(node1);
        int[] distancesFromNode2 = Dijkstra(node2);

        // Initialize the minimum distance and answer node index
        int minDistance = int.MaxValue;
        int closestNode = -1;

        // Iterate through nodes to find the closest meeting node
        for (int i = 0; i < nodeCount; i++)
        {
            int maxOfBothDistances = Math.Max(distancesFromNode1[i], distancesFromNode2[i]);
            if (maxOfBothDistances < minDistance)
            {
                minDistance = maxOfBothDistances;
                closestNode = i;
            }
        }
        return closestNode;
    }

    // Dijkstra's algorithm to find shortest path distances from a starting node 'startNode'
    private int[] Dijkstra(int startNode)
    {
        int[] distances = new int[nodeCount];

        // Initialize distances to a large number
        Array.Fill(distances, int.MaxValue);
        distances[startNode] = 0; // Distance to start node is zero

        // Priority queue to select the closest unvisited node in each step
        var priorityQueue = new SortedSet<(int distance, int node)>();
        priorityQueue.Add((0, startNode));

        while (priorityQueue.Count > 0)
        {
            var current = priorityQueue.Min;
            priorityQueue.Remove(current);
            int currentNode = current.node;

            // Explore neighbors and update distances
            foreach (int neighbor in graph[currentNode])
            {
                if (distances[neighbor] > distances[currentNode] + 1)
                {
                    if (distances[neighbor] != int.MaxValue)
                        priorityQueue.Remove((distances[neighbor], neighbor));
                    distances[neighbor] = distances[currentNode] + 1;
                    priorityQueue.Add((distances[neighbor], neighbor));
                }
            }
        }

        return distances; // Return array of distances from start node to all other nodes
    }
}