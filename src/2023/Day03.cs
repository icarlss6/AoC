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

    internal int RunA()
    {
        int totalSum = 0;
        // int currentNr = 0;
        string currentNr = "";
        bool hasAdjacent = false;
        // Check 8 positions
        for (int i = 0; i < rowNr; i++)
        {
            for (int j = 0; j < colNr; j++)
            {
                // om "context shift eller inte" - villkor för? antingen radbyte eller punkt?
                // antingen addera föregående contexts siffra om hade adjacencies
                // och skapa nytt context om det är siffra
                // eller lägg till siffran till strängen, parse:a samt kolla adjacencies
                //
                // Behöver kolla fallet ny rad + isdigit
                if (j == 0 || !char.IsDigit(board[i, j])) // new context
                {
                    if (hasAdjacent && !string.IsNullOrEmpty(currentNr))
                    {
                        totalSum += int.Parse(currentNr);
                    }
                    hasAdjacent = false;
                    currentNr = "";
                }

                // gäller oavsett context switch eller inte?
                // inte else if eftersom kan vara att i == 0
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

    // int AddFromThisPosition(int x, int y)
    // {
    //     if (board[x, y] == '.')
    //         if (board[x, y] == '.')
    //             return 0;
    // }

    bool CheckPositionsAround(int x, int y)
    {
        var aa = CheckPosition(x, y + 1);
        var a = CheckPosition(x + 1, y + 1);
        var b = CheckPosition(x + 1, y);
        var c = CheckPosition(x + 1, y - 1);
        var d = CheckPosition(x, y - 1);
        var e = CheckPosition(x - 1, y - 1);
        var f = CheckPosition(x - 1, y);
        var g = CheckPosition(x - 1, y + 1);

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
