using System;
using System.Collections.Generic;

namespace RobotCleaner
{
    public class CleaningRobot
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        private HashSet<(int xCoordinate, int yCoordinate)> CoordinatesAlreadyCleaned { get; }

        public CleaningRobot(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
            CoordinatesAlreadyCleaned = new HashSet<(int, int)>();
            CoordinatesAlreadyCleaned.Add((x, y));

        }

        public int RunRobot(List<(string direction, int spaces)> movementCommands)
        {
            foreach (var command in movementCommands)
            {
                Move(command.direction, command.spaces);
            }

            return CoordinatesAlreadyCleaned.Count;
        }

        public void Move(string direction, int spaces)
        {
            for (int i = 0; i < spaces; i++)
            {
                switch (direction.ToUpper())
                {
                    case "N":
                        YCoordinate += 1;
                        break;
                    case "S":
                        YCoordinate -= 1;
                        break;
                    case "E":
                        XCoordinate += 1;
                        break;
                    case "W":
                        XCoordinate -= 1;
                        break;
                }

                CoordinatesAlreadyCleaned.Add((XCoordinate, YCoordinate));
            }
        }
    }
}
