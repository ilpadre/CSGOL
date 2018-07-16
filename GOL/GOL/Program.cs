using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var gol = new GameOfLife();
            List<Cell> listOfCells = null;

            Console.WriteLine("Run 1: Empty Pattern");
            gol.CreateBoard(new List<Cell>());
            gol.RunWithPrompt();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Run 2: Default Pattern");
            gol.CreateBoard();
            gol.RunWithPrompt();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Run 3: Pattern Passed In");
            listOfCells = new List<Cell>()
            {
                new Cell(3, 0),
                new Cell(3, 8),
                new Cell(4, 3),
                new Cell(4, 4),
                new Cell(4, 5),
                new Cell(5, 4),
                new Cell(2, 1),
                new Cell(7, 7),
                new Cell(7, 8),
                new Cell(8, 7),
                new Cell(8, 8)
            };
                        
            gol.CreateBoard(listOfCells);
            gol.RunWithPrompt();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Run 4: Pattern Passed In With Larger Board");
            listOfCells = new List<Cell>()
            {
                new Cell(3, 0),
                new Cell(3, 8),
                new Cell(4, 3),
                new Cell(4, 4),
                new Cell(4, 5),
                new Cell(5, 4),
                new Cell(2, 1),
                new Cell(16, 16),
                new Cell(16, 17),
                new Cell(17, 16),
                new Cell(17, 17)
            };
            
            gol.CreateBoard(listOfCells, 18,18);
            gol.RunWithPrompt();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Run 5: Triomino Pattern");
            var triomino3 = new List<Cell>()
            {
                new Cell(3, 1),
                new Cell(3, 2),
                new Cell(4, 1),
            };
            gol.CreateBoard(triomino3);
            gol.RunWithPrompt();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Run 6: Glider Pattern With Large Board");
            Console.WriteLine("Will run continuously--press enter to continue, ctrl-c to exit.");
            Console.ReadLine();
            var glider = new List<Cell>()
                        {
                            new Cell(24, 24),
                            new Cell(24, 25),
                            new Cell(24, 26),
                            new Cell(25, 24),
                            new Cell(26, 25)
                        };
            gol.board = new GOLBoard(glider, 18, 18);
            gol.RunWithPrompt();
        }
    }
}
