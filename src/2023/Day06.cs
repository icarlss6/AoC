using System.Text.RegularExpressions;
using TimeDistance = (int time, int distance);

public class Day06(string[] input)
{
    private readonly List<TimeDistance> RaceData = [];

    public int RunA()
    {
        ParseInput(input);
        // int minSpeed =
        int result = 1;

        foreach (var race in RaceData)
        {
            result *= GetNrOfWaysToBeatRecord(race.time, race.distance);
        }
        return result;
    }

    internal int GetNrOfWaysToBeatRecord(int time, int distance)
    {
        int nrOfWays = 0;
        var range = Enumerable.Range(0, time);
        foreach (var holdTime in range)
        {
            var distanceForRange = GetDistanceTraveled(holdTime, time);
            if (distanceForRange > distance)
                nrOfWays++;
        }
        return nrOfWays;
    }

    internal void ParseInput(string[] input)
    {
        // Use regex to match digits
        MatchCollection matchesTime = Regex.Matches(input[0], @"\d+");
        MatchCollection matchesDistance = Regex.Matches(input[1], @"\d+");

        // Extract and print the digits
        for (int i = 0; i < matchesTime.Count; i++)
        {
            RaceData.Add((int.Parse(matchesTime[i].Value), int.Parse(matchesDistance[i].Value)));
        }
    }

    internal int GetDistanceTraveled(int holdTime, int totalTime) =>
        (totalTime - holdTime) * holdTime;
}
