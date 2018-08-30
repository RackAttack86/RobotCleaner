using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner;

namespace RobotCleanerTests
{
    [TestClass]
    public class CleaningRobotTests
    {
        #region Tests
        [TestMethod]
        public void InstantiationTest()
        {
            CleaningRobot robot = CreateTesterRobot(10, 22);
            Assert.AreEqual(10, robot.XCoordinate);
            Assert.AreEqual(22, robot.YCoordinate);
        }

        [TestMethod]
        public void MoveEast()
        {
            int x = 1000, y = -99, moveDistance = 1;
            CleaningRobot robot = CreateTesterRobot(x, y);
            robot.Move("E", moveDistance);
            Assert.AreEqual(x + moveDistance, robot.XCoordinate);
        }

        [TestMethod]
        public void MoveWest()
        {
            int x = 1000, y = -99, moveDistance = 3;
            CleaningRobot robot = CreateTesterRobot(x, y);
            robot.Move("W", moveDistance);
            Assert.AreEqual(x - moveDistance, robot.XCoordinate);
        }

        [TestMethod]
        public void MoveNorth()
        {
            int x = 1000, y = -99, moveDistance = 5;
            CleaningRobot robot = CreateTesterRobot(x, y);
            robot.Move("N", moveDistance);
            Assert.AreEqual(y + moveDistance, robot.YCoordinate);
        }

        [TestMethod]
        public void MoveSouth()
        {
            int x = 1000, y = -99, moveDistance = 10;
            CleaningRobot robot = CreateTesterRobot(x, y);
            robot.Move("S", moveDistance);
            Assert.AreEqual(y - moveDistance, robot.YCoordinate);
        }

        [TestMethod]
        public void RunCleaningRobot_LargeCommandsList()
        {
            int x = -100000, y = -100000;
            List<(string, int)> commands = new List<(string, int)>
            {
                ("E", 100000),
                ("N", 100000),
                ("W", 100000),
                ("S", 99999),
                ("E", 99999),
                ("N", 99998),
                ("W", 99997),
                ("S", 99996)
            };
            CleaningRobot robot = CreateTesterRobot(x, y);
            int spacesCleaned = robot.RunRobot(commands);
            Assert.AreEqual(799990, spacesCleaned);
            Assert.AreEqual(-99998, robot.XCoordinate);
            Assert.AreEqual(-99997, robot.YCoordinate);
        }

        [TestMethod]
        public void RunCleaningRobot_Circle()
        {
            int x = 0, y = 0;
            List<(string, int)> commands = new List<(string, int)>
            {
                ("E", 1),
                ("N", 1),
                ("W", 1),
                ("S", 1),
                ("E", 1),
                ("N", 1),
                ("W", 1),
                ("S", 1)
            };
            CleaningRobot robot = CreateTesterRobot(x, y);
            int spacesCleaned = robot.RunRobot(commands);
            Assert.AreEqual(4, spacesCleaned);
            Assert.AreEqual(x, robot.XCoordinate);
            Assert.AreEqual(y, robot.YCoordinate);
        }

        [TestMethod]
        public void RunCleaningRobot_NoMovement()
        {
            int x = 12, y = 13;
            List<(string, int)> commands = new List<(string, int)>
            {
                ("E", 0)
            };
            CleaningRobot robot = CreateTesterRobot(x, y);
            int spacesCleaned = robot.RunRobot(commands);
            Assert.AreEqual(1, spacesCleaned);
            Assert.AreEqual(12, robot.XCoordinate);
            Assert.AreEqual(13, robot.YCoordinate);
        }

        [TestMethod, Ignore]
        public void MaximumSpacesVisited()
        {
            int x = -100000, y = -100000;
            CleaningRobot robot = CreateTesterRobot(x, y);
            List<(string, int)> commands = new List<(string, int)>
            {
                ("E", 100000),
                ("N", 100000),
                ("W", 100000),
            };
            int z = 99998;
            int num = 9997;
            while (num > 0)
            {
                commands.Add(("S", z));
                commands.Add(("E", z));
                z--;
                commands.Add(("N", z));
                commands.Add(("W", z));
                z--;
                num--;
            }
            robot.RunRobot(commands);
        }
        #endregion

        #region Helper Methods
        private CleaningRobot CreateTesterRobot(int x, int y)
        {
            return new CleaningRobot(x, y);
        }
        #endregion
    }
}
