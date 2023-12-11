public class Day09(string[] input)
{
    public long RunA()
    {
        var parsed = input.Select(x => x.Split(" ").Select(x => long.Parse(x)).ToList()).ToList();

        long predictionsSum = 0;
        foreach (var line in parsed)
        {
            List<List<long>> prediction = [];
            prediction.Add(new List<long>(line));
            while (prediction.Last().Any(x => x != 0))
            {
                var lastLine = prediction.Last();
                var newLine = lastLine.Zip(lastLine.Skip(1), (a, b) => (b - a)).ToList();
                prediction.Add(newLine);
            }

            prediction.Last().Add(0);
            long newNumber = 0;
            for (int i = prediction.Count - 2; i >= 0; i--)
            {
                newNumber = prediction[i + 1].Last() + prediction[i].Last();
                prediction[i].Add(newNumber);
            }
            predictionsSum += newNumber;
        }
        return predictionsSum;
    }

    public long RunB()
    {
        return 1;
    }
}
