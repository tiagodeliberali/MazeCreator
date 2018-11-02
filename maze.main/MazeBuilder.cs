using System;
using System.Collections.Generic;

namespace MazeBuilderGame
{
    public class MazeBuilder
    {
        public MazeSlot[,] Maze { get; }
        Stack<MazeSlot> slotStack = new Stack<MazeSlot>();
        Random random = new Random();

        public MazeBuilder(int x, int y)
        {
            if (x <= 1 || y <= 1) throw new ArgumentOutOfRangeException();
            Maze = new MazeSlot[x, y];
            InitializeMaze();
        }

        void InitializeMaze()
        {
            for (int x = 0; x < Maze.GetLength(0); x++)
                for (int y = 0; y < Maze.GetLength(1); y++)
                {
                    Maze[x, y] = new MazeSlot(x, y);
                }
        }

        public void BuildMaze(MazeSlot slot)
        {
            slot.VisitedByBuilder = true;
            List<MazeSlot> neighbor = GetNeighbor(slot);

            if (neighbor.Count == 0)
            {
                if (slotStack.Count == 0) return;
                BuildMaze(slotStack.Pop());
            }
            else
            {
                slotStack.Push(slot);
                int nextPosition = random.Next(neighbor.Count);

                MazeSlot next = neighbor[nextPosition];
                slot.DestroyWall(next);
                next.DestroyWall(slot);

                BuildMaze(next);
            }
        }

        public List<MazeSlot> GetNeighbor(MazeSlot slot)
        {
            List<MazeSlot> result = new List<MazeSlot>(4);

            if (slot.X - 1 >= 0 && !Maze[slot.X - 1, slot.Y].VisitedByBuilder)  result.Add(Maze[slot.X - 1, slot.Y]);
            if (slot.X + 1 < Maze.GetLength(0) && !Maze[slot.X + 1, slot.Y].VisitedByBuilder)  result.Add(Maze[slot.X + 1, slot.Y]);
            if (slot.Y - 1 >= 0 && !Maze[slot.X, slot.Y - 1].VisitedByBuilder)  result.Add(Maze[slot.X, slot.Y - 1]);
            if (slot.Y + 1 < Maze.GetLength(1) && !Maze[slot.X, slot.Y + 1].VisitedByBuilder)  result.Add(Maze[slot.X, slot.Y + 1]);

            return result;
        }
    }
}
