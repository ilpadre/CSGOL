using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOL;

namespace GOLTst
{
    [TestClass]
    public class ConwayGameOfLifeTests
    {
        [TestMethod]
        public void CanCreateGameBoard()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(1, 1),
                new Cell(1, 2)
            };
            gol.CreateBoard(listOfCells);
            gol.CreateBoard(listOfCells);
            Assert.IsInstanceOfType(gol.board, typeof(GOLBoard));
        }

        [TestMethod]
        public void CanInitGameBoardFromInit()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(1, 1),
                new Cell(1, 2)
            };
            gol.CreateBoard(listOfCells);
            Assert.AreEqual(2, gol.board.Cells.Count);
        }

        [TestMethod]
        public void CanInitGameBoardFromCreate()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(1, 1),
                new Cell(1, 2)
            };
            gol.CreateBoard(listOfCells);
            Assert.AreEqual(2, gol.board.Cells.Count);
        }

        [TestMethod]
        public void FindZeroNeighborWhenThereAreZeroNeighbors()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(1, 1)
            };
            gol.CreateBoard(listOfCells);
            int numNeighbors = gol.board.GetNumberOfLiveNeighbors(gol.board.Cells[0]);
            Assert.AreEqual(0, numNeighbors);
        }

        [TestMethod]
        public void FindOneNeighborWhenThereIsOneNeighbor()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(1, 1),
                new Cell(1, 2)
            };
            gol.CreateBoard(listOfCells);
            foreach (Cell c in listOfCells)
            {
                int numNeighbors = gol.board.GetNumberOfLiveNeighbors(c);
                Assert.AreEqual(1, numNeighbors);
            }

        }

        [TestMethod]
        public void FindNoNeighborWhenThereIsNoNeighbor()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(0, 0),
                new Cell(2, 2)
            };
            gol.CreateBoard(listOfCells);
            foreach (Cell c in listOfCells)
            {
                int numNeighbors = gol.board.GetNumberOfLiveNeighbors(c);
                Assert.AreEqual(0, numNeighbors);
            }
        }

        [TestMethod]
        public void FindNoNeighborsWhenThereAreLotsOfCells()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(0, 0),
                new Cell(2, 0),
                new Cell(4, 0),
                new Cell(6, 0),
                new Cell(8, 0),
                new Cell(1, 2),
                new Cell(3, 2),
                new Cell(5, 2),
                new Cell(7, 2),
                new Cell(1, 4),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            foreach (Cell c in listOfCells)
            {
                int numNeighbors = gol.board.GetNumberOfLiveNeighbors(c);
                Assert.AreEqual(0, numNeighbors);
            }
        }

        [TestMethod]
        public void FindTwoNeighborsWhenThereAreLotsOfCells()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(0, 0),
                new Cell(2, 0),
                new Cell(4, 0),
                new Cell(6, 0),
                new Cell(8, 0),
                new Cell(7, 1),
                new Cell(7, 2),
                new Cell(8, 1),
                new Cell(7, 2),
                new Cell(1, 4),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(8, 0);
            int numNeighbors = gol.board.GetNumberOfLiveNeighbors(c);
            Assert.AreEqual(2, numNeighbors);

        }

        [TestMethod]
        public void FindEightNeighborsWhenThereAreLotsOfCells()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(1, 3),
                new Cell(2, 1),
                new Cell(2, 2),
                new Cell(2, 3),
                new Cell(3, 1),
                new Cell(3, 2),
                new Cell(3, 3),
                new Cell(1, 4),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(2, 2);
            int numNeighbors = gol.board.GetNumberOfLiveNeighbors(c);
            Assert.AreEqual(8, numNeighbors);

        }

        [TestMethod]
        public void FindThreeNeighborsWhenTopLeftCornerCell()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(0, 2),
                new Cell(1, 0),
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(2, 1),
                new Cell(2, 2),
                new Cell(2, 3),
                new Cell(1, 4),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(0, 0);
            int numNeighbors = gol.board.GetNumberOfLiveNeighbors(c);
            Assert.AreEqual(3, numNeighbors);
        }

        [TestMethod]
        public void FindThreeNeighborsWhenTopRightCornerCell()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(0, 8),
                new Cell(0, 7),
                new Cell(1, 7),
                new Cell(1, 8),
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(2, 1),
                new Cell(2, 2),
                new Cell(2, 3),
                new Cell(1, 4),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(0, 8);
            int numNeighbors = gol.board.GetNumberOfLiveNeighbors(c);
            Assert.AreEqual(3, numNeighbors);
        }

        [TestMethod]
        public void FindThreeNeighborsWhenBottomLeftCornerCell()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(8, 0),
                new Cell(7, 0),
                new Cell(7, 1),
                new Cell(8, 1),
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(2, 1),
                new Cell(2, 2),
                new Cell(2, 3),
                new Cell(1, 4),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(8, 0);
            int numNeighbors = gol.board.GetNumberOfLiveNeighbors(c);
            Assert.AreEqual(3, numNeighbors);
        }

        [TestMethod]
        public void FindThreeNeighborsWhenBottomRightCornerCell()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(8, 0),
                new Cell(7, 0),
                new Cell(7, 1),
                new Cell(8, 1),
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(2, 1),
                new Cell(7, 7),
                new Cell(7, 8),
                new Cell(8, 7),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(8, 8);
            int numNeighbors = gol.board.GetNumberOfLiveNeighbors(c);
            Assert.AreEqual(3, numNeighbors);
        }

        [TestMethod]
        public void FindFiveNeighborsWhenSideCell()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(3, 7),
                new Cell(3, 8),
                new Cell(4, 7),
                new Cell(4, 8),
                new Cell(5, 7),
                new Cell(5, 8),
                new Cell(2, 1),
                new Cell(7, 7),
                new Cell(7, 8),
                new Cell(8, 7),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(4, 8);
            int numNeighbors = gol.board.GetNumberOfLiveNeighbors(c);
            Assert.AreEqual(5, numNeighbors);
        }

        [TestMethod]
        public void FindFourNeighborsWhenSideCellAndOneMissing()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(3, 0),
                new Cell(3, 8),
                new Cell(4, 7),
                new Cell(4, 8),
                new Cell(5, 7),
                new Cell(5, 8),
                new Cell(2, 1),
                new Cell(7, 7),
                new Cell(7, 8),
                new Cell(8, 7),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(4, 8);
            int numNeighbors = gol.board.GetNumberOfLiveNeighbors(c);
            Assert.AreEqual(4, numNeighbors);
        }

        [TestMethod]
        public void LiveCellWithOnlyOneLiveNeighborsBitesIt()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(3, 0),
                new Cell(3, 8),
                new Cell(4, 4),
                new Cell(5, 4),
                new Cell(5, 8),
                new Cell(2, 1),
                new Cell(7, 7),
                new Cell(7, 8),
                new Cell(8, 7),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(5, 4);
            var cellShouldLive = gol.board.ShouldCellLive(c);
            Assert.IsFalse(cellShouldLive);
        }

        [TestMethod]
        public void LiveCellWithNoLiveNeighborsBitesIt()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(3, 0),
                new Cell(3, 8),
                new Cell(5, 4),
                new Cell(5, 8),
                new Cell(2, 1),
                new Cell(7, 7),
                new Cell(7, 8),
                new Cell(8, 7),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(5, 4);
            var cellShouldLive = gol.board.ShouldCellLive(c);
            Assert.IsFalse(cellShouldLive);
        }

        [TestMethod]
        public void LiveCellWithThreeLiveNeighborsCarriesOn()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(3, 0),
                new Cell(3, 8),
                new Cell(4, 4),
                new Cell(4, 5),
                new Cell(5, 4),
                new Cell(5, 5),
                new Cell(2, 1),
                new Cell(7, 7),
                new Cell(7, 8),
                new Cell(8, 7),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(5, 4);
            var cellShouldLive = gol.board.ShouldCellLive(c);
            Assert.IsTrue(cellShouldLive);
        }

        [TestMethod]
        public void LiveCellWithTwoLiveNeighborsCarriesOn()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(3, 0),
                new Cell(3, 8),
                new Cell(4, 5),
                new Cell(5, 4),
                new Cell(5, 5),
                new Cell(2, 1),
                new Cell(7, 7),
                new Cell(7, 8),
                new Cell(8, 7),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(5, 4);
            var cellShouldLive = gol.board.ShouldCellLive(c);
            Assert.IsTrue(cellShouldLive);
        }

        [TestMethod]
        public void LiveCellWithMoreThanThreeLiveNeighborsBitesIt()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(3, 0),
                new Cell(3, 8),
                new Cell(4, 3),
                new Cell(4, 4),
                new Cell(4, 5),
                new Cell(5, 4),
                new Cell(5, 5),
                new Cell(2, 1),
                new Cell(7, 7),
                new Cell(7, 8),
                new Cell(8, 7),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(5, 4);
            var cellShouldLive = gol.board.ShouldCellLive(c);
            Assert.IsFalse(cellShouldLive);
        }

        [TestMethod]
        public void DeadCellWithoutThreeLiveNeighborsStaysDead()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(3, 0),
                new Cell(3, 8),
                new Cell(4, 3),
                new Cell(4, 4),
                new Cell(4, 5),
                new Cell(5, 4),
                new Cell(5, 5),
                new Cell(2, 1),
                new Cell(7, 7),
                new Cell(7, 8),
                new Cell(8, 7),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            var c = new Cell(0, 0);
            var cellShouldStayDead = gol.board.CanThisCellBeResurrected(c);
            Assert.IsFalse(cellShouldStayDead);
        }

        [TestMethod]
        public void DeadCellWithThreeLiveNeighborsComesAlive()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
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
            var c = new Cell(5, 5);
            var cellShouldStayDead = gol.board.CanThisCellBeResurrected(c);
            Assert.IsTrue(cellShouldStayDead);
        }

        [TestMethod]
        public void NextGenerationStartingWithThree()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(3, 7),
                new Cell(3, 8),
                new Cell(4, 8)
            };
            gol.CreateBoard(listOfCells);
            gol.board.NextGeneration();
            Assert.AreEqual(4, gol.board.Cells.Count);
        }

        [TestMethod]
        public void NextTwoGenerationsStartingWithThree()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(3, 7),
                new Cell(3, 8),
                new Cell(4, 8)
            };
            gol.CreateBoard(listOfCells);
            gol.board.NextGeneration();
            gol.board.NextGeneration();
            Assert.AreEqual(4, gol.board.Cells.Count);
        }

        [TestMethod]
        public void NoDupsAfterThreeGenerations()
        {
            var gol = new GameOfLife();
            var listOfCells = new List<Cell>()
            {
                new Cell(0, 0),
                new Cell(0, 2),
                new Cell(0, 4),
                new Cell(0, 6),
                new Cell(0, 8),
                new Cell(1, 1),
                new Cell(1, 3),
                new Cell(1, 5),
                new Cell(1, 8),
                new Cell(2, 1),
                new Cell(2, 3),
                new Cell(2, 5),
                new Cell(2, 7),
                new Cell(3, 0),
                new Cell(3, 2),
                new Cell(3, 4),
                new Cell(3, 6),
                new Cell(3, 8),
                new Cell(4, 0),
                new Cell(4, 1),
                new Cell(4, 2),
                new Cell(4, 4),
                new Cell(4, 5),
                new Cell(4, 7),
                new Cell(4, 8),
                new Cell(5, 1),
                new Cell(5, 4),
                new Cell(5, 6),
                new Cell(5, 8),
                new Cell(6, 0),
                new Cell(6, 1),
                new Cell(6, 3),
                new Cell(6, 4),
                new Cell(6, 5),
                new Cell(6, 6),
                new Cell(7, 0),
                new Cell(7, 1),
                new Cell(7, 3),
                new Cell(7, 4),
                new Cell(7, 5),
                new Cell(7, 6),
                new Cell(7, 8),
                new Cell(8, 0),
                new Cell(8, 2),
                new Cell(8, 3),
                new Cell(8, 5),
                new Cell(8, 6),
                new Cell(8, 8)
            };
            gol.CreateBoard(listOfCells);
            gol.board.NextGeneration();
            gol.board.NextGeneration();
            gol.board.NextGeneration();
            gol.board.NextGeneration();
            gol.board.NextGeneration();
            bool hasDups = gol.board.Cells.Count != gol.board.Cells.Distinct().Count();
            Assert.IsFalse(hasDups);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Board dimensions are too small")]
        public void BoardDimensionsTooSmallXY()
        {
            var gol = new GameOfLife();
            gol.CreateBoard(6,6);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Board dimensions are too small")]
        public void BoardDimensionsTooSmallX()
        {
            var gol = new GameOfLife();
            gol.CreateBoard(6, 9);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Board dimensions are too small")]
        public void BoardDimensionsTooSmallY()
        {
            var gol = new GameOfLife();
            gol.CreateBoard(9, 6);
        }
    }
}
