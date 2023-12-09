public class Day09(string[] input)
{
    public int RunA()
    {
        var parsed = input.Select(x => x.Split(" ").Select(x => int.Parse(x)).ToList()).ToList();

        int predictionsSum = 0;
        foreach (var line in parsed)
        {
            List<List<int>> prediction = [];
            prediction.Add(new List<int>(line));
            while (prediction.Last().Any(x => x != 0))
            {
                var lastLine = prediction.Last();
                var newLine = lastLine.Zip(lastLine.Skip(1), (a, b) => Math.Abs(a - b)).ToList();
                prediction.Add(newLine);
            }

            prediction.Last().Add(0);
            int newNumber = 0;
            for (int i = prediction.Count - 2; i >= 0; i--)
            {
                newNumber = prediction[i + 1].Last() + prediction[i].Last();
                prediction[i].Add(newNumber);
            }
            predictionsSum += newNumber;
        }
        return predictionsSum;
    }

    public int RunB()
    {
        return 1;
    }
}
