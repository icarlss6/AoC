public class Day11(string[] input)
{
    // private readonly List<(int, int)> galaxyCoordinates = new();

    public int RunA()
    {
        var grid = ParseAndExpand();
        var galaxyCoordinates = FindHashCoordinates(grid);
        var combinationsToCheck = GetCombinations(galaxyCoordinates);

        var shortestPaths = combinationsToCheck.Select(
            c => GetShortestPathBetweenPoints(c.Item1, c.Item2)
        );

        return shortestPaths.Sum();
    }

    internal static List<(T, T)> GetCombinations<T>(List<T> list)
    {
        return list.SelectMany(
                (value1, index1) =>
                    list.Where((value2, index2) => index2 > index1)
                        .Select(value2 => (value1, value2))
            )
            .ToList();
    }

    internal static int GetShortestPathBetweenPoints((int, int) point1, (int, int) point2)
    {
        var diffY = Math.Abs(point1.Item1 - point2.Item1);
        var diffX = Math.Abs(point1.Item2 - point2.Item2);

        var diff1direction = Math.Abs(diffX - diffY);
        var diffDiagonal = Math.Max(diffX, diffY) - diff1direction;
        var shortestPath = diff1direction + 2 * diffDiagonal;
        return shortestPath;
    }

    internal List<(int, int)> FindHashCoordinates(List<List<char>> grid)
    {
        return grid.SelectMany((row, i) => row.Select((c, j) => (i, j, c)))
            .Where(t => t.c == '#')
            .Select(t => (t.i, t.j))
            .ToList();
    }

    internal List<List<char>> ParseAndExpand()
    {
        var parsed = input.Select(line => line.ToList()).ToList();

        int columnCount = parsed[0].Count;
        for (int i = 0; i < columnCount; i++)
        {
            if (parsed.All(row => row[i] == '.'))
            {
                foreach (var row in parsed)
                {
                    row.Insert(i + 1, '.');
                }
                i++; // Skip the newly added column
                columnCount++; // Increase the total column count
            }
        }

        int rowCount = parsed.Count;
        for (int i = 0; i < rowCount; i++)
        {
            if (parsed[i].All(c => c == '.'))
            {
                var newRow = new List<char>(parsed[i].Count);
                newRow.AddRange(Enumerable.Repeat('.', parsed[i].Count));
                parsed.Insert(i + 1, newRow);
                i++; // Skip the newly added row
                rowCount++; // Increase the total row count
            }
        }

        return parsed;
    }

    public int RunB()
    {
        return 1;
    }
}
