public class Day08
{
    private readonly string[] input;
    private Dictionary<string, (string left, string right)> _network = [];
    private string _steps = "";

    public Day08(string[] input)
    {
        this.input = input;
        ParseInput(input);
    }

    public int RunA()
    {
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

    public long RunB()
    {
        var currentNodes = _network.Keys.Where(k => k.EndsWith('A')).ToList();
        int stepIndex = 0;
        int iterations = 0;
        var nodesRepeatInterval = new int[currentNodes.Count];

        // repeat until all nodes end with Z
        while (nodesRepeatInterval.Any(t => t == 0))
        {
            if (currentNodes.Any(n => n.EndsWith('Z')))
            {
                // find indices in currentnodes for nodes that end with Z
                var indices = currentNodes
                    .Select((n, i) => (n, i))
                    .Where(t => t.n.EndsWith('Z'))
                    .Select(t => t.i)
                    .ToList();
                foreach (var index in indices)
                {
                    // if the node has not been visited before, store the iteration count
                    if (nodesRepeatInterval[index] == 0)
                        nodesRepeatInterval[index] = iterations;
                }
            }

            var nextNodes = currentNodes.Select(n => GetNextNode(n, _steps[stepIndex])).ToList();
            stepIndex = (stepIndex + 1) % _steps.Length;

            currentNodes = nextNodes;
            iterations++;
        }

        long lcm = nodesRepeatInterval[0];

        for (int i = 1; i < nodesRepeatInterval.Length; i++)
        {
            lcm = LCM(lcm, nodesRepeatInterval[i]);
        }

        return lcm;
    }

    public static long LCM(long a, long b)
    {
        return a * b / GCD(a, b);
    }

    public static long GCD(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
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
