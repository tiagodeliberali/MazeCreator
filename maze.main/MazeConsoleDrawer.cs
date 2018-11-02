using System;

namespace MazeBuilderGame
{
    public class MazeConsoleDrawer
    {
        private static string[] TOP_CORNERS = new string[] { "╔", "╗", "╝", "╚" };
        private static string[] BOTTON_CORNERS = new string[] { "╚", "╝", "╗", "╔" };

        public static void DrawMaze(MazeSlot[,] maze)
        {
            for (int y = maze.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    DrawHorizontal(maze, y, x, WallPosition.Up);
                }
                Console.WriteLine();

                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    DrawVertical(maze, y, x);
                }
                Console.WriteLine();

                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    DrawHorizontal(maze, y, x, WallPosition.Down);
                }
                Console.WriteLine();
            }
        }

        private static void DrawVertical(MazeSlot[,] maze, int y, int x)
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

        private static void DrawHorizontal(MazeSlot[,] maze, int y, int x, WallPosition wall)
        {
            string[] corners = wall == WallPosition.Up ? TOP_CORNERS : BOTTON_CORNERS;

            if (!maze[x, y].DestroyedWalls.Contains(wall))
            {
                if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Left)) Console.Write(corners[0]);
                else Console.Write("═");

                Console.Write("═══");

                if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Rigth)) Console.Write(corners[1]);
                else Console.Write("═");
            }
            else
            {
                if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Left)) Console.Write("║");
                else Console.Write(corners[2]);

                Console.Write("   ");

                if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Rigth)) Console.Write("║");
                else Console.Write(corners[3]);
            }
        }
    }
}
