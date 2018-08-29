using System;
using System.Collections.Generic;

namespace RobotCleaner
{
    public class CleaningRobot
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int TotalUniqueSpacesCleaned { get; private set; }
        private Dictionary<(int xCoordinate, int yCoordinate), char> CoordinatesAlreadyCleaned { get; }        

        public CleaningRobot(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
            CoordinatesAlreadyCleaned = new Dictionary<(int, int), char>();
            CoordinatesAlreadyCleaned.Add(CreateTuple(x, y), 'x');
            TotalUniqueSpacesCleaned = 1;
            
        }

        public int RunRobot(List<(string direction, int spaces)> movementCommands)
        {
            foreach (var command in movementCommands)
            {
                Move(command.direction, command.spaces);
            }
            return TotalUniqueSpacesCleaned;
        }

        public bool IsNewSpot(int x, int y)
        {
            return !CoordinatesAlreadyCleaned.ContainsKey(CreateTuple(x, y));
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
                UpdateUniqueCleanedSpaces(XCoordinate, YCoordinate);
            }
        }

        #region Helper Methods

        private void UpdateUniqueCleanedSpaces(int x, int y)
        {
            if (IsNewSpot(x, y))
            {
                TotalUniqueSpacesCleaned += 1;
                CoordinatesAlreadyCleaned.Add(CreateTuple(x, y), 'x');
            }
        }

        private (int, int) CreateTuple(int x, int y)
        {
            return (x, y);
        }
        #endregion
    }
}
