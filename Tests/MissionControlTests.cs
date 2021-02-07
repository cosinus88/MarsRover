using MarsRover.Models;
using MarsRover.Tests.TestCases;
using NUnit.Framework;
using System.Linq;

namespace MarsRover.Tests
{
    [TestFixture]
    public class MissionControlTests
    {
        [SetUp]
        public void Setup()
        {
            MissionControl.SetPlateu(new Size(6, 6));
        }

        [Test(Description = "Tests to check that mission control commands interpreted correctly"),
            TestCaseSource(typeof(MissionControlTestCases), nameof(MissionControlTestCases.ValidateMissionTestCases))]
        public void ValidateMoves(Position originalPosition, Command[] commands, Position expected, bool hasError)
        {

            var rover = MissionControl.LaunchRover(originalPosition);

            // Act
            var result = (CommandResult)null;
            
            commands.ToList().ForEach(x =>
            {
                result = MissionControl.Move(rover.Id, x);
            });

            var resultError = !string.IsNullOrEmpty(result.Error);
            
            //Assert
            Assert.AreEqual(expected, result.Position);

            Assert.AreEqual(hasError, resultError);
        }
    }
}
