public class Day16
{
    private readonly char[,] _visitedBoard;
    private HashSet<(int, int)> _visited = [];
    private readonly List<BeamState> _beamStates = [];
    private readonly char[][] Board;

    public Day16(string[] input)
    {
        Board = input.Select(x => x.ToArray()).ToArray();
        _visitedBoard = new char[Board.Length, Board[0].Length];
    }

    public int RunA()
    {
        var initialState = new BeamState((0, 0), Direction.Right);
        _beamStates.Add(initialState);
        int i = 0;
        int lastCount = 0;
        bool isIncreasing = true;

        while (_beamStates.Any(bs => IsInsideBoard(bs)) && isIncreasing)
        {
            List<BeamState> newBeams = [];
            foreach (var beamState in _beamStates)
            {
                if (IsInsideBoard(beamState))
                {
                    _visited.Add(beamState.Position);
                    _visitedBoard[beamState.Position.Item1, beamState.Position.Item2] = '#';

                    var gridType = Board[beamState.Position.Item1][beamState.Position.Item2];

                    var newBeamCandidateDir = GetNewBeamDirection(beamState.Direction, gridType);
                    if (newBeamCandidateDir != Direction.None)
                    {
                        newBeams.Add(new BeamState(beamState.Position, newBeamCandidateDir));
                    }
                    beamState.Move(gridType);
                }
            }
            _beamStates.AddRange(newBeams);

            if (i % 10 == 0 && _visited.Count == lastCount)
                isIncreasing = false;
            if (i % 10 == 0)
                lastCount = _visited.Count;
            i++;
        }

        return _visited.Count();
    }

    private bool IsInsideBoard(BeamState bs) =>
        bs.Position.Item1 < Board.Length
        && bs.Position.Item1 >= 0
        && bs.Position.Item2 < Board[0].Length
        && bs.Position.Item2 >= 0;

    private Direction GetNewBeamDirection(Direction direction, char gridType) =>
        (direction, gridType) switch
        {
            (Direction.Right, '.') => Direction.None,
            (Direction.Down, '.') => Direction.None,
            (Direction.Left, '.') => Direction.None,
            (Direction.Up, '.') => Direction.None,

            (Direction.Up, '/') => Direction.None,
            (Direction.Up, '\\') => Direction.None,
            (Direction.Up, '|') => Direction.None,
            (Direction.Up, '-') => Direction.Right,

            (Direction.Right, '/') => Direction.None,
            (Direction.Right, '\\') => Direction.None,
            (Direction.Right, '|') => Direction.Down,
            (Direction.Right, '-') => Direction.None,

            (Direction.Down, '/') => Direction.None,
            (Direction.Down, '\\') => Direction.None,
            (Direction.Down, '|') => Direction.None,
            (Direction.Down, '-') => Direction.Right,

            (Direction.Left, '/') => Direction.None,
            (Direction.Left, '\\') => Direction.None,
            (Direction.Left, '|') => Direction.Down,
            (Direction.Left, '-') => Direction.None,

            (_, _) => throw new ArgumentException()
        };

    public int RunB()
    {
        return 1;
    }
}

internal class BeamState
{
    internal BeamState((int, int) position, Direction direction)
    {
        Position = position;
        Direction = direction;
    }

    public (int, int) Position { get; private set; }

    public Direction Direction { get; private set; }

    public void Move(char currentGridSymbol)
    {
        var newDirection = GetNextDirection(Direction, currentGridSymbol);
        var newPosition = GetNextPosition(newDirection, Position);
        Position = newPosition;
        Direction = newDirection;
    }

    private (int, int) GetNextPosition(Direction direction, (int, int) position) =>
        direction switch
        {
            Direction.Down => (position.Item1 + 1, position.Item2),
            Direction.Left => (position.Item1, position.Item2 - 1),
            Direction.Right => (position.Item1, position.Item2 + 1),
            Direction.Up => (position.Item1 - 1, position.Item2),
            Direction.None => throw new ArgumentException(),
            _ => throw new ArgumentException()
        };

    private Direction GetNextDirection(Direction direction, char gridType) =>
        (direction, gridType) switch
        {
            (Direction.Right, '.') => Direction.Right,
            (Direction.Down, '.') => Direction.Down,
            (Direction.Left, '.') => Direction.Left,
            (Direction.Up, '.') => Direction.Up,

            (Direction.Up, '/') => Direction.Right,
            (Direction.Up, '\\') => Direction.Left,
            (Direction.Up, '|') => Direction.Up,
            (Direction.Up, '-') => Direction.Left,

            (Direction.Right, '/') => Direction.Up,
            (Direction.Right, '\\') => Direction.Down,
            (Direction.Right, '|') => Direction.Up,
            (Direction.Right, '-') => Direction.Right,

            (Direction.Down, '/') => Direction.Left,
            (Direction.Down, '\\') => Direction.Right,
            (Direction.Down, '|') => Direction.Down,
            (Direction.Down, '-') => Direction.Left,

            (Direction.Left, '/') => Direction.Down,
            (Direction.Left, '\\') => Direction.Up,
            (Direction.Left, '|') => Direction.Up,
            (Direction.Left, '-') => Direction.Left,

            (_, _) => throw new ArgumentOutOfRangeException()
        };
}

internal enum Direction
{
    None,
    Right,
    Left,
    Up,
    Down,
}
