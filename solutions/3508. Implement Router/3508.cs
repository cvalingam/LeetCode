public class Router
{
    private record Packet(int source, int destination, int timestamp) { }

    private class Timestamps
    {
        public int startIndex;
        public List<int> timestamps = new List<int>();
    }

    private static readonly int[] THERE_ARE_NO_PACKETS = new int[] { };
    private static readonly int PACKETS_NOT_FOUND_FOR_GIVEN_TIMESTAMP_RANGE = 0;

    private readonly int memoryLimit;
    private readonly Queue<Packet> packets;
    private readonly HashSet<Packet> quickAccessPackets;
    private readonly Dictionary<int, Timestamps> destinationToTimestamps;
    public Router(int memoryLimit)
    {
        this.memoryLimit = memoryLimit;
        packets = new Queue<Packet>();
        quickAccessPackets = new HashSet<Packet>();
        destinationToTimestamps = new Dictionary<int, Timestamps>();
    }

    public bool AddPacket(int source, int destination, int timestamp)
    {
        Packet packet = new Packet(source, destination, timestamp);

        if (quickAccessPackets.Contains(packet))
            return false;

        if (packets.Count == memoryLimit)
        {
            Packet toRemove = packets.Dequeue();
            quickAccessPackets.Remove(toRemove);
            ++destinationToTimestamps[toRemove.destination].startIndex;
        }

        packets.Enqueue(packet);
        quickAccessPackets.Add(packet);
        destinationToTimestamps.TryAdd(destination, new Timestamps());
        destinationToTimestamps[destination].timestamps.Add(timestamp);

        return true;
    }

    public int[] ForwardPacket()
    {
        if (packets.Count == 0)
            return THERE_ARE_NO_PACKETS;

        Packet toRemove = packets.Dequeue();
        quickAccessPackets.Remove(toRemove);
        ++destinationToTimestamps[toRemove.destination].startIndex;

        return new int[] { toRemove.source, toRemove.destination, toRemove.timestamp };
    }

    public int GetCount(int destination, int startTime, int endTime)
    {
        if (!destinationToTimestamps.ContainsKey(destination))
            return PACKETS_NOT_FOUND_FOR_GIVEN_TIMESTAMP_RANGE;

        List<int> timestamps = destinationToTimestamps[destination].timestamps;
        int startIndex = destinationToTimestamps[destination].startIndex;
        int endIndex = destinationToTimestamps[destination].timestamps.Count - 1;

        if (startIndex > endIndex
                || startIndex == timestamps.Count
                || timestamps[startIndex] > endTime
                || timestamps[endIndex] < startTime)
            return PACKETS_NOT_FOUND_FOR_GIVEN_TIMESTAMP_RANGE;

        while (startIndex < endIndex && timestamps[startIndex] < startTime)
            ++startIndex;

        while (endIndex > 0 && timestamps[endIndex] > endTime)
            --endIndex;

        return endIndex - startIndex + 1;
    }
}

/**
 * Your Router object will be instantiated and called as such:
 * Router obj = new Router(memoryLimit);
 * bool param_1 = obj.AddPacket(source,destination,timestamp);
 * int[] param_2 = obj.ForwardPacket();
 * int param_3 = obj.GetCount(destination,startTime,endTime);
 */