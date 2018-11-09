using System;

namespace MazeBuilderGame
{
    public class MazeConsoleDrawerSingleSide : MazeDrawerSingleSide<string>
    {
        public MazeConsoleDrawerSingleSide(int width, int height) : base(width, height, "▒", "▓")
        {
        }

        protected override void DrawScreen()
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
