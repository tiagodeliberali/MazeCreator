using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeBuilderGame
{
    public class MazeSolver
    {
        private MazeSlot[,] maze;
        private MazeSlot end;
        Stack<MazeSlot> slotStack = new Stack<MazeSlot>();

        public MazeSolver(MazeSlot[,] maze)
        {
            this.maze = maze;
        }

        public Stack<MazeSlot> Solve(MazeSlot start, MazeSlot end)
        {
            this.end = end;
            return Move(start);
        }

        private Stack<MazeSlot> Move(MazeSlot slot)
        {
            if (slot.Equals(end))
            {
                slotStack.Push(slot);
                return slotStack;
            }

            List<MazeSlot> moves = NextMoves(slot);

            while (moves.Count > 0)
            {
                slotStack.Push(slot);
                slot.VisitedBySolver = true;
                slot = moves.First();

                if (slot.Equals(end))
                {
                    slotStack.Push(slot);
                    return slotStack;
                }

                moves = NextMoves(slot);

                if (moves.Count == 0)
                {
                    slot.VisitedBySolver = true;
                    do
                    {
                        if (slotStack.Count == 0) throw new Exception("Could not find a solution!");
                        slot = slotStack.Pop();
                        moves = NextMoves(slot);
                    }
                    while (moves.Count == 0);
                }
            }

            return slotStack;
        }

        public List<MazeSlot> NextMoves(MazeSlot slot)
        {
            List<MazeSlot> result = new List<MazeSlot>(4);

            if (slot.DestroyedWalls.Contains(WallPosition.Up) && !maze[slot.X, slot.Y + 1].VisitedBySolver) result.Add(maze[slot.X, slot.Y + 1]);
            if (slot.DestroyedWalls.Contains(WallPosition.Down) && !maze[slot.X, slot.Y - 1].VisitedBySolver) result.Add(maze[slot.X, slot.Y - 1]);
            if (slot.DestroyedWalls.Contains(WallPosition.Left) && !maze[slot.X - 1, slot.Y].VisitedBySolver) result.Add(maze[slot.X - 1, slot.Y]);
            if (slot.DestroyedWalls.Contains(WallPosition.Rigth) && !maze[slot.X + 1, slot.Y].VisitedBySolver) result.Add(maze[slot.X + 1, slot.Y]);

            return result;
        }
    }
}
