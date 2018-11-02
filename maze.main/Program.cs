using System;
using System.Collections.Generic;

namespace MazeBuilderGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int x = 5;
            int y = 5;
            bool showSolution = true;
            do
            {
                Console.Clear();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    try
                    {
                        string[] splitedInput = input.Split(",");
                        x = int.Parse(splitedInput[0]);
                        y = int.Parse(splitedInput[1]);

                        if (splitedInput.Length > 2)
                            showSolution = bool.Parse(splitedInput[2]);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Entrada inválida. Use Valor,Valor[,MostrarSolucao]. Ex: 10,10 ou 10,10,true");
                        Console.WriteLine();
                    }
                }

                MazeSlot[,] maze = BuildMaze(x, y);
                if (showSolution)
                    SolveMaze(maze);

                MazeConsoleDrawer.DrawMaze(maze);
                Console.Write("Gerar outro labirinto [{0},{1},{2}] ('q' para sair): ", x, y, showSolution);
                input = Console.ReadLine();
            }
            while(input != "q");
        }

        private static MazeSlot[,] BuildMaze(int x, int y)
        {
            MazeBuilder builder = new MazeBuilder(x, y);
            builder.BuildMaze(builder.Maze[0, 0]);
            return builder.Maze;
        }

        private static void SolveMaze(MazeSlot[,] maze)
        {
            try
            {
                MazeSolver solver = new MazeSolver(maze);
                Stack<MazeSlot> solution = solver.Solve(maze[0, 0], maze[maze.GetLength(0) - 1, maze.GetLength(1) - 1]);

                while (solution.Count > 0)
                {
                    MazeSlot slot = solution.Pop();
                    maze[slot.X, slot.Y].SolutionPath = true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine("Não achei uma solução para esse labirinto");
            }
        }
    }
}
