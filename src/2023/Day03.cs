public class Day03
{
    private readonly char[,] board;
    private readonly string[] input;
    private readonly int colNr;
    private readonly int rowNr;

    public Day03(string[] input)
    {
        this.input = input;
        rowNr = input.Length;
        colNr = input[0].Length;
        board = InputTo2dArray(input);
    }

    public int RunA()
    {
        int totalSum = 0;
        string currentNr = "";
        bool hasAdjacent = false;

        for (int i = 0; i < rowNr; i++)
        {
            for (int j = 0; j < colNr; j++)
            {
                // new "context" to check caused by row change or not a digit
                if (j == 0 || !char.IsDigit(board[i, j]))
                {
                    if (hasAdjacent && !string.IsNullOrEmpty(currentNr))
                    {
                        totalSum += int.Parse(currentNr);
                    }
                    hasAdjacent = false;
                    currentNr = "";
                }

                // Add digit to current one
                if (char.IsDigit(board[i, j]))
                {
                    currentNr = currentNr + board[i, j].ToString();
                    if (!hasAdjacent)
                    {
                        hasAdjacent = CheckPositionsAround(i, j);
                    }
                }
            }
        }

        return totalSum;
    }

    // A gear is any * symbol that is adjacent to exactly two part numbers.
    // Store candidate list 
    // - * board position
    // - first number
    // - second number
    // delete if one more found?
    public int RunB()
    {
        int totalSum = 0;
        string currentNr = "";
        bool hasAdjacent = false;

        for (int i = 0; i < rowNr; i++)
        {
            for (int j = 0; j < colNr; j++)
            {
                // new "context" to check caused by row change or not a digit
                if (j == 0 || !char.IsDigit(board[i, j]))
                {
                    if (hasAdjacent && !string.IsNullOrEmpty(currentNr))
                    {
                        totalSum += int.Parse(currentNr);
                    }
                    hasAdjacent = false;
                    currentNr = "";
                }

                // Add digit to current one
                if (char.IsDigit(board[i, j]))
                {
                    currentNr = currentNr + board[i, j].ToString();
                    if (!hasAdjacent)
                    {
                        hasAdjacent = CheckPositionsAround(i, j);
                    }
                }
            }
        }

        return totalSum;
    }

    bool CheckPositionsAround(int x, int y)
    {
        return CheckPosition(x, y + 1)
            || CheckPosition(x + 1, y + 1)
            || CheckPosition(x + 1, y)
            || CheckPosition(x + 1, y - 1)
            || CheckPosition(x, y - 1)
            || CheckPosition(x - 1, y - 1)
            || CheckPosition(x - 1, y)
            || CheckPosition(x - 1, y + 1);
    }

    bool CheckPosition(int x, int y)
    {
        if (!IsValidPosition(x, y))
            return false;
        if (board[x, y] == '.' || char.IsDigit(board[x, y]))
            return false;

        return true;
    }

    internal bool IsValidPosition(int x, int y)
    {
        if (x < 0 || y < 0)
            return false;
        if (x > rowNr - 1)
            return false;
        if (y > colNr - 1)
            return false;
        return true;
    }

    internal char[,] InputTo2dArray(string[] input)
    {
        char[,] board = new char[rowNr, colNr];
        for (int i = 0; i < rowNr; i++)
        {
            for (int j = 0; j < colNr; j++)
            {
                board[i, j] = input[i][j];
            }
        }
        return board;
    }
}
