using System.Collections.Generic;

namespace MazeBuilderGame
{
    public class MazeSlot
    {
        public bool Visited { get; set; }
        public HashSet<WallPosition> DestroyedWalls { get; } = new HashSet<WallPosition>();
        public int X { get; }
        public int Y { get; }

        public MazeSlot(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void DestroyWall(MazeSlot other)
        {
            WallPosition position = WallPosition.None;

            if (X > other.X) position = WallPosition.Left;
            else if (X < other.X) position = WallPosition.Rigth;
            else if (Y > other.Y) position = WallPosition.Down;
            else if (Y < other.Y) position = WallPosition.Up;

            if (position != WallPosition.None) DestroyedWalls.Add(position);
        }
    }
}
