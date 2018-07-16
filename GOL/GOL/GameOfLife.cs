using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//    Any live cell with fewer than two live neighbors dies, as if by under population.
//    Any live cell with two or three live neighbors lives on to the next generation.
//    Any live cell with more than three live neighbors dies, as if by overpopulation.
//    Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

namespace GOL
{
    public class GameOfLife
    {
        public GOLBoard board { get; set; }

        public GameOfLife()
        {
            board = new GOLBoard();
        }

        public void CreateBoard()
        {
            board = new GOLBoard();
        }

        public void CreateBoard(List<Cell> cells)
        {
            board = new GOLBoard(cells);
        }

        public void CreateBoard(int rows, int columns)
        {
            board = new GOLBoard(rows, columns);
        }

        public void CreateBoard(List<Cell> cells, int rows, int columns)
        {
            board = new GOLBoard(cells, rows, columns);
        }

        public void RunWithPrompt()
        {
            do
            {
              Run();
            } while (PromptForContinue());
        }

        public void RunContinuous()
        {
            do
            {
                Console.Clear();
                Run();
                Thread.Sleep(1000);
            } while (true);
        }

        public void Run()
        {
            board.Display();
            board.NextGeneration();
        }

        private bool PromptForContinue()
        {
            Console.WriteLine();
            Console.Write("Continue? (Y/N): ");
            string ch = Console.ReadLine().ToUpper();
            return (!string.IsNullOrEmpty(ch) &&  ch[0] == 'Y' );
        }
    }

    public class GOLBoard
    {
        private const string LiveCellDefaultChar = "X";
        private const string DeadCellDefaultChar = "-";
        private const string DimensionErrorMessage = "Board dimensions are too small";
        private const int DefaultNumberOfRows = 9;
        private const int DefaultNumberOfColumns = 9;
        private const int MinimumRows = 7;
        private const int MinimumColumns = 7;

       private List<Cell> defaultPattern = new List<Cell>()
        {
            new Cell(2, 3),
            new Cell(3, 3),
            new Cell(4, 3),
        };

        public List<Cell> Cells { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string LiveCellChar { get; set; }
        public string DeadCellChar { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
    

        public GOLBoard()
        {
            Rows = DefaultNumberOfRows;
            Columns = DefaultNumberOfColumns;
            LiveCellChar = LiveCellDefaultChar;
            DeadCellChar = DeadCellDefaultChar;
            Cells = new List<Cell>();
            Cells = defaultPattern;
        }

        public GOLBoard(List<Cell> cells) : this()
        {
            Cells = cells;
            VerifyDimensions();
        }

        public GOLBoard(int r, int c) : this()
        {
            Rows = r;
            Columns = c;
            VerifyDimensions();
        }

        public GOLBoard(List<Cell> cells, int r, int c) : this()
        {
            Rows = r;
            Columns = c;
            Cells = cells;
            VerifyDimensions();
        }

        public int GetNumberOfLiveNeighbors(Cell cell)
        {
            int numNeighbors = 0;
            foreach (Cell c in Cells)
            {
                if (cell.XCoord != c.XCoord || cell.YCoord != c.YCoord)
                {
                    if (IsNeighbor(cell, c))
                    {
                        numNeighbors += 1;
                    }
                }
            }

            return numNeighbors;
        }

        public bool IsNeighbor(Cell thisCell, Cell thatCell)
        {
            if (Math.Abs(thisCell.XCoord - thatCell.XCoord) <= 1
                && Math.Abs(thisCell.YCoord - thatCell.YCoord) <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ShouldCellLive(Cell c)
        {
            var numNeighbors = GetNumberOfLiveNeighbors(c);

            //   Rule 1: Any live cell with fewer than two live neighbors dies, as if by under population.
            if (numNeighbors < 2)
            {
                return false;
            }
            //    Rule 3: Any live cell with more than three live neighbors dies, as if by overpopulation.
            else if (numNeighbors > 3)
            {
                return false;
            }
            //    Rule 2: Any live cell with two or three live neighbors lives on to the next generation.
            return true;
        }

        public bool CanThisCellBeResurrected(Cell c)
        {
            var numNeighbors = GetNumberOfLiveNeighbors(c);
            if (numNeighbors == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanThisCellBeResurrected(int x, int y)
        {
            return CanThisCellBeResurrected(new Cell(x, y));
        }

        public void Display()
        {
            for (int i = 0; i < Rows; i++ )
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (IsAlive(i, j))
                    {
                        Console.Write($"{LiveCellChar}");
                    }
                    else
                    {
                        Console.Write($"{DeadCellChar}");
                    }
                }
                Console.WriteLine();
            }
        }

        private bool IsAlive(int x, int y)
        {
            bool isAlive = false;
            foreach (Cell c in Cells)
            {
                if (c.XCoord == x && c.YCoord == y)
                {
                    isAlive = true;
                }
            }

            return isAlive;
        }

        public void NextGeneration()
        {
            var nextGenList = new List<Cell>();
            foreach (Cell c in Cells)
            {
                if (ShouldCellLive(c))
                {
                    nextGenList.Add(c);
                }
            }

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (!Cells.Any(c=>c.XCoord == i && c.YCoord == j))
                    {
                        if (CanThisCellBeResurrected(i, j))
                        {
                            nextGenList.Add(new Cell(i, j));
                        }
                    }
                }
            }

            Cells.RemoveAll(c=>c!=null);
            Cells = null;
            Cells = nextGenList;
        }

        private void VerifyDimensions()
        {
            try
            {
                if (Rows < MinimumRows || Columns < MinimumColumns)
                {
                    throw new Exception(DimensionErrorMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

    }

    public class Cell
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }

        public Cell(int x, int y)
        {
            XCoord = x;
            YCoord = y;
        }
    }
}



    

