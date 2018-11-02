using System;
using System.Collections.Generic;

namespace MazeBuilderGame
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                MazeSlot[,] maze = BuildMaze(30, 20);
                SolveMaze(maze);

                MazeConsoleDrawer.DrawMaze(maze);
            }
            while(Console.ReadLine() != "q");
        }

        private static MazeSlot[,] BuildMaze(int x, int y)
        {
            MazeBuilder builder = new MazeBuilder(x, y);
            builder.BuildMaze(builder.Maze[0, 0]);
            return builder.Maze;
        }

        private static void SolveMaze(MazeSlot[,] maze)
        {
            try
            {
                MazeSolver solver = new MazeSolver(maze);
                Stack<MazeSlot> solution = solver.Solve(maze[0, 0], maze[maze.GetLength(0) - 1, maze.GetLength(1) - 1]);

                while (solution.Count > 0)
                {
                    MazeSlot slot = solution.Pop();
                    maze[slot.X, slot.Y].SolutionPath = true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine("Não achei uma solução para esse labirinto");
            }
        }
    }
}
