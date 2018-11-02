using System;

namespace MazeBuilderGame
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeBuilder builder = new MazeBuilder(4, 4);
            builder.BuildMaze(builder.maze[0, 0]);

            for (int x = 0; x < builder.maze.GetLength(0); x++)
            {
                for (int y = 0; y < builder.maze.GetLength(1); y++)
                {
                    if (!builder.maze[x, y].DestroyedWalls.Contains(WallPosition.Up))
                        Console.Write("___");
                }
                Console.WriteLine();
                for (int y = 0; y < builder.maze.GetLength(1); y++)
                {
                    if (!builder.maze[x, y].DestroyedWalls.Contains(WallPosition.Left))
                        Console.Write("| ");
                    else
                        Console.Write("  ");

                    if (!builder.maze[x, y].DestroyedWalls.Contains(WallPosition.Rigth))
                        Console.Write("|");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
                for (int y = 0; y < builder.maze.GetLength(1); y++)
                {
                    if (!builder.maze[x, y].DestroyedWalls.Contains(WallPosition.Down))
                        Console.Write("___");
                }
                Console.WriteLine();
            }
        }
    }
}
