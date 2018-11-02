using System;
using System.Collections.Generic;
using System.Text;
using MazeBuilderGame;
using Xunit;

namespace maze.test
{
    public class MazeBuilderTest
    {
        [Fact]
        public void SholdInitializeMazeArray()
        {
            MazeBuilder builder = new MazeBuilder(2, 2);

            for (int x = 0; x < builder.Maze.GetLength(0); x++)
                for (int y = 0; y < builder.Maze.GetLength(1); y++)
                {
                    Assert.NotNull(builder.Maze[x, y]);
                }
        }

        [Fact]
        public void ShouldReturnCorrectNeighborOnMiddle()
        {
            MazeBuilder builder = new MazeBuilder(3, 3);

            List<MazeSlot> neighbor = builder.GetNeighbor(builder.Maze[1, 1]);

            Assert.Equal(4, neighbor.Count);
        }

        [Fact]
        public void ShouldReturnCorrectNeighborOnCorner()
        {
            MazeBuilder builder = new MazeBuilder(3, 3);

            List<MazeSlot> neighbor = builder.GetNeighbor(builder.Maze[2, 2]);

            Assert.Equal(2, neighbor.Count);
        }

        [Fact]
        public void ShouldReturnCorrectNeighborOnSide()
        {
            MazeBuilder builder = new MazeBuilder(3, 3);

            List<MazeSlot> neighbor = builder.GetNeighbor(builder.Maze[2, 1]);

            Assert.Equal(3, neighbor.Count);
        }

        [Fact]
        public void ShouldIgnoreVisitedSlots()
        {
            MazeBuilder builder = new MazeBuilder(3, 3);
            builder.Maze[2, 0].Visited = true;
            builder.Maze[2, 2].Visited = true;

            List<MazeSlot> neighbor = builder.GetNeighbor(builder.Maze[2, 1]);

            Assert.Single(neighbor);
        }
    }
}
