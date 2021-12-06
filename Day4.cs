using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day4 : AdventBase
    {
        private class Position { public int Number; public bool Check; };

        public Day4() : base("64084", "12833")
        { }

        public override void RunPart1()
        {
            var inputList = InputLines.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

            var drawnNumbers = inputList.ElementAt(0).Split(',').Select(element => int.Parse(element));

            var boards = new List<Position[,]>();
            for (int i = 1; i < inputList.Count(); i += 5)
            {
                boards.Add(Get5x5Board(inputList.GetRange(i, 5)));
            }

            int winningNumber = 0;
            Position[,] winningBoard = null;
            foreach (var number in drawnNumbers)
            {
                MarkNumber(boards, number);

                if(CheckForWinner(boards, ref winningBoard))
                {
                    winningNumber = number;
                    break;
                }
            }

            var unmarkedSum = SumUnmarked(winningBoard);

            var result = winningNumber * unmarkedSum;

            PrintPart1Result(result);
        }

        public override void RunPart2()
        {
            var inputList = InputLines.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

            var drawnNumbers = inputList.ElementAt(0).Split(',').Select(element => int.Parse(element));

            var boards = new List<Position[,]>();
            for (int i = 1; i < inputList.Count(); i += 5)
            {
                boards.Add(Get5x5Board(inputList.GetRange(i, 5)));
            }

            int winningNumber = 0;
            foreach (var number in drawnNumbers)
            {
                MarkNumber(boards, number);

                var wonBoards = FindWonBoards(boards);

                if(boards.Count() == 1 && wonBoards.Count() == 1)
                {
                    winningNumber = number;
                    break;
                }

                foreach (var wonBoard in wonBoards)
                {
                    boards.Remove(wonBoard);
                }
            }

            var unmarkedSum = SumUnmarked(boards.ElementAt(0));

            var result = winningNumber * unmarkedSum;

            PrintPart2Result(result);
        }

        private Position[,] Get5x5Board(IEnumerable<string> boardInput)
        {
            var board = new Position[5, 5];

            int i = 0, j = 0;
            foreach (var row in boardInput)
            {
                j = 0;
                foreach (var element in row.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    board[i, j] = new Position() { Number = int.Parse(element)};
                    j++;
                }
                i++;
            }

            return board;
        }

        private void MarkNumber(List<Position[,]> boards, int number)
        {
            foreach (var board in boards)
            {
                foreach (var position in board)
                {
                    if(position.Number == number)
                        position.Check = true;
                }
            }
        }

        private bool CheckForWinner(IEnumerable<Position[,]> boards, ref Position[,] winningBoard)
        {
            foreach (var board in boards)
            {
                if (IsBingo(board))
                {
                    winningBoard = board;
                    return true;
                }
            }

            return false;
        }

        private List<Position[,]> FindWonBoards(IEnumerable<Position[,]> boards)
        {
            var wonBoards = new List<Position[,]>();

            foreach (var board in boards)
            {
                if (IsBingo(board))
                {
                    wonBoards.Add(board);
                }
            }

            return wonBoards;
        }

        private bool IsBingo(Position[,] board)
        {
            if (board.GetLength(0) != board.GetLength(1))
                throw new Exception("Board needs to have an equal dimensions length to check for bingo.");

            bool rowResult, columnResult;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                rowResult = columnResult = true;

                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (!board[i, j].Check)
                        rowResult = false;

                    if (!board[j, i].Check)
                        columnResult = false;

                    if (!rowResult && !columnResult)
                        break;
                }

                if (rowResult || columnResult)
                    return true;
            }

            return false;
        }

        private int SumUnmarked(Position[,] board)
        {
            int sum = 0;

            foreach (var position in board)
            {
                if (!position.Check)
                    sum += position.Number;
            }

            return sum;
        }
    }
}
