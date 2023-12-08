public class Day08(string[] input)
{
    private Dictionary<string, (string left, string right)> _network = [];
    private string _steps = "";

    public int RunA()
    {
        ParseInput(input);

        var currentNode = "AAA";
        int stepIndex = 0;
        int iterations = 0;

        while (currentNode != "ZZZ")
        {
            var nextNode = GetNextNode(currentNode, _steps[stepIndex]);
            stepIndex = (stepIndex + 1) % _steps.Length;

            currentNode = nextNode;
            iterations++;
        }

        return iterations;
    }

    public int RunB()
    {
        var currentNodes = _network.Keys.Where(k => k.StartsWith('A')).ToList();
        int stepIndex = 0;
        int iterations = 0;

        while (currentNodes.All(n => n.EndsWith('Z')))
        {
            var nextNodes = currentNodes.Select(n => GetNextNode(n, _steps[stepIndex])).ToList();
            stepIndex = (stepIndex + 1) % _steps.Length;

            currentNodes = nextNodes;
            iterations++;
        }

        return iterations;
    }

    private string GetNextNode(string key, char direction)
    {
        if (direction == 'L')
        {
            return _network[key].left;
        }
        else if (direction == 'R')
        {
            return _network[key].right;
        }
        else
        {
            throw new Exception("Invalid direction");
        }
    }

    private void ParseInput(string[] input)
    {
        _steps = input[0].Trim();

        foreach (var line in input)
        {
            var parts = line.Split(new[] { '=', ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 3)
            {
                var key = parts[0].Trim();
                var value1 = parts[1].Trim().Trim('(', ')');
                var value2 = parts[2].Trim().Trim('(', ')');

                _network[key] = (value1, value2);
            }
        }
    }
}
