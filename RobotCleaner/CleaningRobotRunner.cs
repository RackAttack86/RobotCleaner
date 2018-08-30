using System;
using System.Collections.Generic;

namespace RobotCleaner
{
    public class CleaningRobotRunner
    {
        public static void Main()
        {
            string[] lines = Properties.Resources.ExampleInputs.Split(new [] {Environment.NewLine}, StringSplitOptions.None);
            int.TryParse(lines[0], out int numCommands);

            string[] startingPosition = lines[1].Split(' ');
            int.TryParse(startingPosition[0], out int x);
            int.TryParse(startingPosition[1], out int y);

            CleaningRobot robot = new CleaningRobot(x, y);

            const int commandsStartLine = 2;
            List<(string direction, int spaces)> movementCommands = new List<(string, int)>();
            for (int i = 0; i < numCommands; i++)
            {
                string[] movementCommand = lines[i + commandsStartLine].Split(' ');
                string direction = movementCommand[0];
                int.TryParse(movementCommand[1], out int spaces);
                movementCommands.Add((direction, spaces));
            }

            int cleaned = robot.RunRobot(movementCommands);
            Console.WriteLine($@"=> Cleaned: {cleaned}");
            Console.ReadLine();
        }
    }
}
