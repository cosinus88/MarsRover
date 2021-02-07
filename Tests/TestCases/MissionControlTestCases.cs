using MarsRover.Models;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Tests.TestCases
{
    public class MissionControlTestCases
    {
        public static IEnumerable ValidateMissionTestCases
        {
            get
            {

                yield return new TestCaseData(new Position(0, 0, Direction.N), new[] { Command.M }, new Position( 0, 1, Direction.N), false)
                .SetName("Move north");

                yield return new TestCaseData(new Position(0, 0, Direction.N), new[] { Command.R }, new Position(0, 0, Direction.E), false)
                .SetName("Turn right");

                yield return new TestCaseData(new Position(0, 0, Direction.N), new[] { Command.L }, new Position(0, 0, Direction.W), false)
               .SetName("Turn left");

                yield return new TestCaseData(new Position(0, 0, Direction.N), new[] { Command.R, Command.M }, new Position(1, 0, Direction.E), false)
               .SetName("Turn right and move to the east");

                yield return new TestCaseData(new Position(0, 0, Direction.N), new[] { Command.R, Command.R, Command.M }, new Position(0, 0, Direction.S), true)
               .SetName("Attempt to move outside of the plateu");

            }
        }
    }
}
