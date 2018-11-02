using System;
using System.Collections.Generic;

namespace MazeBuilderGame
{
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
}
