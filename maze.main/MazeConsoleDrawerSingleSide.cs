using System;

namespace MazeBuilderGame
{
    public class MazeConsoleDrawerSingleSide
    {
        string WALL = "▒";
        string FLOOR = "▓";

        string[,] screen;

        int xSize;
        int ySize;

        public MazeConsoleDrawerSingleSide(int width, int height)
        {
            xSize = width - 1;
            ySize = height - 1;
        }

        public void DrawMaze(MazeSlot[,] maze)
        {
            screen = new string[maze.GetLength(0) * xSize, maze.GetLength(1) * ySize + 1];

            for (int y = maze.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    int screenX = x * xSize;
                    int screenY = y * ySize;

                    if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Rigth))
                    {
                        for (int i = 0; i < ySize; i++)
                        {
                            screen[screenX + xSize - 1, screenY + i] = WALL;
                        }
                    }
                    else
                    {
                        screen[screenX + xSize - 1, screenY] = FLOOR;
                    }

                    if (!maze[x, y].DestroyedWalls.Contains(WallPosition.Down))
                    {
                        for (int i = 0; i < xSize - 1; i++)
                        {
                            screen[screenX + i, screenY] = FLOOR;
                        }
                    }
                }
            }

            DrawUpperLeftBorder();
            DrawScreen();
        }

        private void DrawUpperLeftBorder()
        {
            for (int x = 0; x < screen.GetLength(0); x++)
            {
                screen[x, screen.GetLength(1) - 1] = FLOOR;
            }

            for (int y = ySize; y < screen.GetLength(1) - 1; y++)
            {
                screen[0, y] = WALL;
            }
        }

        private void DrawScreen()
        {
            for (int y = screen.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x < screen.GetLength(0); x++)
                {
                    if (string.IsNullOrEmpty(screen[x, y])) Console.Write(" ");
                    else Console.Write(screen[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
