using System.Text.RegularExpressions;
using TimeDistance = (long time, long distance);
using TimeDistanceLong = (long time, long distance);

public class Day06(string[] input)
{
    private readonly List<TimeDistance> _raceDataA = [];
    private TimeDistanceLong RaceDataB;

    public long RunA()
    {
        ParseInputA(input);
        long result = 1;

        foreach (var race in _raceDataA)
        {
            result *= GetNrOfWaysToBeatRecord(race.time, race.distance);
        }
        return result;
    }

    public long RunB()
    {
        ParseInputB(input);

        return GetNrOfWaysToBeatRecord(RaceDataB.time, RaceDataB.distance);
    }

    internal long GetNrOfWaysToBeatRecord(long time, long distance)
    {
        long nrOfWays = 0;
        var range = CreateRange(0, time);
        foreach (var holdTime in range)
        {
            var distanceForRange = GetDistanceTraveled(holdTime, time);
            if (distanceForRange > distance)
                nrOfWays++;
        }
        return nrOfWays;
    }

    private IEnumerable<long> CreateRange(long start, long count)
    {
        var limit = start + count;

        while (start < limit)
        {
            yield return start;
            start++;
        }
    }

    internal void ParseInputA(string[] input)
    {
        // Use regex to match digits
        MatchCollection matchesTime = Regex.Matches(input[0], @"\d+");
        MatchCollection matchesDistance = Regex.Matches(input[1], @"\d+");

        // Extract the digits
        for (int i = 0; i < matchesTime.Count; i++)
        {
            _raceDataA.Add(
                (long.Parse(matchesTime[i].Value), long.Parse(matchesDistance[i].Value))
            );
        }
    }

    internal void ParseInputB(string[] input)
    {
        string timeString = string.Concat(
            input[0].Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries).Skip(1)
        );
        string distanceString = string.Concat(
            input[1].Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries).Skip(1)
        );

        RaceDataB = (long.Parse(timeString), long.Parse(distanceString));
    }

    internal long GetDistanceTraveled(long holdTime, long totalTime) =>
        (totalTime - holdTime) * holdTime;
}
