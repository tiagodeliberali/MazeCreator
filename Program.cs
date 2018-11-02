using System;
using System.Collections.Generic;

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

    public class MazeBuilder
    {
        public MazeSlot[,] maze { get; }
        Stack<MazeSlot> slotStack = new Stack<MazeSlot>();
        Random random = new Random();

        public MazeBuilder(int x, int y)
        {
            if (x <= 1 || y <= 1) throw new ArgumentOutOfRangeException();
            maze = new MazeSlot[x, y];
            InitializeMaze();
        }

        void InitializeMaze()
        {
            for (int x = 0; x < maze.GetLength(0); x++)
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    maze[x, y] = new MazeSlot(x, y);
                }
        }

        public void BuildMaze(MazeSlot slot)
        {
            slot.Visited = true;
            List<MazeSlot> neighbor = GetNeighbor(slot);

            if (neighbor.Count == 0)
            {
                if (slotStack.Count == 0) return;
                BuildMaze(slotStack.Pop());
            }
            else
            {
                slotStack.Push(slot);
                int nextPosition = random.Next(neighbor.Count - 1);

                MazeSlot next = neighbor[nextPosition];
                slot.DestroyWall(next);
                next.DestroyWall(slot);

                BuildMaze(next);
            }
        }

        public List<MazeSlot> GetNeighbor(MazeSlot slot)
        {
            List<MazeSlot> result = new List<MazeSlot>();

            if (slot.X - 1 >= 0 && !maze[slot.X - 1, slot.Y].Visited)  result.Add(maze[slot.X - 1, slot.Y]);
            if (slot.X + 1 < maze.GetLength(0) && !maze[slot.X + 1, slot.Y].Visited)  result.Add(maze[slot.X + 1, slot.Y]);
            if (slot.Y - 1 >= 0 && !maze[slot.X, slot.Y - 1].Visited)  result.Add(maze[slot.X, slot.Y - 1]);
            if (slot.Y + 1 < maze.GetLength(1) && !maze[slot.X, slot.Y + 1].Visited)  result.Add(maze[slot.X, slot.Y + 1]);

            return result;
        }
    }

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

    public enum WallPosition
    {
        None,
        Up,
        Down,
        Left,
        Rigth
    }
}
