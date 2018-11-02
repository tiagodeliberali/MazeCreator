using System.Collections.Generic;
using MazeBuilderGame;
using Xunit;

namespace maze.test
{
    public class MazeSolverTest
    {
        [Fact]
        public void ShouldReturnNoNeighborsIfNoDestroyedWalls()
        {
            MazeSolver solver = new MazeSolver(BuildMaze(3, 3));
            MazeSlot slot = new MazeSlot(1, 1);

            List<MazeSlot> moves = solver.NextMoves(slot);

            Assert.Empty(moves);
        }

        [Theory]
        [InlineData(1, 0, WallPosition.Down)]
        [InlineData(1, 2, WallPosition.Up)]
        [InlineData(0, 1, WallPosition.Left)]
        [InlineData(2, 1, WallPosition.Rigth)]
        public void ShouldReturnCorrectNeighbors(int x, int y, WallPosition expectedWall)
        {
            MazeSlot[,] maze = BuildMaze(3, 3);
            MazeSolver solver = new MazeSolver(maze);

            MazeSlot slot = new MazeSlot(1, 1);
            slot.DestroyWall(maze[x, y]);

            List<MazeSlot> moves = solver.NextMoves(slot);

            Assert.Single(moves);
            Assert.Contains(expectedWall, slot.DestroyedWalls);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(1, 2)]
        [InlineData(0, 1)]
        [InlineData(2, 1)]
        public void ShouldIgnoreVisitedNeighbors(int x, int y)
        {
            MazeSlot[,] maze = BuildMaze(3, 3);
            MazeSolver solver = new MazeSolver(maze);

            MazeSlot slot = new MazeSlot(1, 1);
            slot.DestroyWall(maze[x, y]);
            maze[x, y].VisitedBySolver = true;

            List<MazeSlot> moves = solver.NextMoves(slot);

            Assert.Empty(moves);
        }

        private MazeSlot[,] BuildMaze(int x, int y)
        {
            MazeBuilder builder = new MazeBuilder(x, y);
            return builder.Maze;
        }
    }
}
