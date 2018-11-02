using System;

namespace MazeBuilderGame
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeBuilder builder = new MazeBuilder(10, 10);
            builder.BuildMaze(builder.Maze[0, 0]);

            for (int y = builder.Maze.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x < builder.Maze.GetLength(0); x++) 
                {
                    if (!builder.Maze[x, y].DestroyedWalls.Contains(WallPosition.Up))
                        Console.Write("╔═══╗");
                    else
                        Console.Write("╔   ╗");
                }
                Console.WriteLine();
                for (int x = 0; x < builder.Maze.GetLength(0); x++)
                {
                    if (!builder.Maze[x, y].DestroyedWalls.Contains(WallPosition.Left))
                        Console.Write("║   ");
                    else
                        Console.Write("    ");

                    if (!builder.Maze[x, y].DestroyedWalls.Contains(WallPosition.Rigth))
                        Console.Write("║");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
                for (int x = 0; x < builder.Maze.GetLength(0); x++)
                {
                    if (!builder.Maze[x, y].DestroyedWalls.Contains(WallPosition.Down))
                        Console.Write("╚═══╝");
                    else
                        Console.Write("╚   ╝");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
