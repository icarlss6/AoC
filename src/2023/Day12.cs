public class Day12(string[] input)
{
    private readonly List<string> _conditionRecordsLeft = [];
    private readonly List<List<int>> _conditionRecordsRight = [];
    private readonly List<List<string>> _combinations = [];

    public int RunA()
    {
        ParseInput(input);
        GenerateCombinations();
        var validCombinations = GetValidCombinations();
        return validCombinations.Sum();
    }

    internal List<int> GetValidCombinations()
    {
        List<int> combinations = [];
        for (int i = 0; i < _conditionRecordsLeft.Count; i++)
        {
            combinations.Add(GetValidCombinations(_combinations[i], _conditionRecordsRight[i]));
        }
        return combinations;
    }

    private int GetValidCombinations(List<string> combinations, List<int> records)
    {
        var test = combinations.Select(
            c => c.Split('.', StringSplitOptions.RemoveEmptyEntries).Select(d => d.Trim('.'))
        );
        var matching = test.Where(x => x.Count() == records.Count);
        var matching2 = matching.Where(x => x.Select(y => y.Length).SequenceEqual(records));

        var combinationsCount = matching2.Count();

        return combinationsCount;
    }

    public void GenerateCombinations()
    {
        List<string> results = new List<string>();
        foreach (var record in _conditionRecordsLeft)
        {
            _combinations.Add(GenerateCombinationsHelper(new string(record)));
        }
    }

    private static List<string> GenerateCombinationsHelper(string input)
    {
        int index = input.IndexOf('?');
        if (index == -1)
        {
            return [input];
        }

        var resultWithHash = GenerateCombinationsHelper(input.Remove(index, 1).Insert(index, "#"));
        var resultWithDot = GenerateCombinationsHelper(input.Remove(index, 1).Insert(index, "."));

        resultWithHash.AddRange(resultWithDot);
        return resultWithHash;
    }

    internal void ParseInput(string[] input)
    {
        foreach (var line in input)
        {
            var left = line.Split(' ')[0];
            var right = line.Split(' ')[1].Split(',').Select(c => int.Parse(c)).ToList();

            _conditionRecordsLeft.Add(left);
            _conditionRecordsRight.Add(right);
        }
    }

    public int RunB()
    {
        return 1;
    }
}
