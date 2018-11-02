using System;
using System.Collections.Generic;

namespace MazeBuilderGame
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeSlot[,] maze = BuildMaze();
            // SolveMaze(maze);

            for (int y = maze.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Up))
                    {
                        if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Left)) Console.Write("╔");
                        else Console.Write("═");

                        Console.Write("═══");

                        if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Rigth)) Console.Write("╗");
                        else Console.Write("═");
                    }
                    else
                    {
                        if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Left)) Console.Write("║");
                        else Console.Write("╝");

                        Console.Write("   ");

                        if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Rigth)) Console.Write("║");
                        else Console.Write("╚");
                    }
                }
                Console.WriteLine();

                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Left))
                        Console.Write("║");
                    else
                        Console.Write(" ");

                    if (maze[x, y].SolutionPath)
                        Console.Write(" X ");
                    else
                        Console.Write("   ");

                    if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Rigth))
                        Console.Write("║");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();

                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Down))
                    {
                        if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Left)) Console.Write("╚");
                        else Console.Write("═");

                        Console.Write("═══");

                        if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Rigth)) Console.Write("╝");
                        else Console.Write("═");
                    }
                    else
                    {
                        if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Left)) Console.Write("║");
                        else Console.Write("╗");

                        Console.Write("   ");

                        if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Rigth)) Console.Write("║");
                        else Console.Write("╔");
                    }
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static MazeSlot[,] BuildMaze()
        {
            MazeBuilder builder = new MazeBuilder(30, 20);
            builder.BuildMaze(builder.Maze[0, 0]);
            return builder.Maze;
        }

        private static void SolveMaze(MazeSlot[,] maze)
        {
            MazeSolver solver = new MazeSolver();
            Stack<MazeSlot> solution = solver.Solve(maze, maze[0, 0], maze[maze.GetLength(0) - 1, maze.GetLength(1) - 1]);

            while (solution.Count > 0)
            {
                MazeSlot slot = solution.Pop();
                maze[slot.X, slot.Y].SolutionPath = true;
            }
        }
    }
}
