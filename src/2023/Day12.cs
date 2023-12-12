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
        return combinations
            .Select(
                c => c.Split('.', StringSplitOptions.RemoveEmptyEntries).Select(d => d.Trim('.'))
            )
            .Where(
                x => x.Count() == records.Count && x.Select(y => y.Length).SequenceEqual(records)
            )
            .Count();
    }

    public void GenerateCombinations()
    {
        _conditionRecordsLeft.ForEach(
            record => _combinations.Add(GenerateCombinationsHelper(record))
        );
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
