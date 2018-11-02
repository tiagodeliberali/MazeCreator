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

        public Stack<MazeSlot> Solve(MazeSlot[,] maze, MazeSlot start, MazeSlot end)
        {
            this.maze = maze;
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
                    if (slotStack.Count == 0) throw new Exception("Could not find a solution!");

                    moves = NextMoves(slotStack.Pop());
                    while (moves.Count == 0)
                    {
                        if (slotStack.Count == 0) throw new Exception("Could not find a solution!");
                        moves = NextMoves(slotStack.Pop());
                    }
                }
            }

            return slotStack;
        }

        private List<MazeSlot> NextMoves(MazeSlot slot)
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
